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
		    public ICollection<Robna_kartica> Robna_kartica { get; set; }
		    public ICollection<Faktura> Faktura { get; set; }
			[ForeignKey("Preduzece")]
			[Required]
		    public int Preduzece_ID { get; set; }
		    
		    [ForeignKey("Preduzece_ID")]
		    public virtual Preduzece Preduzece { get; set; }
	}
}
