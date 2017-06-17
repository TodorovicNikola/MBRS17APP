/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED MODEL FOR -- Poslovni_partner -- AS A PARTIAL CLASS

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
	public partial class Poslovni_partner
	{  
	
		[Key]
		public int Id { get; set; }
	         
		[Required]
		public TipPoslovnogPartnera Tip { get; set; }
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		[Required]
		[Index]	 	
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
	         
		[Column(TypeName = "VARCHAR")]
		[StringLength(128)]
		public String Adresa { get; set; }
	         
	    [InverseProperty("Poslovni_partner")]
	    public ICollection<Prijemni_dokument> Dokumenti_u_kojima_se_pominje { get; set; }
	         
	    [InverseProperty("Poslovni_partner")]
	    public ICollection<Faktura> Fakture { get; set; }
	         
		[ForeignKey("Iz_mesta")]
		[Required]
	    public int Iz_mesta_ID { get; set; }
	    
	    [ForeignKey("Iz_mesta_ID")]
	    [InverseProperty("Poslovni_partneri_iz_mesta")]
	    public Mesto Iz_mesta { get; set; }
	         
	
	}
}
