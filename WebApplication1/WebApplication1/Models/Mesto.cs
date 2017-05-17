using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Mesto
	{  
			[Key]
			public int Id { get; set; }
			public String Naziv { get; set; }
			public String Postanski_broj { get; set; }
		    public ICollection<Magacin> Magacin { get; set; }
		    public ICollection<Poslovni_partner> Poslovni_partner { get; set; }
		    public ICollection<Preduzece> Preduzece { get; set; }
	}
}
