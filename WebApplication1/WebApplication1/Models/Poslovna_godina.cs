/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Poslovna_godina -- AS A PARTIAL CLASS

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
	public partial class Poslovna_godina
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Required]
		[Index(IsUnique=true)]
		public int Godina { get; set; }
	         
		public Boolean Zakljucena { get; set; }		
	         
	    [InverseProperty("Poslovna_godina")]
	    public ICollection<Robna_kartica> Robne_kartice { get; set; }
	         
	    [InverseProperty("Poslovna_godina")]
	    public ICollection<Faktura> Fakture { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Poslovne_godine")]
	    public Preduzece Preduzece { get; set; }
	         
	
	}
}
