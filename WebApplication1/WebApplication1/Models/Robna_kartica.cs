/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Robna_kartica -- AS A PARTIAL CLASS

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
	public partial class Robna_kartica
	{
		[Key]
		public int Id { get; set; }
	         
		public double Prosecna_cena { get; set; }
	         
		public double Poc__stanje_kol_ { get; set; }
	         
		public double Poc__stanje_vr_ { get; set; }
	         
		public double Promet_ulaza_kol_ { get; set; }
	         
		public double Promet_ulaza_vr_ { get; set; }
	         
		public double Promet_izlaza_kol_ { get; set; }
	         
		public double Promet_izlaza_vr_ { get; set; }
	         
		public double Ukupna_kolicina { get; set; }
	         
		public double Ukupna_vrednost { get; set; }
	         
	    [InverseProperty("Robna_kartica")]
	    public ICollection<Analitika_magacinske_kartice> Analiticke_kartice { get; set; }
	         
		[ForeignKey("Roba")]
		[Required]
	    public int Roba_ID { get; set; }
	    
	    [ForeignKey("Roba_ID")]
	    [InverseProperty("Robne_kartice")]
	    public Roba Roba { get; set; }
	         
		[ForeignKey("Magacin")]
		[Required]
	    public int Magacin_ID { get; set; }
	    
	    [ForeignKey("Magacin_ID")]
	    [InverseProperty("Robne_kartice")]
	    public Magacin Magacin { get; set; }
	         
		[ForeignKey("Poslovna_godina")]
		[Required]
	    public int Poslovna_godina_ID { get; set; }
	    
	    [ForeignKey("Poslovna_godina_ID")]
	    [InverseProperty("Robne_kartice")]
	    public Poslovna_godina Poslovna_godina { get; set; }
	         
		[Timestamp]
    	public byte[] RowVersion { get; set; }
	
		public String Generisi_statistiku(DateTime od_kad, DateTime do_kad)
		{
			// USER CODE STARTS HERE

			return null;
			// USER CODE ENDS HERE
		}
	}
}
