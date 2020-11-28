using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.Models
{
    [DataContract]
    public class ManagerModel : EmployeeModel
    {
        [DataMember]
        public string Supervisor { get; set; }

        [DataMember]
        public List<WorkerModel> WorkerSubordinates { get; set; }
        
    }
}