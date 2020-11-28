using System;
using System.Collections.Generic;
using BLL.Abstract;
using BLL.Abstract.Services;
using BLL.Implementation.Strategy;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class ManagerService : IManagerService
    {
        private DirectorModel Director { get; set; }
        
        readonly IStructureStrategy _structureStrategy = new PositionHeightStructureStrategy();
        
        private IClientService ClientService { get; set; }

        public ManagerService(DirectorModel directorModel)
        {
            Director = directorModel;
            
            ClientService = new ClientService(Director);
        }
        
        public ManagerModel CreateManager(string name, string position, int salary)
        {
            ManagerModel managerModel = new ManagerModel();
            managerModel.Name = name;
            managerModel.Position = position;
            managerModel.Salary = salary;
            managerModel.WorkerSubordinates = new List<WorkerModel>();
            managerModel.Supervisor = Director.Name;
            
            Director.Subordinates.Add(managerModel);

            return managerModel;
        }

        public List<string> AddSubordinate(string managerName, string workerName)
        {
            List<string> subordinatesNames = new List<string>();

            if (workerName != null && managerName != null)
            {
                ManagerModel manager = FindManagerModel(managerName);
                WorkerModel worker = ClientService.FindWorkerModel(workerName);
                manager.WorkerSubordinates.Add(worker);
                worker.Supervisor = manager.Name;
                

                foreach (var child in manager.WorkerSubordinates)
                {
                    subordinatesNames.Add(child.Name);
                }
            }
            return subordinatesNames;
        }
        
        public void RemoveSubordinate(string managerName, string subordinateName)
        {
            ManagerModel manager = FindManagerModel(managerName);
            foreach (var subordinateModel in manager.WorkerSubordinates)
            {
                if (subordinateModel.Name == subordinateName)
                {
                    manager.WorkerSubordinates.Remove(subordinateModel);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public ManagerModel FindManagerModel(string name)
        {
            ManagerModel resultedManager = new ManagerModel();
            List<ManagerModel> allEmployees = Director.Subordinates;

            foreach (var employee in allEmployees)
            {
                if (employee.Name.ToLower() == name.ToLower())
                {
                    resultedManager = employee;
                }
            }

            return resultedManager;
        }
    }
}