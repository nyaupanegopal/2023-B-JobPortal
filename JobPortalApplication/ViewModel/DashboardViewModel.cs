namespace JobPortalApplication.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalEmployer { get; set; }
        public int TotalJobPost { get; set; }
        public int MonthlyJobPost { get; set; }
        public List<JobVacancyList> JobVacancyList { get; set; }
    }
    public class JobVacancyList
    {
        public string VacancyNo { get; set; }          // Assuming it's an integer
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }            // e.g., Full-Time, Part-Time
        public DateTime DeadLine { get; set; }      // Assuming it's a DateTime
        public string Location { get; set; }
        public decimal Salary { get; set; }         // Assuming salary is a decimal
        public string Status { get; set; }          // e.g., Open, Closed
    }
}
