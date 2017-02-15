using System;
using System.Collections.Generic;

namespace SmartRP.Domain
{
    public class Coordinator : User
    {

        #region Properties

        public virtual ICollection<Term> OpenedTerms { get; set; }

        #endregion

        #region Ctor

        protected Coordinator()
        {
            // required by EF
            this.OpenedTerms = new List<Term>();
        }

        public Coordinator(string aspNetIdentity) : base(aspNetIdentity)
        {

        }

        #endregion

        #region Helper

        #endregion


    }
}