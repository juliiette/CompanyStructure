using System.Runtime.Serialization;

namespace BLL.Models
{
    [DataContract]
    public class EmployeeModel
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Position { get; set; }
        
        [DataMember]
        public int Salary { get; set; }
    }
}