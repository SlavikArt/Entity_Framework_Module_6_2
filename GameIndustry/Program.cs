using GameIndustry.Entities;
using Microsoft.IdentityModel.Tokens;
using System;

namespace GameIndustry
{
    public class Program
    {
        private static GameRepository gameRepo;

        static void Main(string[] args)
        {
            // Data Insert
            using (var db = new GameContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var studio1 = new Studio
                {
                    Name = "Naughty Dog",
                    Cities = new List<City>
                    {
                        new City { Name = "Los Angeles" },
                        new City { Name = "Vancouver" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "USA" },
                        new Country { Name = "Canada" }
                    }
                };

                var studio2 = new Studio
                {
                    Name = "Rockstar Games",
                    Cities = new List<City>
                    {
                        new City { Name = "New York" },
                        new City { Name = "London" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "USA" },
                        new Country { Name = "UK" }
                    }
                };

                var studio3 = new Studio
                {
                    Name = "Bethesda Game Studios",
                    Cities = new List<City>
                    {
                        new City { Name = "Rockville" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "USA" }
                    }
                };

                var studio4 = new Studio
                {
                    Name = "Ubisoft Montreal",
                    Cities = new List<City>
                    {
                        new City { Name = "Montreal" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Canada" }
                    }
                };

                var studio5 = new Studio
                {
                    Name = "CD Projekt Red",
                    Cities = new List<City>
                    {
                        new City { Name = "Warsaw" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Poland" }
                    }
                };

                var studio6 = new Studio
                {
                    Name = "FromSoftware",
                    Cities = new List<City>
                    {
                        new City { Name = "Tokyo" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Japan" }
                    }
                };

                var studio7 = new Studio
                {
                    Name = "Insomniac Games",
                    Cities = new List<City>
                    {
                        new City { Name = "Burbank" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "USA" }
                    }
                };

                var studio8 = new Studio
                {
                    Name = "Square Enix",
                    Cities = new List<City>
                    {
                        new City { Name = "Tokyo" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Japan" }
                    }
                };

                var studio9 = new Studio
                {
                    Name = "Capcom",
                    Cities = new List<City>
                    {
                        new City { Name = "Osaka" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Japan" }
                    }
                };

                var studio10 = new Studio
                {
                    Name = "BioWare",
                    Cities = new List<City>
                    {
                        new City { Name = "Edmonton" },
                        new City { Name = "Austin" }
                    },
                    Countries = new List<Country>
                    {
                        new Country { Name = "Canada" },
                        new Country { Name = "USA" }
                    }
                };

                db.Studios.AddRange(studio1, studio2, studio3, studio4, studio5,
                    studio6, studio7, studio8, studio9, studio10);

                var game1 = new Game {
                    Title = "The Last of Us Part II", Studio = studio1,
                    Style = "Action-adventure",
                    Sales = 4000000, Popularity = 90, ReleaseYear = 2020,
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game2 = new Game {
                    Title = "Red Dead Redemption 2", Studio = studio2,
                    Style = "Action-adventure", 
                    Sales = 32000000, Popularity = 93, ReleaseYear = 2018,
                    HasSingleplayer = true, HasMultiplayer = true 
                };
                var game3 = new Game { 
                    Title = "The Elder Scrolls V: Skyrim", Studio = studio3, 
                    Style = "Action role-playing", 
                    Sales = 30000000, Popularity = 94, ReleaseYear = 2011, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game4 = new Game { 
                    Title = "Assassin's Creed Valhalla", Studio = studio4, 
                    Style = "Action role-playing", 
                    Sales = 2000000, Popularity = 85, ReleaseYear = 2020, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game5 = new Game { 
                    Title = "Cyberpunk 2077", Studio = studio5, 
                    Style = "Action role-playing", 
                    Sales = 13000000, Popularity = 70, ReleaseYear = 2020, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game6 = new Game { 
                    Title = "Dark Souls III", Studio = studio6, 
                    Style = "Action role-playing", 
                    Sales = 3000000, Popularity = 89, ReleaseYear = 2016, 
                    HasSingleplayer = true, HasMultiplayer = true 
                };
                var game7 = new Game { 
                    Title = "Spider-Man: Miles Morales", Studio = studio7, 
                    Style = "Action-adventure", 
                    Sales = 4100000, Popularity = 85, ReleaseYear = 2020, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game8 = new Game { 
                    Title = "Final Fantasy VII Remake", Studio = studio8, 
                    Style = "Action role-playing", 
                    Sales = 5000000, Popularity = 87, ReleaseYear = 2020, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game9 = new Game { 
                    Title = "Resident Evil 3", Studio = studio9, 
                    Style = "Survival horror",
                    Sales = 3600000, Popularity = 79, ReleaseYear = 2020, 
                    HasSingleplayer = true, HasMultiplayer = false 
                };
                var game10 = new Game { 
                    Title = "Mass Effect: Legendary Edition", Studio = studio10,
                    Style = "Action role-playing",
                    Sales = 500000, Popularity = 86, ReleaseYear = 2021,
                    HasSingleplayer = true, HasMultiplayer = false 
                };

                db.Games.AddRange(game1, game2, game3, game4, game5, 
                    game6, game7, game8, game9, game10);

                db.SaveChanges();
            }

            // Data Output
            using (var db = new GameContext())
            {
                gameRepo = new GameRepository(db);

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("1) Search info (Game, Studio)");
                    Console.WriteLine("2) Show info by Game parameters");
                    Console.WriteLine("3) Show additional Game info");
                    Console.WriteLine("4) Add/Update/Delete -> Game/Studio");
                    Console.WriteLine("5) Exit");

                    Console.Write("\nChoose an option: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            SearchInfo();
                            break;
                        case "2":
                            ShowInfo();
                            break;
                        case "3":
                            ShowAdditionalInfo();
                            break;
                        case "4":
                            EditInfo();
                            break;
                        case "5":
                            return;
                    }
                }
            }
        }

        private static void SearchInfo()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("1) Game By Title");
                    Console.WriteLine("2) Games By Studio");
                    Console.WriteLine("3) Game By Studio And Title");
                    Console.WriteLine("4) Games By Style");
                    Console.WriteLine("5) Games By Release Year");
                    Console.WriteLine("6) Studio By Name");
                    Console.WriteLine("7) Studios By City");
                    Console.WriteLine("8) Studios By Country");
                    Console.WriteLine("9) Return");

                    Console.Write("\nChoose an option: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter game title: ");
                            var gameTitle = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(gameTitle))
                            {
                                Console.WriteLine("Game title cannot be empty." +
                                    " Please enter a valid title.");
                                break;
                            }

                            var gameByTitle = gameRepo.GetGameByTitle(gameTitle);

                            if (gameByTitle != null)
                                GameRepository.Print(gameByTitle);
                            else
                                Console.WriteLine("Game not found");
                            break;
                        case "2":
                            Console.Write("Enter studio name: ");
                            var studioName = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(studioName))
                            {
                                Console.WriteLine("Studio name cannot be empty." +
                                    " Please enter a valid name.");
                                break;
                            }

                            var gamesByStudio = gameRepo.GetGamesByStudio(studioName);

                            if (!gamesByStudio.IsNullOrEmpty())
                                GameRepository.Print(gamesByStudio);
                            else
                                Console.WriteLine("Games not found");
                            break;
                        case "3":
                            Console.Write("Enter studio name: ");
                            studioName = Console.ReadLine();

                            Console.Write("Enter game title: ");
                            gameTitle = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(studioName) || string.IsNullOrWhiteSpace(gameTitle))
                            {
                                Console.WriteLine("Studio name and game title cannot be empty." +
                                    " Please enter valid values.");
                                break;
                            }

                            var specificGame = gameRepo.GetGameByStudioAndTitle(studioName, gameTitle);

                            if (specificGame != null)
                                GameRepository.Print(specificGame);
                            else
                                Console.WriteLine("Game not found");
                            break;

                        case "4":
                            Console.Write("Enter game style: ");
                            var style = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(style))
                            {
                                Console.WriteLine("Game style cannot be empty." +
                                    " Please enter a valid style.");
                                break;
                            }

                            var gamesByStyle = gameRepo.GetGamesByStyle(style);

                            if (!gamesByStyle.IsNullOrEmpty())
                                GameRepository.Print(gamesByStyle);
                            else
                                Console.WriteLine("Games not found");
                            break;

                        case "5":
                            Console.Write("Enter release year: ");
                            var yearInput = Console.ReadLine();

                            Console.WriteLine();

                            if (!int.TryParse(yearInput, out var year))
                            {
                                Console.WriteLine("Invalid input." +
                                    " Please enter a valid year.");
                                break;
                            }

                            var gamesByYear = gameRepo.GetGamesByReleaseYear(year);

                            if (!gamesByYear.IsNullOrEmpty())
                                GameRepository.Print(gamesByYear);
                            else
                                Console.WriteLine("Games not found");
                            break;
                        case "6":
                            Console.Write("Enter studio name: ");
                            studioName = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(studioName))
                            {
                                Console.WriteLine("Studio name cannot be empty." +
                                    " Please enter a valid name.");
                                break;
                            }

                            var studioByName = gameRepo.GetStudioByName(studioName);

                            if (studioByName != null)
                                GameRepository.Print(studioByName);
                            else
                                Console.WriteLine("Studio not found");
                            break;
                        case "7":
                            Console.Write("Enter city name: ");
                            var cityName = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(cityName))
                            {
                                Console.WriteLine("City name cannot be empty." +
                                    " Please enter a valid name.");
                                break;
                            }

                            var studiosByCity = gameRepo.GetStudiosByCity(cityName);

                            if (!studiosByCity.IsNullOrEmpty())
                                GameRepository.Print(studiosByCity);
                            else
                                Console.WriteLine("No studios found in this city");
                            break;
                        case "8":
                            Console.Write("Enter country name: ");
                            var countryName = Console.ReadLine();

                            Console.WriteLine();

                            if (string.IsNullOrWhiteSpace(countryName))
                            {
                                Console.WriteLine("Country name cannot be empty." +
                                    " Please enter a valid name.");
                                break;
                            }

                            var studiosByCountry = gameRepo.GetStudiosByCountry(countryName);

                            if (!studiosByCountry.IsNullOrEmpty())
                                GameRepository.Print(studiosByCountry);
                            else
                                Console.WriteLine("No studios found in this country");
                            break;
                        case "9":
                            return;
                        default:
                            Console.WriteLine("Invalid option." +
                                " Please choose a valid option.");
                            break;
                    }

                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
            }  
        }

        private static void ShowInfo()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("1) Singleplayer Games");
                    Console.WriteLine("2) Multiplayer Games");
                    Console.WriteLine("3) Top Selling Game");
                    Console.WriteLine("4) Least Selling Game");
                    Console.WriteLine("5) Top Popular Games");
                    Console.WriteLine("6) Top Least Popular Games");
                    Console.WriteLine("7) Return");

                    Console.Write("\nChoose an option: ");
                    var showOption = Console.ReadLine();

                    switch (showOption)
                    {
                        case "1":
                            var singleplayerGames = gameRepo.GetSinglePlayerGames();

                            Console.WriteLine();

                            if (!singleplayerGames.IsNullOrEmpty())
                                GameRepository.Print(singleplayerGames);
                            else
                                Console.WriteLine("No singleplayer games found");
                            break;
                        case "2":
                            var multiplayerGames = gameRepo.GetMultiplayerGames();

                            Console.WriteLine();

                            if (!multiplayerGames.IsNullOrEmpty())
                                GameRepository.Print(multiplayerGames);
                            else
                                Console.WriteLine("No multiplayer games found");
                            break;
                        case "3":
                            var topSellingGame = gameRepo.GetTopSellingGame();

                            Console.WriteLine();

                            if (topSellingGame != null)
                                GameRepository.Print(topSellingGame);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "4":
                            var leastSellingGame = gameRepo.GetLeastSellingGame();

                            Console.WriteLine();

                            if (leastSellingGame != null)
                                GameRepository.Print(leastSellingGame);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "5":
                            var top3Games = gameRepo.GetTopPopularGames();

                            Console.WriteLine();

                            if (!top3Games.IsNullOrEmpty())
                                GameRepository.Print(top3Games);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "6":
                            var least3Games = gameRepo.GetTopLeastPopularGames();

                            Console.WriteLine();

                            if (!least3Games.IsNullOrEmpty())
                                GameRepository.Print(least3Games);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Invalid option." +
                                " Please choose a valid option.");
                            break;
                    }

                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void ShowAdditionalInfo()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("1) Singleplayer Games Count");
                    Console.WriteLine("2) Multiplayer Games Count");
                    Console.WriteLine("3) Top Selling Game By Style");
                    Console.WriteLine("4) Top Least Selling Game By Style");
                    Console.WriteLine("5) Top 5 Popular Games By Style");
                    Console.WriteLine("6) Top 5 Least Popular Games By Style");
                    Console.WriteLine("7) Studios And Their Dominant Style");
                    Console.WriteLine("8) Return");

