using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BakeryManagement.Domain.Common.Constants;
using BakeryManagement.Domain.Common.Entities;

namespace BakeryManagement.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = EnumStatus.ACTIVE.ToString();

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int BreadId { get; set; }
        public Bread Bread { get; set; }

        [NotMapped]
        public EnumStatus EnumStatus
        {
            get => Enum.TryParse(Status, out EnumStatus status) ? status : EnumStatus.ACTIVE;
            set => Status = value.ToString();
        }

        public OrderItem(int orderId, int breadId, int quantity)
        {
            OrderId = orderId;
            BreadId = breadId;
            Quantity = quantity;
            Status = EnumStatus.ACTIVE.ToString();
        }

        public OrderItem() { }
    }
}
