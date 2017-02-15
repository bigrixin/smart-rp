using System;
using System.Collections.Generic;

namespace SmartRP.Domain
{
    public class Student : User
    {

        #region Properties

        public virtual ICollection<Interest> PostedInterests { get; set; }

        public string Degree { get; set; }
        public Subject SubjectName { get; set; }
        public float? GPA { get; set; }

        public bool Leader { get; set; }
        public int? TermId { get; set; }
        public int? GroupId { get; set; }

        #endregion

        #region Ctor

        protected Student()
        {
            // required by EF
            this.PostedInterests = new List<Interest>();
        }

        public Student(int? termId, int? groupId)
        {
            this.TermId = termId;
            this.GroupId = groupId;
        }

        public Student(string aspNetIdentity) : base(aspNetIdentity)
        {
            // this.PostedInterests = new List<Interest>();
        }

        #endregion

        #region Helper
        public enum Subject
        {
            TRP, RP
        }

        #endregion


    }
}