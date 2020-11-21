using System.Collections.Generic;

namespace BLL.Models
{
    public class ManagerModel : EmployeeModel
    {
        public DirectorModel Supervisor { get; set; }
        
        public string ManagerType { get; set; }
        
        public List<EmployeeModel> Subordinates { get; set; }
    }
}