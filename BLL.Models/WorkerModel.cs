namespace BLL.Models
{
    public class WorkerModel : EmployeeModel
    {
        public ManagerModel Supervisor { get; set; }
        
        public string WorkerType { get; set; }
    }
}