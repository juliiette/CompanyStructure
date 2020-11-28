using System.Collections.Generic;

namespace BLL.Models
{
    public class DirectorModel : EmployeeModel
    {
        public List<ManagerModel> Subordinates { get; set; }
        
        public List<WorkerModel> Workers { get; set; }
    }
}