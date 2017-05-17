using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Poslovni_partner
	{  
			[Key]
			public int Id { get; set; }
			[Required]
			public TipPoslovnogPartnera Tip { get; set; }
			public String Naziv { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
			[Index(IsUnique=true)]
			public String PIB { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
			[Index(IsUnique=true)]
			public String Maticni_broj { get; set; }
			public String Adresa { get; set; }
		    public ICollection<Prijemni_dokument> Prijemni_dokument { get; set; }
		    public ICollection<Faktura> Faktura { get; set; }
			[ForeignKey("Mesto")]
			[Required]
		    public int Mesto_ID { get; set; }
		    
		    [ForeignKey("Mesto_ID")]
		    public virtual Mesto Mesto { get; set; }
	}
}