                    Console.Write("\nChoose an option: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            var singleplayerGamesCount = gameRepo.GetSinglePlayerGames().Count;

                            Console.WriteLine();

                            if (singleplayerGamesCount > 0)
                                Console.WriteLine($"Singleplayer Games Count: {singleplayerGamesCount}");
                            else
                                Console.WriteLine("No singleplayer games found");
                            break;
                        case "2":
                            var multiplayerGamesCount = gameRepo.GetMultiplayerGames().Count;

                            Console.WriteLine();

                            if (multiplayerGamesCount > 0)
                                Console.WriteLine($"Multiplayer Games Count: {multiplayerGamesCount}");
                            else
                                Console.WriteLine("No singleplayer games found");
                            break;
                        case "3":
                            Console.Write("Enter game style: ");
                            var style = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(style))
                            {
                                Console.WriteLine("Game style cannot be empty." +
                                    " Please enter a valid style.");
                                break;
                            }

                            Console.WriteLine();

                            var topSellingGameByStyle = gameRepo.GetTopSellingGameByStyle(style);

                            if (topSellingGameByStyle != null)
                                GameRepository.Print(topSellingGameByStyle);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "4":
                            Console.Write("Enter game style: ");
                            style = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(style))
                            {
                                Console.WriteLine("Game style cannot be empty." +
                                    " Please enter a valid style.");
                                break;
                            }

