using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Stopa_PDV_a
	{  
			[Key]
			public int Id { get; set; }
			public double Stopa { get; set; }
			[Required]
			public DateTime Datum_vazenja { get; set; }
			[ForeignKey("PDV")]
			[Required]
		    public int PDV_ID { get; set; }
		    
		    [ForeignKey("PDV_ID")]
		    public virtual PDV PDV { get; set; }
	}
}
