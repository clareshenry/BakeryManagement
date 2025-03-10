using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class Bread : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public TimeSpan CookingTime { get; set; }
        public TimeSpan RestingTime { get; set; }
        public TimeSpan FermentTime { get; set; }
        public double Temperature { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
