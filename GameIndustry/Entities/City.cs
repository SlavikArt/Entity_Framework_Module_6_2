using System.ComponentModel.DataAnnotations;

namespace GameIndustry.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Studio> Studios { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}