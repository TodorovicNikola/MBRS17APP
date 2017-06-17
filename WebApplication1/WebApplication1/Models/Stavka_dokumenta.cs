// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Stavka_dokumenta
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Stavka_dokumenta
	{  
		//Constraint :Redni_broj_pozitive -> self.Redni_broj>0
		
		//Constraint :Kolicina_pozitive -> self.Kolicina>0
		
	
		[Key]
		public int Id { get; set; }
	         
		[Required]
		public int Redni_broj { get; set; }
	         
		[Required]
		public double Kolicina { get; set; }
	         
		[Required]
		public double Nabavna_cena_po_jedinici { get; set; }
	         
		public double Nabavna_vrednost { get; set; }
	         
		[Required]
		public double Procenat_marze { get; set; }
	         
		public double Transportni_trosak { get; set; }
	         
		public double Zavisni_trosak { get; set; }
	         
		public double Kalkulisana_cena { get; set; }
	         
		public double Ukupna_vrednost { get; set; }
	         
	    [InverseProperty("Stavka_dokumenta")]
	    public ICollection<Prijemni_dokument> Prijemni_dokument { get; set; }
	         
		[ForeignKey("Roba")]
		[Required]
	    public int Roba_ID { get; set; }
	    
	    [ForeignKey("Roba_ID")]
	    [InverseProperty("Stavke_dokumenata")]
	    public Roba Roba { get; set; }
	         
	}
}
