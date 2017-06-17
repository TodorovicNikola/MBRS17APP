// DO NOT CHANGE THIS CODE
// TEMPLATE model.ftl
// AUTOMATICALLY GENERATED MODEL FOR Poslovna_godina
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
