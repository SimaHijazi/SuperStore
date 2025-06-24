using SoperStore2;
using System.ComponentModel.DataAnnotations;

namespace SuperStore2.Models
{
    public class Catagory
	{
        public Catagory(int catID, string? catName)
        {
            CatID = catID;
            CatName = catName;
        }

        [Key]
		[Required]
		public int CatID { get; set; }

		[Required]
		[MaxLength(100)]
		public string? CatName { get; set; }

        public EnumCat EnumCat { get; set; }

        public ICollection<SubCatagory>? subcatagory { get; set; }

    }
}
