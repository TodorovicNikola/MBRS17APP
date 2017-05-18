using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Magacin
	{  
		[Key]
		public int Id { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		public String Naziv { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Index]	 	
		public String Adresa { get; set; }
	         
	    [InverseProperty("Pripada_magacinu")]
	    public virtual ICollection<Prijemni_dokument> Prijemni_dokumenti_magacina { get; set; }
	         
	    [InverseProperty("Magacin_u_dokumentu")]
	    public virtual ICollection<Prijemni_dokument> Dokumenti_u_kojima_se_pominje { get; set; }
	         
	    [InverseProperty("Magacin")]
	    public virtual ICollection<Robna_kartica> Robne_kartice { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Magacini")]
	    public virtual Preduzece Preduzece { get; set; }
	         
		[ForeignKey("Mesto")]
		[Required]
	    public int Mesto_ID { get; set; }
	    
	    [ForeignKey("Mesto_ID")]
	    [InverseProperty("Magacini_iz_mesta")]
	    public virtual Mesto Mesto { get; set; }
	         
	}
}
