using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain
{
	public class MyAccountModule : Autofac.Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// register UserService
			builder
				.RegisterType<UserService>()
				.As<IUserService>();
		}
	}
}