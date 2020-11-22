using System.Collections.Generic;
using BLL.Abstract;
using BLL.Models;

namespace BLL.Implementation.Strategy
{
    public class StraightStructureStrategy : IStructureStrategy
    {
        public List<EmployeeModel> BuildStructure(DirectorModel directorModel)
        {
            List<EmployeeModel> resultedEmployees = new List<EmployeeModel>();
            
            resultedEmployees.Add(directorModel);
            foreach (var manager in directorModel.Subordinates)
            {
                resultedEmployees.Add(manager);
                foreach (var worker in manager.Subordinates)
                {
                    resultedEmployees.Add(worker);
                }
            }

            return resultedEmployees;
        }
    }
}