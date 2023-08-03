namespace Entities
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Employee_name { get; set; }
        public int Employee_salary { get; set; }
        public int Employee_age { get; set; }
        public int Employee_anual_salary { get; set; } = 0;
        public string? Profile_image { get; set; }
    }
}