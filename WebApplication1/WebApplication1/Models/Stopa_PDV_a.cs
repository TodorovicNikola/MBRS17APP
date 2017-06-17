/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Stopa_PDV_a -- AS A PARTIAL CLASS

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
	public partial class Stopa_PDV_a
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Required]
		public double Stopa { get; set; }
	         
		[Required]
		public DateTime Datum_vazenja { get; set; }
	         
		[ForeignKey("PDV")]
		[Required]
	    public int PDV_ID { get; set; }
	    
	    [ForeignKey("PDV_ID")]
	    [InverseProperty("Stope_PDV_a")]
	    public PDV PDV { get; set; }
	         
	
	}
}
