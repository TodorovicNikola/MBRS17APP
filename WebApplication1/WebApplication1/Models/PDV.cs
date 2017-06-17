// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR PDV
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class PDV
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
		public String Naziv_PDV_a { get; set; }
	         
	    [InverseProperty("PDV")]
	    public ICollection<Grupa_roba> Grupe_roba { get; set; }
	         
	    [InverseProperty("PDV")]
	    public ICollection<Stopa_PDV_a> Stope_PDV_a { get; set; }
	         
	}
}
