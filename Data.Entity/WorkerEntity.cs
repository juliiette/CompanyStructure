namespace Data.Entity
{
    public class WorkerEntity : EmployeeEntity
    {
        public ManagerEntity Supervisor { get; set; }
        
        public string WorkerType { get; set; }
    }
}