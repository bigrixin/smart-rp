using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartRP.Domain
{
    public class Interest
    {

        #region Properties

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? StudentId { get; private set; }
        public int? SupervisorId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion

        #region Ctor

        protected Interest()
        {
            // required by EF
        }

        public Interest(int? studentId, int? supervisorId, int? projectId)
        {
            this.StudentId = studentId;
            this.SupervisorId = supervisorId;
            this.ProjectId = projectId;
        }

        #endregion

    }
}