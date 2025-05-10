using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class BakeryOffice : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }

        public IEnumerable<Menu> Menu { get; set; } = new List<Menu>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
