using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Infrastructure.Data
{
	public class EntityFrameworkModule : Autofac.Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			bool shouldRecreateDb;
#if DEBUG
			bool.TryParse(ConfigurationManager.AppSettings["recreateDb"], out shouldRecreateDb);
#else
			shouldRecreateDb = false;
#endif

			// register initializer
			if (shouldRecreateDb)
				builder.RegisterType<CreateFromScratchDbInitializer>().As<IDatabaseInitializer<SmartRPDbContext>>();

			// register database context
			builder
				.RegisterType<SmartRPDbContext>()
				.As<IReadEntities>()
				.As<IWriteEntities>()
				.InstancePerLifetimeScope();
		}
	}
}