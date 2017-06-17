// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Jedinica_mere
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Jedinica_mere
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
