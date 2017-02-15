using Microsoft.AspNet.Identity;
using System;
namespace SmartRP.Domain
{
    public abstract class User
    {

        #region Properties

        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string AspNetIdentityId { get; private set; }

        #endregion

        #region Ctor

        protected User()
        {
            // required by EF
        }

        public User(string aspNetIdentityId)
        {
            this.AspNetIdentityId = aspNetIdentityId;
        }

        #endregion

    }
}