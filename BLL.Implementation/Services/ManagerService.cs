using System;
using System.Collections.Generic;
using BLL.Abstract.Services;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class ManagerService : IManagerService
    {
        public ManagerModel CreateManager(string name, string position, int salary)
        {
            ManagerModel managerModel = new ManagerModel();
            managerModel.Name = name;
            managerModel.Position = position;
            managerModel.Salary = salary;
            managerModel.Subordinates = new List<WorkerModel>();

            return managerModel;
        }

        public List<string> AddSubordinate(ManagerModel manager, WorkerModel worker)
        {
            if (worker != null)
            {
                manager.Subordinates.Add(worker);
                worker.Supervisor = manager.Name;
            }
            
            List<string> subordinatesName = new List<string>();

            foreach (var child in manager.Subordinates)
            {
                subordinatesName.Add(child.Name);
            }

            return subordinatesName;
        }
        
        public void RemoveSubordinate(ManagerModel manager, string subordinateName)
        {
            foreach (var subordinateModel in manager.Subordinates)
            {
                if (subordinateModel.Name == subordinateName)
                {
                    manager.Subordinates.Remove(subordinateModel);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}