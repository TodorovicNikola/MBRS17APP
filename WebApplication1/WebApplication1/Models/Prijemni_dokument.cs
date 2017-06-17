/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Prijemni_dokument -- AS A PARTIAL CLASS

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
	public partial class Prijemni_dokument
	{  
	
		public int Redni_broj { get; set; }
	         
		[Key]
		public int Id { get; set; }
	         
		[Required]
		public DateTime Datum_formiranja { get; set; }
	         
		public DateTime Datum_knjizenja { get; set; }
	         
		public StatusPrijemnogDokumenta Status { get; set; }
	         
		public double Ukupna_vrednost { get; set; }
	         
		[Required]
		public double Transportni_troskovi { get; set; }
	         
		[Required]
		public double Zavisni_troskovi { get; set; }
	         
		[ForeignKey("Stavka_dokumenta")]
	    public int Stavka_dokumenta_ID { get; set; }
	    
	    [ForeignKey("Stavka_dokumenta_ID")]
	    [InverseProperty("Prijemni_dokument")]
	    public Stavka_dokumenta Stavka_dokumenta { get; set; }
	         
		[ForeignKey("Pripada_magacinu")]
		[Required]
	    public int Pripada_magacinu_ID { get; set; }
	    
	    [ForeignKey("Pripada_magacinu_ID")]
	    [InverseProperty("Prijemni_dokumenti_magacina")]
	    public Magacin Pripada_magacinu { get; set; }
	         
		[ForeignKey("Magacin_u_dokumentu")]
	    public int Magacin_u_dokumentu_ID { get; set; }
	    
	    [ForeignKey("Magacin_u_dokumentu_ID")]
	    [InverseProperty("Dokumenti_u_kojima_se_pominje")]
	    public Magacin Magacin_u_dokumentu { get; set; }
	         
		[ForeignKey("Poslovni_partner")]
	    public int Poslovni_partner_ID { get; set; }
	    
	    [ForeignKey("Poslovni_partner_ID")]
	    [InverseProperty("Dokumenti_u_kojima_se_pominje")]
	    public Poslovni_partner Poslovni_partner { get; set; }
	         
	
		public void Stampaj()
		{
			// USER CODE STARTS HERE

			return;
			// USER CODE ENDS HERE
		}
	}
}
