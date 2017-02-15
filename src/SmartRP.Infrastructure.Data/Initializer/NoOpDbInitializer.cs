using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Infrastructure.Data
{
	public class NoOpDbInitializer : IDatabaseInitializer<SmartRPDbContext>
	{

		public void InitializeDatabase(SmartRPDbContext db)
		{
			// do nothing, assume db already exists
		}

	}
}