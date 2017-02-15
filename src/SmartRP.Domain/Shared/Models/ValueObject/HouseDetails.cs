using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain
{
	public class HouseDetails
	{
		public bool HasAdequateAccess { get; set; }
		public bool HasSmokersLivingIn { get; set; }
		public bool HasStreetParking { get; set; }
		public string Equipments { get; set; }
		public string SpecialInstructions { get; set; }
		public bool PremiseSafetyStatementAcknowledged { get; set; }
	}
}