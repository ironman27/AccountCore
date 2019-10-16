namespace AccountCore.Contract.Models
{
    public class Employee
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int SalaryPerHour { get; set; }
        public Position Position { get; set; }

        public string ManagerName { get; set; }

    }
}
