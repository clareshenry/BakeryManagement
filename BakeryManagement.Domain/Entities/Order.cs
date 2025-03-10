using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Constants;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Status { get; set; } = EnumStatus.ACTIVE.ToString();

        public int BakeryOfficeId { get; set; }
        public BakeryOffice BakeryOffice { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [NotMapped]
        public EnumStatus EnumStatus
        {
            get => Enum.TryParse(Status, out EnumStatus status) ? status : EnumStatus.ACTIVE;
            set => Status = value.ToString();
        }

        public Order(int bakeryOfficeId)
        {
            BakeryOfficeId = bakeryOfficeId;
            Status = EnumStatus.ACTIVE.ToString();
        }

        public Order() { }
    }
}
