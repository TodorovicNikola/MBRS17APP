// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Mesto
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Mesto
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
		public String Naziv { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index(IsUnique=true)]
		public String Postanski_broj { get; set; }
	         
	    [InverseProperty("Mesto")]
	    public ICollection<Magacin> Magacini_iz_mesta { get; set; }
	         
	    [InverseProperty("Iz_mesta")]
	    public ICollection<Poslovni_partner> Poslovni_partneri_iz_mesta { get; set; }
	         
	    [InverseProperty("Mesto")]
	    public ICollection<Preduzece> Preduzeca_iz_mesta { get; set; }
	         
	}
}
