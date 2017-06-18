/*

######## DO NOT CHANGE THIS CODE! ########
AUTOMATICALLY GENERATED CONSTRAINTS FOR -- Mesto -- AS A PARTIAL CLASS

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
	public partial class Mesto
	{	
		public bool ValidateOcl()
		{	
			//Constraint :Naziv_mora_poceti_velikim_slovom -> self.Naziv.at(0) = self.Naziv.toUpper().at(0)	
			if (!(this.Naziv.ElementAt(0) == this.Naziv.ToUpper().ElementAt(0)))
			{
				return false;
			}	
			//Constraint :Naziv_mora_imati_bar_2_slova -> self.Naziv.size()>1	
			if (!(this.Naziv.Length>1))
			{
				return false;
			}	
			return true;
		}
	}
}
