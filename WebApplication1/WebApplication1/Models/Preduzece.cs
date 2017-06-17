// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Preduzece
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Preduzece
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
		public String Maticni_broj { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index(IsUnique=true)]
		public String PIB { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		public String Adresa { get; set; }
	         
	    [InverseProperty("Preduzece")]
	    public ICollection<Roba> Roba { get; set; }
	         
	    [InverseProperty("Preduzece")]
	    public ICollection<Grupa_roba> Grupe_roba { get; set; }
	         
	    [InverseProperty("Preduzece")]
	    public ICollection<Magacin> Magacini { get; set; }
	         
	    [InverseProperty("Preduzece")]
	    public ICollection<Poslovna_godina> Poslovne_godine { get; set; }
	         
		[ForeignKey("Mesto")]
		[Required]
	    public int Mesto_ID { get; set; }
	    
	    [ForeignKey("Mesto_ID")]
	    [InverseProperty("Preduzeca_iz_mesta")]
	    public Mesto Mesto { get; set; }
	         
	}
}
