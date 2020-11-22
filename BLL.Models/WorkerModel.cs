using System.Runtime.Serialization;

namespace BLL.Models
{
    [DataContract]
    public class WorkerModel : EmployeeModel
    {
        [DataMember]
        public string Supervisor { get; set; }
        
    }
}