using Microsoft.AspNet.Identity.EntityFramework;
using SmartRP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain
{
    public class UserService : IUserService
    {

        #region Fields

        private readonly IWriteEntities _entities;

        #endregion

        #region Ctor

        public UserService(IWriteEntities entities)
        {
            this._entities = entities;
        }

        #endregion

        #region IUserService

        public void CreateStudent(IdentityUser aspNetUser)
        {
            if (aspNetUser == null)
                throw new ArgumentNullException("aspNetUser");

            var now = DateTime.Now;

            var student = new Student(aspNetUser.Id);
            student.CreatedAt = now;
            student.UpdatedAt = now;
            student.Email = aspNetUser.Email;
            this._entities.Create(student);
            this._entities.Save();
        }

        public void CreateSupervisor(IdentityUser aspNetUser)
        {
            if (aspNetUser == null)
                throw new ArgumentNullException("aspNetUser");

            var now = DateTime.Now;

            var supervisor = new Supervisor(aspNetUser.Id);
            supervisor.CreatedAt = now;
            supervisor.UpdatedAt = now;
            supervisor.Email = aspNetUser.Email;
            this._entities.Create(supervisor);
            this._entities.Save();
        }

        public void CreateCoordinator(IdentityUser aspNetUser)
        {
            if (aspNetUser == null)
                throw new ArgumentNullException("aspNetUser");

            var now = DateTime.Now;

            var coordinator = new Coordinator(aspNetUser.Id);
            coordinator.CreatedAt = now;
            coordinator.UpdatedAt = now;
            coordinator.Email = aspNetUser.Email;
            this._entities.Create(coordinator);
            this._entities.Save();
        }


        public User FindUser(int? id)
        {
            return this._entities.Get<User>(u => u.ID == id).Single();
        }

        public List<User> GetAllUser()
        {
            var users = this._entities.Get<User>().ToList();
            return users;
        }
        #endregion

    }
}