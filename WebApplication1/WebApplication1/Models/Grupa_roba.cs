// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Grupa_roba
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Grupa_roba
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
		public String Naziv { get; set; }
	         
	    [InverseProperty("Grupa_roba")]
	    public ICollection<Roba> Roba_koja_joj_pripada { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Grupe_roba")]
	    public Preduzece Preduzece { get; set; }
	         
		[ForeignKey("PDV")]
		[Required]
	    public int PDV_ID { get; set; }
	    
	    [ForeignKey("PDV_ID")]
	    [InverseProperty("Grupe_roba")]
	    public PDV PDV { get; set; }
	         
	}
}
