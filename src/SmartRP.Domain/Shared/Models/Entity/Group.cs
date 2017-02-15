using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartRP.Domain
{
    public class Group
    {

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GroupStatus Status { get; set; }
        public int Size { get; set; }

        public int ProjectId { get; private set; }
        public int GroupLeaderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Student> JoinedStudents { get; set; }
        #endregion

        #region Ctor

        protected Group()
        {
            // required by EF   
            this.JoinedStudents = new List<Student>();
        }

        public Group(int projectId, int groupLeaderId)
        {
            this.ProjectId = projectId;
            this.GroupLeaderId = groupLeaderId;

        }

        #endregion

        #region Helper
        public enum GroupStatus
        {
            Avaliable,
            Full,
            Closed
        }

        #endregion

    }
}