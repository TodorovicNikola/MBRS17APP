// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Roba
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Roba
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
		public String Naziv { get; set; }
	         
	    [InverseProperty("Roba")]
	    public ICollection<Robna_kartica> Robne_kartice { get; set; }
	         
	    [InverseProperty("Roba")]
	    public ICollection<Stavka_dokumenta> Stavke_dokumenata { get; set; }
	         
		[ForeignKey("Grupa_roba")]
		[Required]
	    public int Grupa_roba_ID { get; set; }
	    
	    [ForeignKey("Grupa_roba_ID")]
	    [InverseProperty("Roba_koja_joj_pripada")]
	    public Grupa_roba Grupa_roba { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Roba")]
	    public Preduzece Preduzece { get; set; }
	         
		[ForeignKey("Jedinica_mere")]
		[Required]
	    public int Jedinica_mere_ID { get; set; }
	    
	    [ForeignKey("Jedinica_mere_ID")]
	    [InverseProperty("Roba_na_koju_se_odnosi")]
	    public Jedinica_mere Jedinica_mere { get; set; }
	         
	}
}
