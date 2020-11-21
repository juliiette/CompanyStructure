namespace Data.Entity
{
    public class EmployeeEntity : BaseEntity
    {
        public string Name { get; set; }
        
        public string Position { get; set; }
        
        public int Salary { get; set; }
    }
}