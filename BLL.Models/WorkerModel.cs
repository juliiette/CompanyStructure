using System.Runtime.Serialization;

namespace BLL.Models
{
    [DataContract]
    public class WorkerModel : EmployeeModel
    {
        [DataMember]
        public ManagerModel Supervisor { get; set; }
        
        [DataMember]
        public string WorkerType { get; set; }
    }
}