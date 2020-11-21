using System.Collections.Generic;

namespace Data.Entity
{
    public class ManagerEntity
    {
        public DirectorEntity Supervisor { get; set; }
        
        public string ManagerType { get; set; }
        
        public List<WorkerEntity> Subordinates { get; set; }
    }
}