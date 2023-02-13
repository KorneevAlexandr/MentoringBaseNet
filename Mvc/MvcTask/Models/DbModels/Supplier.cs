using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTask.Models.DbModels
{
	[Table("Suppliers")]
	public class Supplier
	{
		[Key]
		public int SupplierId { get; set; }

		public string CompanyName { get; set; }
	}
}
