using Autofac;
using SmartRP.Domain.StudentFunctions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain
{
	public class StudentFunctionsModule : Autofac.Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// register StudentService
			builder
				.RegisterType<StudentService>()
				.As<IStudentService>();
		}
	}
}