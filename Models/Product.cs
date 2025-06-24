using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperStore2.Models
{
	public class Product
	{
        public Product(int proID, string? proName, double proPrice, int catID)
        {
            ProID = proID;
            ProName = proName;
            ProPrice = proPrice;
            CatID = catID;
        }

        [Key]
		[Required(ErrorMessage = "This Field is Required")]
        [Column(name: "Product ID", TypeName = "nvarchar(255)")]
        public int ProID { get; set; }

		[Required(ErrorMessage = "This Field is Required")]
		public string? ProName { get; set; }

		[Required(ErrorMessage = "This Field is Required")]
		[Range(maximum: 100, minimum: 0, ErrorMessage = "Should be between 0 & 100 ")]
		public double ProPrice { get; set; }

        public int CatID { get; set; }
        [ForeignKey("CatId")]
        public Catagory? catagory { get; set; }

        public ICollection<Shipping>? shipping { get; set; }
        public ICollection<SubCatagory>? subcatagory { get; set; }
    }
}
