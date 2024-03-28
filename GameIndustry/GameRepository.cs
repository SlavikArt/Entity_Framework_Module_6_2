using GameIndustry.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameIndustry
{
    public class GameRepository
    {
        private GameContext db;

        public GameRepository(GameContext context)
        {
            db = context;
        }

        // Get game by ID
        public Game? GetGameById(int id)
        {
            return db.Games.Include(g => g.Studio).FirstOrDefault(g => g.Id == id);
        }

        // Get game by title
        public Game? GetGameByTitle(string title)
        {
            return db.Games.Include(g => g.Studio).FirstOrDefault(g => g.Title == title);
        }

        // Get games by studio name
        public List<Game> GetGamesByStudio(string studioName)
        {
            return db.Games.Include(g => g.Studio).Where(g => g.Studio.Name == studioName).ToList();
        }

        // Get game by studio and game title
        public Game? GetGameByStudioAndTitle(string studioName, string gameTitle)
        {
            return db.Games.Include(g => g.Studio)
                .FirstOrDefault(g => g.Studio.Name == studioName && g.Title == gameTitle);
        }

        // Get games by style
        public List<Game> GetGamesByStyle(string style)
        {
            return db.Games.Include(g => g.Studio).Where(g => g.Style == style).ToList();
        }

        // Get games by release year
        public List<Game> GetGamesByReleaseYear(int year)
        {
            return db.Games.Include(g => g.Studio).Where(g => g.ReleaseYear == year).ToList();
        }

        // Get all singleplayer games
        public List<Game> GetSinglePlayerGames()
        {
            return db.Games.Include(g => g.Studio).Where(g => g.HasSingleplayer == true).ToList();
        }

        // Get all multiplayer games
        public List<Game> GetMultiplayerGames()
        {
            return db.Games.Include(g => g.Studio).Where(g => g.HasMultiplayer == true).ToList();
        }

        // Get the game with the most sales
        public Game? GetTopSellingGame()
        {
            return db.Games.Include(g => g.Studio)
                .OrderByDescending(g => g.Sales).FirstOrDefault();
        }

        // Get the game with the least sales
        public Game? GetLeastSellingGame()
        {
            return db.Games.Include(g => g.Studio).OrderBy(g => g.Sales).FirstOrDefault();
        }

        // Get the top X most popular games
        public List<Game> GetTopPopularGames(int top = 3)
        {
            return db.Games.Include(g => g.Studio)
                .OrderByDescending(g => g.Popularity).Take(top).ToList();
        }

        // Get the top X least popular games
        public List<Game> GetTopLeastPopularGames(int top = 3)
        {
            return db.Games.Include(g => g.Studio)
                .OrderBy(g => g.Popularity).Take(top).ToList();
        }

        // Get top selling game by style
        public Game? GetTopSellingGameByStyle(string style)
        {
            return db.Games.Where(g => g.Style == style)
                .OrderByDescending(g => g.Sales).FirstOrDefault();
        }

        // Get top least selling game by style
        public Game? GetTopLeastSellingGameByStyle(string style)
        {
            return db.Games.Where(g => g.Style == style)
                .OrderBy(g => g.Sales).FirstOrDefault();
        }

        // Get top popular games by style
        public List<Game> GetTopPopularGamesByStyle(string style, int top = 3)
        {
            return db.Games.Where(g => g.Style == style)
                .OrderByDescending(g => g.Popularity).Take(top).ToList();
        }

        // Get top least popular games by style
        public List<Game> GetTopLeastPopularGamesByStyle(string style, int top = 3)
        {
            return db.Games.Where(g => g.Style == style)
                .OrderBy(g => g.Popularity).Take(top).ToList();
        }

        // Get dominant game style by studio
        public Dictionary<string, string> GetDominantGameStyleByStudio()
        {
            var res = new Dictionary<string, string>();
            var studios = db.Studios.Include(s => s.Games).ToList();

            foreach (var studio in studios)
            {
                var dominantStyle = studio.Games
                    .GroupBy(g => g.Style)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault();

                if (dominantStyle != null)
                    res.Add(studio.Name, dominantStyle.Key);
            }
            return res;
        }

        // Add a new game
        public void AddGame(Game game)
        {
            if (!db.Games.Any(g => g.Title == game.Title))
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        // Update game
        public void UpdateGame(Game game)
        {
            var gameToUpdate = db.Games.FirstOrDefault(g => g.Id == game.Id);
            if (gameToUpdate != null)
            {
                gameToUpdate = game;
                db.SaveChanges();
            }
        }

        // Delete game by id
        public void DeleteGame(int gameId)
        {
            var gameToDelete = db.Games.FirstOrDefault(g => g.Id == gameId);
            if (gameToDelete != null)
            {
                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }
        }

        // Delete game by studio name and game title
        public void DeleteGame(string studioName, string gameTitle)
        {
            var gameToDelete = GetGameByStudioAndTitle(studioName, gameTitle);
            if (gameToDelete != null)
            {
                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }
        }

        // Get studio by ID
        public Studio? GetStudioById(int id)
        {
            return db.Studios.Include(s => s.Games).FirstOrDefault(s => s.Id == id);
        }

        // Get studio by name
        public Studio? GetStudioByName(string studioName)
        {
            return db.Studios.Include(s => s.Games).
                Include(s => s.Cities).Include(s => s.Countries)
                .FirstOrDefault(s => s.Name == studioName);
        }

        // Get studios by city
        public List<Studio> GetStudiosByCity(string cityName)
        {
            return db.Studios.Include(s => s.Games)
                .Include(s => s.Cities).Include(s => s.Countries)
                .Where(s => s.Cities.Any(c => c.Name == cityName)).ToList();
        }

        // Get studios by country
        public List<Studio> GetStudiosByCountry(string countryName)
        {
            return db.Studios.Include(s => s.Games)
                .Include(s => s.Cities).Include(s => s.Countries)
                .Where(s => s.Countries.Any(c => c.Name == countryName)).ToList();
        }

        // Add a new studio
        public void AddStudio(Studio studio)
        {
            if (!db.Studios.Any(s => s.Name == studio.Name))
            {
                db.Studios.Add(studio);
                db.SaveChanges();
            }
        }

        // Update studio
        public void UpdateStudio(Studio studio)
        {
            var studioToUpdate = db.Studios.FirstOrDefault(s => s.Id == studio.Id);

            if (studioToUpdate != null)
            {
                studioToUpdate = studio;
                db.SaveChanges();
            }
        }

        // Delete studio by id
        public void DeleteStudio(int studioId)
        {
            var studioToDelete = db.Studios.FirstOrDefault(s => s.Id == studioId);

            if (studioToDelete != null)
            {
                db.Studios.Remove(studioToDelete);
                db.SaveChanges();
            }
        }

        // Print game info
        public static void Print(Game game)
        {
            Console.WriteLine(game);
        }

        // Print games info
        public static void Print(IEnumerable<Game> games)
        {
            foreach (var game in games)
                Console.WriteLine(game);
        }

        // Print studio info
        public static void Print(Studio studio)
        {
            Console.WriteLine(studio);
        }

        // Print studios info
        public static void Print(IEnumerable<Studio> studios)
        {
            foreach (var studio in studios)
                Console.WriteLine(studio);
        }
    }
}