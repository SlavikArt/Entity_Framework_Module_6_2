using System.ComponentModel.DataAnnotations;

namespace GameIndustry.Entities
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Game> Games { get; set; }

        public Studio()
        {
            Countries = new List<Country>();
            Cities = new List<City>();
        }

        public override string ToString()
        {
            var countries = Countries.Select(c => c.ToString()).ToList();
            var cities = Cities.Select(c => c.ToString()).ToList();

            return $"Studio (ID:{Id}): {Name}\n" +
                   $"Countries: {string.Join(", ", countries)}\n" +
                   $"Cities: {string.Join(", ", cities)}\n" +
                   $"Games: {Games.Count}\n";
        }
    }
}
