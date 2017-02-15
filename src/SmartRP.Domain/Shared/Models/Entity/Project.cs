using System;
using System.Collections.Generic;

namespace SmartRP.Domain
{
    public class Project
    {
        #region Properties

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public ProjectStatus Status { get; set; }
        public ProjectType Type { get; set; }
        public string ApprovedNumber { get; set; }
        public int TeamSize { get; set; }
        public DateTime? ExpiredAt { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int SupervisorId { get; set; }
        public virtual ICollection<Interest> PostedInterests { get; set; }
        public virtual ICollection<Group> RegisteredGroups { get; set; }
        public virtual ICollection<Report> UploadedReports { get; set; }

        #endregion

        #region Ctor

        protected Project()
        {
            // required by EF
            this.PostedInterests = new List<Interest>();
            this.RegisteredGroups = new List<Group>();
            this.UploadedReports = new List<Report>();
        }

        public Project(int supervisorId)
        {
            this.SupervisorId = supervisorId;
        }

        #endregion

        #region Heper

        public enum ProjectStatus
        {
            Available,
            Full,
            Closed
        }

        public enum ProjectType
        {
            Proposed,
            Ready
        }

        #endregion

    }
}