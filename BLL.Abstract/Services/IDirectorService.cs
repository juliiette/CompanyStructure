using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract.Services
{
    public interface IDirectorService
    {
        DirectorModel CreateDirector(string name, string position, int salary);

        List<string> AddSubordinate(DirectorModel director, string managerName);

        void RemoveSubordinate(DirectorModel director, string managerName);

        void AddSubordinatesList(DirectorModel director, List<ManagerModel> managersList);
    }
}