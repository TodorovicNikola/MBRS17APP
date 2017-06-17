/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Jedinica_mere -- AS A PARTIAL CLASS

TO ADD ADDITIONAL METHODS OR PROPERTIES TO THIS CLASS, CREATE ANOTHER PARTIAL CLASS OF THE SAME NAME!

TEMPLATE - model.ftl

*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public partial class Jedinica_mere
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
		public String Naziv { get; set; }
	         
	    [InverseProperty("Jedinica_mere")]
	    public ICollection<Roba> Roba_na_koju_se_odnosi { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index(IsUnique=true)]
		public String Oznaka { get; set; }
	         
	
	}
}
