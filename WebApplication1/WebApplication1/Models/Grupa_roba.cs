using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Grupa_roba
	{  
			[Key]
			public int Id { get; set; }
			public String Naziv { get; set; }
		    public ICollection<Roba> Roba { get; set; }
			[ForeignKey("Preduzece")]
			[Required]
		    public int Preduzece_ID { get; set; }
		    
		    [ForeignKey("Preduzece_ID")]
		    public virtual Preduzece Preduzece { get; set; }
			[ForeignKey("PDV")]
			[Required]
		    public int PDV_ID { get; set; }
		    
		    [ForeignKey("PDV_ID")]
		    public virtual PDV PDV { get; set; }
	}
}
