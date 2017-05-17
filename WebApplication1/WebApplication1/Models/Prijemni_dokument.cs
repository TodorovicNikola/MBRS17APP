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
			[ForeignKey("Stavka_dokumenta")]
		    public int Stavka_dokumenta_ID { get; set; }
		    
		    [ForeignKey("Stavka_dokumenta_ID")]
		    public virtual Stavka_dokumenta Stavka_dokumenta { get; set; }
			[ForeignKey("MagacinUDokumentu")]
			[Required]
		    public int MagacinUDokumentu_ID { get; set; }
		    
		    [ForeignKey("MagacinUDokumentu_ID")]
		    public virtual Magacin MagacinUDokumentu { get; set; }

			[ForeignKey("MagacinKomPripada")]
		    public int MagacinKomPripada_ID { get; set; }
		    
		    [ForeignKey("MagacinKomPripada_ID")]
		    public virtual Magacin MagacinKomPripada { get; set; }
			[ForeignKey("Poslovni_partner")]
		    public int Poslovni_partner_ID { get; set; }
		    
		    [ForeignKey("Poslovni_partner_ID")]
		    public virtual Poslovni_partner Poslovni_partner { get; set; }
	}
}
