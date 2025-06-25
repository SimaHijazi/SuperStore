using SoperStore2;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore2.Models
{
    public class Shipping
    {
        [Key]
        [DataType(DataType.DateTime)]
        public DateTime ShipDate { get; set; }

        [Column(name: "ShipMode", TypeName = "nvarchar(255)")]
        public string? ShipMode { get; set; }

        public EnumShip EnumShip { get; set; }

        public DateTime OrderDate { get; set; }
        [ForeignKey("OrderDate")]
        public Order? order { get; set; }

        public int ProID { get; set; }
        [ForeignKey("ProID")]
        public Product? product { get; set; }
    }
}
