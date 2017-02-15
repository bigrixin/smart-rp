using SmartRP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Infrastructure.Data
{
	public class CreateFromScratchDbInitializer : CreateDatabaseIfNotExists<SmartRPDbContext>
	{

		protected override void Seed(SmartRPDbContext context)
		{
			var now = DateTime.Now;

			var steve = new Student(Guid.NewGuid().ToString());
			steve.FirstName = "Steven";
			steve.LastName = "Zhai";
			steve.CreatedAt = now;
			steve.UpdatedAt = now;

			var tommy = new Student(Guid.NewGuid().ToString());
			tommy.FirstName = "Tommy";
			tommy.LastName = "Lee";
			tommy.CreatedAt = now;
			tommy.UpdatedAt = now;

			var heri = new Student(Guid.NewGuid().ToString());
			heri.FirstName = "Herianto";
			heri.LastName = "Ramli";
			heri.CreatedAt = now;
			heri.UpdatedAt = now;

			var cruise = new Student(Guid.NewGuid().ToString());
			cruise.FirstName = "Tom";
			cruise.LastName = "Cruise";
			cruise.CreatedAt = now;
			cruise.UpdatedAt = now;

			var clients = new List<Student> { steve, tommy, heri, cruise };
			clients.ForEach(m => context.Users.Add(m));

			context.SaveChanges();
		}

	}
}
