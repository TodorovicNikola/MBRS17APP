using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Preduzece
	{  
			[Key]
			public int Id { get; set; }
			public String Naziv { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
			[Index(IsUnique=true)]
			public String Maticni_broj { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Required]
			[Index(IsUnique=true)]
			public String PIB { get; set; }
			public String Adresa { get; set; }
		    public virtual ICollection<Roba> Roba { get; set; }
		    public virtual ICollection<Grupa_roba> Grupa_roba { get; set; }
		    public virtual ICollection<Magacin> Magacin { get; set; }
		    public virtual ICollection<Poslovna_godina> Poslovna_godina { get; set; }
			[ForeignKey("Mesto")]
			[Required]
		    public int Mesto_ID { get; set; }
		    
		    [ForeignKey("Mesto_ID")]
		    public virtual Mesto Mesto { get; set; }
	}
}
