using System;
using System.Collections.Generic;
using BLL.Abstract.Services;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class DirectorService : IDirectorService
    {
        private DirectorModel Director { get; set; }
        private IManagerService ManagerService { get; set; }

        public DirectorService(DirectorModel directorModel)
        {
            ManagerService = new ManagerService(directorModel);

            Director = directorModel;
        }
        public DirectorModel CreateDirector(string name, string position, int salary)
        {
            DirectorModel directorModel = new DirectorModel();
            directorModel.Name = name;
            directorModel.Position = position;
            directorModel.Salary = salary;
            directorModel.Subordinates = new List<ManagerModel>();
            directorModel.Workers = new List<WorkerModel>();

            return directorModel;
        }
        
        
        public List<string> AddSubordinate(DirectorModel director, string managerName)
        {
            ManagerModel manager = ManagerService.FindManagerModel(managerName);
            director.Subordinates.Add(manager);
            manager.Supervisor = director.Name;
            
            List<string> subordinatesName = new List<string>();

            foreach (var child in director.Subordinates)
            {
                subordinatesName.Add(child.Name);
            }

            return subordinatesName;
        }

        public void AddSubordinatesList(DirectorModel director, List<ManagerModel> managersList)
        {
            foreach (var employee in managersList)
            {
                director.Subordinates.Add(employee);
            }
        }
        

        public void RemoveSubordinate(DirectorModel director, string managerName)
        {
            foreach (var managerModel in director.Subordinates)
            {
                if (managerModel.Name == managerName)
                {
                    director.Subordinates.Remove(managerModel);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}