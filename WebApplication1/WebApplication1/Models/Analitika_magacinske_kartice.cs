using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Analitika_magacinske_kartice
	{  
		[Key]
		public int Id { get; set; }
	         
		public int Redni_broj { get; set; }
	         
		public VrstaPrometa Vrsta_prometa { get; set; }
	         
		public Smer Smer_prometa { get; set; }
	         
		public double Kolicina { get; set; }
	         
		public double Cena { get; set; }
	         
		public double Vrednost { get; set; }
	         
		[ForeignKey("Robna_kartica")]
		[Required]
	    public int Robna_kartica_ID { get; set; }
	    
	    [ForeignKey("Robna_kartica_ID")]
	    [InverseProperty("Analiticke_kartice")]
	    public virtual Robna_kartica Robna_kartica { get; set; }
	         
	}
}
