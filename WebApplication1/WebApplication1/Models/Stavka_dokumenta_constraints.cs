/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED CONSTRAINTS FOR -- Stavka_dokumenta -- AS A PARTIAL CLASS

TO ADD ADDITIONAL METHODS OR PROPERTIES TO THIS CLASS, CREATE ANOTHER PARTIAL CLASS OF THE SAME NAME!

TEMPLATE - modelConstraints.ftl

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
	public partial class Stavka_dokumenta
	{	
		public bool ValidateOcl()
		{	
			//Constraint :Redni_broj_pozitive -> self.Redni_broj>0	
			if (!(this.Redni_broj>0))
			{
				return false;
			}	
			//Constraint :Kolicina_pozitive -> self.Kolicina>= 0	
			if (!(this.Kolicina>= 0))
			{
				return false;
			}	
			return true;
		}
	}
}
