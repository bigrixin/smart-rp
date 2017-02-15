namespace SmartRP.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReportURL { get; set; }
        public int ProjectId { get; set; }

        public Report(int projectId)
        {
            this.ProjectId = projectId;
        }

    }
}