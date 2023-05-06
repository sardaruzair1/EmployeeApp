namespace EmployeeApp.Models
{
    public class EmployeeUpdate
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public long Salary { get; set; }
    }
}
