using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = "g";

        public int BreadId { get; set; }
        public required Bread Bread { get; set; }
    }
}
