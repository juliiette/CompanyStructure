using System.Collections.Generic;

namespace Data.Entity
{
    public class DirectorEntity
    {
        public List<ManagerEntity> Subordinates { get; set; }
    }
}