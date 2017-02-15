using System;
using System.Collections.Generic;

namespace SmartRP.Domain
{
    public class Term
    {
        #region Properties

        public int Id { get; set; }
        public string TermName { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public virtual ICollection<Student> RegisteredStudents { get; set; }
        public virtual ICollection<Supervisor> RegisteredSupervisors { get; set; }
        public int CoordinatorId { get; set; }

        #endregion

        #region Ctor

        protected Term()
        {
            // required by EF
        }

        public Term(int coordinatorId)
        {
            this.CoordinatorId = coordinatorId;
        }

        #endregion

    }
}