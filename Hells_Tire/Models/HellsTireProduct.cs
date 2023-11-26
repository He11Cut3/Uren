using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Hells_Tire.Models
{
	public class HellsTireProduct
	{
		public long HellsTireProductID { get; set; }

		public string HellsTireProductName { get; set; }

		public string HellsTireProductBrand { get; set; }

		public string HellsTireProductDescriptions { get; set; }

		public decimal HellsTireProductPrice { get; set; }

		public string HellsTireProductSlug { get; set; }

		public long HellsTireCategoryID { get; set; }

		public HellsTireCategory HellsTireCategory { get; set; }

		public byte[] HellsTireProductImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
