
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore2.Models
{
	public class Order
	{
        
        [Column(name: "OrderId", TypeName = "nvarchar(255)")]
        public int OrderId { get; set; }

        [Key]
        [DataType(DataType.DateTime)]
		public DateTime OrderDate { get; set; }

        public ICollection<Shipping>? shipping { get; set; }


    }
}
