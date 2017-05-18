using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Poslovna_godina
	{  
		[Key]
		public int Id { get; set; }
	         
		public int Godina { get; set; }
	         
		public Boolean Zakljucena { get; set; }		
	         
	    [InverseProperty("Poslovna_godina")]
	    public virtual ICollection<Robna_kartica> Robne_kartice { get; set; }
	         
	    [InverseProperty("Poslovna_godina")]
	    public virtual ICollection<Faktura> Fakture { get; set; }
	         
		[ForeignKey("Preduzece")]
		[Required]
	    public int Preduzece_ID { get; set; }
	    
	    [ForeignKey("Preduzece_ID")]
	    [InverseProperty("Poslovne_godine")]
	    public virtual Preduzece Preduzece { get; set; }
	         
	}
}
