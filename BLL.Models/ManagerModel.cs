using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.Models
{
    [DataContract]
    public class ManagerModel : EmployeeModel
    {
        [DataMember]
        public DirectorModel Supervisor { get; set; }
        
        [DataMember]
        public string ManagerType { get; set; }
        
        [DataMember]
        public List<WorkerModel> Subordinates { get; set; }
    }
}