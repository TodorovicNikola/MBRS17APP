using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Prijemni_dokument
	{  
		[Key]
		public int Id { get; set; }
	         
		public int Redni_broj { get; set; }
	         
		[Required]
		public DateTime Datum_formiranja { get; set; }
	         
		public DateTime Datum_knjizenja { get; set; }
	         
		public StatusPrijemnogDokumenta Status { get; set; }
	         
		public double Ukupna_vrednost { get; set; }
	         
		[Required]
		public double Transportni_troskovi { get; set; }
	         
		[Required]
		public double Zavisni_troskovi { get; set; }
	         
	    public virtual ICollection<Stavka_dokumenta> Stavke_dokumenta { get; set; }
	         
		[ForeignKey("Pripada_magacinu")]
		[Required]
	    public int Pripada_magacinu_ID { get; set; }
	    
	    [ForeignKey("Pripada_magacinu_ID")]
	    [InverseProperty("Prijemni_dokumenti_magacina")]
	    public virtual Magacin Pripada_magacinu { get; set; }
	         
		[ForeignKey("Magacin_u_dokumentu")]
	    public int Magacin_u_dokumentu_ID { get; set; }
	    
	    [ForeignKey("Magacin_u_dokumentu_ID")]
	    [InverseProperty("Dokumenti_u_kojima_se_pominje")]
	    public virtual Magacin Magacin_u_dokumentu { get; set; }
	         
		[ForeignKey("Poslovni_partner")]
	    public int Poslovni_partner_ID { get; set; }
	    
	    [ForeignKey("Poslovni_partner_ID")]
	    [InverseProperty("Dokumenti_u_kojima_se_pominje")]
	    public virtual Poslovni_partner Poslovni_partner { get; set; }
	         
	}
}
