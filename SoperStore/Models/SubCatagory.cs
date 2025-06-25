using SoperStore2;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore2.Models
{
    public class SubCatagory
    {
        public SubCatagory(int catId, string? subName, int proName)
        {
            CatId = catId;
            SubName = subName;
            ProName = proName;
        }

        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public Catagory? catagory { get; set; }

        [Column(name: "SubCatagoryName", TypeName = "nvarchar(255)")]
        public String? SubName { get; set; }

        public int ProName { get; set; }
        [ForeignKey("ProName")]
        public Product? product { get; set; }

        public EnumSubCat EnumSubCat { get; set; }

    }
}
