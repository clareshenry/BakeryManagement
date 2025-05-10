using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class Menu : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BreadId { get; set; }
        public required Bread Bread { get; set; }

        public int BakeryOfficeId { get; set; }
        public required BakeryOffice BakeryOffice { get; set; }
    }
}