                            Console.WriteLine();

                            var leastSellingGameByStyle = gameRepo.GetTopLeastSellingGameByStyle(style);

                            if (leastSellingGameByStyle != null)
                                GameRepository.Print(leastSellingGameByStyle);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "5":
                            Console.Write("Enter game style: ");
                            style = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(style))
                            {
                                Console.WriteLine("Game style cannot be empty." +
                                    " Please enter a valid style.");
                                break;
                            }

                            Console.WriteLine();

                            var top5GamesByStyle = gameRepo.GetTopPopularGamesByStyle(style, 5);

                            if (!top5GamesByStyle.IsNullOrEmpty())
                                GameRepository.Print(top5GamesByStyle);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "6":
                            Console.Write("Enter game style: ");
                            style = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(style))
                            {
                                Console.WriteLine("Game style cannot be empty." +
                                    " Please enter a valid style.");
                                break;
                            }

                            Console.WriteLine();

                            var least5GamesByStyle = gameRepo.GetTopLeastPopularGamesByStyle(style, 5);

                            if (!least5GamesByStyle.IsNullOrEmpty())
                                GameRepository.Print(least5GamesByStyle);
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "7":
                            var studiosAndStyles = gameRepo.GetDominantGameStyleByStudio();

                            Console.WriteLine();

                            if (!studiosAndStyles.IsNullOrEmpty())
                                foreach (var item in studiosAndStyles)
                                    Console.WriteLine($"Studio: {item.Key}\nDominant Style: {item.Value}\n");
                            else
                                Console.WriteLine("No games found");
                            break;
                        case "8":
                            return;
                        default:
                            Console.WriteLine("Invalid option." +
                                " Please choose a valid option.");
                            break;
                    }

                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void EditInfo()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("1) Add Game");
                    Console.WriteLine("2) Update Game");
                    Console.WriteLine("3) Delete Game");
                    Console.WriteLine("4) Add Studio");
                    Console.WriteLine("5) Update Studio");
                    Console.WriteLine("6) Delete Studio");
                    Console.WriteLine("7) Return");

                    Console.Write("\nChoose an option: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter game title: ");
                            var gameTitle = Console.ReadLine();

                            Console.Write("Enter game studio name: ");
                            var studioName = Console.ReadLine();

                            var studio = gameRepo.GetStudioByName(studioName);
                            if (studio == null)
                            {
                                studio = new Studio { Name = studioName };
                                gameRepo.AddStudio(studio);
                            }

                            Console.Write("Enter game style: ");
                            var gameStyle = Console.ReadLine();

                            Console.Write("Enter game sales: ");
                            var gameSales = int.Parse(Console.ReadLine());

                            Console.Write("Enter game popularity: ");
                            var gamePopularity = int.Parse(Console.ReadLine());

                            Console.Write("Enter game release year: ");
                            var gameReleaseYear = int.Parse(Console.ReadLine());

                            Console.Write("Does the game have singleplayer mode? (yes/no): ");
                            var hasSingleplayer = Console.ReadLine().ToLower() == "yes";

                            Console.Write("Does the game have multiplayer mode? (yes/no): ");
                            var hasMultiplayer = Console.ReadLine().ToLower() == "yes";

                            var newGame = new Game
                            {
                                Title = gameTitle,
                                Studio = studio,
                                Style = gameStyle,
                                Sales = gameSales,
                                Popularity = gamePopularity,
                                ReleaseYear = gameReleaseYear,
                                HasSingleplayer = hasSingleplayer,
                                HasMultiplayer = hasMultiplayer
                            };

                            gameRepo.AddGame(newGame);

                            Console.WriteLine("Game added successfully!");
                            break;
                        case "2":
                            Console.Write("Enter game id to update: ");
                            if (!int.TryParse(Console.ReadLine(), out var gameId))
                            {
                                Console.WriteLine("Invalid input." +
                                    " Please enter a valid game id.");
                                break;
                            }

                            var gameToUpdate = gameRepo.GetGameById(gameId);

                            if (gameToUpdate != null)
                            {
                                Console.Write("Enter new game title: ");
                                gameToUpdate.Title = Console.ReadLine();

                                Console.Write("Enter new game style: ");
                                gameToUpdate.Style = Console.ReadLine();

                                Console.Write("Enter new game sales: ");
                                gameToUpdate.Sales = int.Parse(Console.ReadLine());

                                Console.Write("Enter new game popularity: ");
                                gameToUpdate.Popularity = int.Parse(Console.ReadLine());

                                Console.Write("Enter new game release year: ");
                                gameToUpdate.ReleaseYear = int.Parse(Console.ReadLine());

                                Console.Write("Does the game have singleplayer mode? (yes/no): ");
                                gameToUpdate.HasSingleplayer = Console.ReadLine().ToLower() == "yes";

                                Console.Write("Does the game have multiplayer mode? (yes/no): ");
                                gameToUpdate.HasMultiplayer = Console.ReadLine().ToLower() == "yes";

                                gameRepo.UpdateGame(gameToUpdate);

                                Console.WriteLine("Game updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Game not found");
                            }
                            break;
                        case "3":
                            Console.Write("Enter game id to delete: ");
                            gameId = int.Parse(Console.ReadLine());

                            gameRepo.DeleteGame(gameId);

                            Console.WriteLine("Game deleted successfully!");
                            break;
                        case "4":
                            Console.Write("Enter studio name: ");
                            studioName = Console.ReadLine();

                            studio = new Studio { Name = studioName };

                            gameRepo.AddStudio(studio);

                            Console.WriteLine("Studio added successfully!");
                            break;
                        case "5":
                            Console.Write("Enter studio id to update: ");
                            if (!int.TryParse(Console.ReadLine(), out var studioId))
                            {
                                Console.WriteLine("Invalid input." +
                                    " Please enter a valid studio id.");
                                break;
                            }

                            var studioToUpdate = gameRepo.GetStudioById(studioId);

                            if (studioToUpdate != null)
                            {
                                Console.Write("Enter new studio name: ");
                                studioToUpdate.Name = Console.ReadLine();

                                gameRepo.UpdateStudio(studioToUpdate);

                                Console.WriteLine("Studio updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Studio not found");
                            }
                            break;
                        case "6":
                            Console.Write("Enter studio id to delete: ");
                            studioId = int.Parse(Console.ReadLine());

                            gameRepo.DeleteStudio(studioId);

                            Console.WriteLine("Studio deleted successfully!");
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Invalid option." +
                                " Please choose a valid option.");
                            break;
                    }

                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
