using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Magacin
	{  
			[Key]
			public int Id { get; set; }
			public String Naziv { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        [Index]
        public string Adresa { get; set; }

            [InverseProperty("MagacinUDokumentu")]
		    public ICollection<Prijemni_dokument> MagacinUPrijemnimDokumentima { get; set; }

        [InverseProperty("MagacinKomPripada")]
        public ICollection<Prijemni_dokument> PripadajuciPrijemniDokumenti { get; set; }
		    public ICollection<Robna_kartica> Robna_kartica { get; set; }
			[ForeignKey("Preduzece")]
			[Required]
		    public int Preduzece_ID { get; set; }
		    
		    [ForeignKey("Preduzece_ID")]
		    public virtual Preduzece Preduzece { get; set; }
			[ForeignKey("Mesto")]
			[Required]
		    public int Mesto_ID { get; set; }
		    
		    [ForeignKey("Mesto_ID")]
		    public virtual Mesto Mesto { get; set; }
	}
}
