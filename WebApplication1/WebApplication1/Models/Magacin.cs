/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Magacin -- AS A PARTIAL CLASS

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
	public partial class Magacin
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
		[Index]	 	
		public String Adresa { get; set; }
	         
	    [InverseProperty("Pripada_magacinu")]
	    public ICollection<Prijemni_dokument> Prijemni_dokumenti_magacina { get; set; }
	         
	    [InverseProperty("Magacin_u_dokumentu")]
	    public ICollection<Prijemni_dokument> Dokumenti_u_kojima_se_pominje { get; set; }
	         
	    [InverseProperty("Magacin")]
	    public ICollection<Robna_kartica> Robne_kartice { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Magacini")]
	    public Preduzece Preduzece { get; set; }
	         
		[ForeignKey("Mesto")]
		[Required]
	    public int Mesto_ID { get; set; }
	    
	    [ForeignKey("Mesto_ID")]
	    [InverseProperty("Magacini_iz_mesta")]
	    public Mesto Mesto { get; set; }
	         
	
	}
}
