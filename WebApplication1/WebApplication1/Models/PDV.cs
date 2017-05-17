using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class PDV
	{  
			[Key]
			public int Id { get; set; }
			public String Naziv_PDV_a { get; set; }
		    public ICollection<Grupa_roba> Grupa_roba { get; set; }
		    public ICollection<Stopa_PDV_a> Stopa_PDV_a { get; set; }
	}
}
