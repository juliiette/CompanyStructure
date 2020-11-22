using System;
using System.Collections.Generic;
using BLL.Abstract.Services;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class DirectorService : IDirectorService
    {
        public void CreateDirector(string name, string position, int salary)
        {
            DirectorModel directorModel = new DirectorModel();
            directorModel.Id = 1;
            directorModel.Name = name;
            directorModel.Position = position;
            directorModel.Salary = salary;
            directorModel.Subordinates = new List<ManagerModel>();
        }
        
        
        public List<string> AddSubordinate(DirectorModel director, ManagerModel manager)
        {
            director.Subordinates.Add(manager);
            
            List<string> subordinatesName = new List<string>();

            foreach (var child in director.Subordinates)
            {
                subordinatesName.Add(child.Name);
            }

            return subordinatesName;
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