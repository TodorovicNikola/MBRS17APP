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
			public String Naziv { get; set; }
		    public ICollection<Robna_kartica> Robna_kartica { get; set; }
		    public ICollection<Stavka_dokumenta> Stavka_dokumenta { get; set; }
			[ForeignKey("Grupa_roba")]
			[Required]
		    public int Grupa_roba_ID { get; set; }
		    
		    [ForeignKey("Grupa_roba_ID")]
		    public virtual Grupa_roba Grupa_roba { get; set; }
			[ForeignKey("Preduzece")]
			[Required]
		    public int Preduzece_ID { get; set; }
		    
		    [ForeignKey("Preduzece_ID")]
		    public virtual Preduzece Preduzece { get; set; }
			[ForeignKey("Jedinica_mere")]
			[Required]
		    public int Jedinica_mere_ID { get; set; }
		    
		    [ForeignKey("Jedinica_mere_ID")]
		    public virtual Jedinica_mere Jedinica_mere { get; set; }
	}
}
