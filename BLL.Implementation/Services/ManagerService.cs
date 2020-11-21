using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class ManagerService
    {
        public void CreateManager(int id, string name, string position, int salary)
        {
            ManagerModel managerModel = new ManagerModel();
            managerModel.Id = 1;
            managerModel.Name = name;
            managerModel.Position = position;
            managerModel.Salary = salary;
            managerModel.Subordinates = new List<EmployeeModel>();
        }

        public List<string> AddSubordinate(ManagerModel manager, EmployeeModel worker)
        {
            manager.Subordinates.Add(worker);
            
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