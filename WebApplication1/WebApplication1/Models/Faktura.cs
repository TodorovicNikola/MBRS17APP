/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Faktura -- AS A PARTIAL CLASS

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
	public partial class Faktura
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Required]
		[Index(IsUnique=true)]
		public int Broj_fakture { get; set; }
	         
		[Required]
		public DateTime Datum_fakture { get; set; }
	         
		[Required]
		public DateTime Datum_valute { get; set; }
	         
		public double Ukupan_rabat { get; set; }
	         
		public double Ukupan_iznos_bez_PDV_a { get; set; }
	         
		[Required]
		public double Ukupan_PDV { get; set; }
	         
		[Required]
		public double Ukupno_za_placanje { get; set; }
	         
		[ForeignKey("Poslovna_godina")]
		[Required]
	    public int Poslovna_godina_ID { get; set; }
	    
	    [ForeignKey("Poslovna_godina_ID")]
	    [InverseProperty("Fakture")]
	    public Poslovna_godina Poslovna_godina { get; set; }
	         
		[ForeignKey("Poslovni_partner")]
		[Required]
	    public int Poslovni_partner_ID { get; set; }
	    
	    [ForeignKey("Poslovni_partner_ID")]
	    [InverseProperty("Fakture")]
	    public Poslovni_partner Poslovni_partner { get; set; }
	         
		[Timestamp]
    	public byte[] RowVersion { get; set; }
	
		public void Generisi_izvestaj(String jezik)
		{
			// USER CODE STARTS HERE

			return;
			// USER CODE ENDS HERE
		}
		public void Proknjizi()
		{
			// USER CODE STARTS HERE

			return;
			// USER CODE ENDS HERE
		}
	}
}
