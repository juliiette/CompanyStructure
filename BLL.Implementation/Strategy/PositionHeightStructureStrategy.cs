using System.Collections.Generic;
using BLL.Abstract;
using BLL.Models;

namespace BLL.Implementation.Strategy
{
    public class PositionHeightStructureStrategy : IStructureStrategy
    {
        public List<EmployeeModel> BuildStructure(DirectorModel directorModel)
        {
            List<EmployeeModel> resultedEmployees = new List<EmployeeModel>();
            List<WorkerModel> workers = new List<WorkerModel>();

            resultedEmployees.Add(directorModel);
            foreach (var manager in directorModel.Subordinates)
            {
                resultedEmployees.Add(manager);
                foreach (var worker in manager.Subordinates)
                {
                    workers.Add(worker);
                }
            }

            foreach (var worker in workers)
            {
                resultedEmployees.Add(worker);
            }
            
            return resultedEmployees;
        }
    }
}