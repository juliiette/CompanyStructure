using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract.Services
{
    public interface IManagerService
    {
        ManagerModel CreateManager(string name, string position, int salary);

        List<string> AddSubordinate(string managerName, string workerName);

        void RemoveSubordinate(string managerName, string subordinateName);

        ManagerModel FindManagerModel(string name);
    }
}