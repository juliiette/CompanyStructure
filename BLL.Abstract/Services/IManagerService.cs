using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract.Services
{
    public interface IManagerService
    {
        void CreateManager(int id, string name, string position, int salary);

        List<string> AddSubordinate(ManagerModel manager, WorkerModel worker);

        void RemoveSubordinate(ManagerModel manager, string subordinateName);
    }
}