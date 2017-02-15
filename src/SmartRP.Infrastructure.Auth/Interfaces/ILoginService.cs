using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Infrastructure.Auth
{
	public interface ILoginService
	{
		Task SignOn();
		Task SignOut();
	}
}