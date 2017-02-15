using System;
using System.Collections.Generic;

namespace SmartRP.Domain
{
    public class Supervisor : User
    {

        #region Properties

        public virtual ICollection<Interest> PostedInterests { get; set; }
        public virtual ICollection<Project> PostedProjects { get; set; }

        public int? TermId { get; set; }

        #endregion

        #region Ctor

        protected Supervisor()
        {
            // required by EF
            this.PostedInterests = new List<Interest>();
            this.PostedProjects = new List<Project>();
        }

        public Supervisor(int? termId)
        {
            this.TermId = termId;
        }
        public Supervisor(string aspNetIdentity) : base(aspNetIdentity)
        {
        }

        #endregion

    }
}