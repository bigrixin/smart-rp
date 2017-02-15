using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain
{
    public interface IUserService
    {
        void CreateStudent(IdentityUser aspNetUser);
        void CreateSupervisor(IdentityUser aspNetUser);
        void CreateCoordinator(IdentityUser aspNetUser);
        User FindUser(int? id);
        List<User> GetAllUser();
    }
}