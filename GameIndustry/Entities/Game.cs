using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameIndustry.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public Studio Studio { get; set; }

        [MaxLength(50)]
        public string? Style { get; set; }

        [Required]
        public int Sales { get; set; }

        [Required]
        public int Popularity { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public bool HasSingleplayer { get; set; }

        [Required]
        public bool HasMultiplayer { get; set; }

        public override string ToString()
        {
            var gameMode = HasSingleplayer && HasMultiplayer ? "Singleplayer And Multiplayer"
                            : HasSingleplayer ? "Singleplayer"
                            : HasMultiplayer ? "Multiplayer"
                            : "Other";

            var sb = new StringBuilder();
            sb.AppendLine($"Game (ID:{Id}): {Title}");
            sb.AppendLine($"Studio: {Studio.Name}");
            sb.AppendLine($"Style: {Style}");
            sb.AppendLine($"Game Mode: {gameMode}");
            sb.AppendLine($"ReleaseYear: {ReleaseYear}");
            sb.AppendLine($"Popularity: {Popularity}");
            sb.AppendLine($"Sales: {Sales}");

            return sb.ToString();
        }
    }
}
