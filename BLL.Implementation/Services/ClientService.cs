using System.Collections.Generic;
using System.IO;
using BLL.Abstract;
using BLL.Abstract.Services;
using BLL.Implementation.Strategy;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class ClientService : IClientService
    {
        private DirectorModel Director { get; set; }
        
        readonly IStructureStrategy _structureStrategy = new PositionHeightStructureStrategy();

        public ClientService(DirectorModel directorModel)
        {
            Director = directorModel;
        }
        
        public EmployeeModel FindEmployeeWithMaxSalary()
        {
            List<EmployeeModel> allEmployees = _structureStrategy.BuildStructure(Director);
            EmployeeModel resultedEmployee = new EmployeeModel();

            int maxSalary = 800;
            foreach (var employee in allEmployees)
            {
                if (employee.Salary >= maxSalary)
                {
                    maxSalary = employee.Salary;
                    resultedEmployee = employee;
                }
            }

            return resultedEmployee;
        }

        public List<EmployeeModel> FindEmployeesWithBiggerSalary(int givenSalary)
        {
            List<EmployeeModel> resultedEmployees = new List<EmployeeModel>();
            List<EmployeeModel> allEmployees = _structureStrategy.BuildStructure(Director);

            foreach (var employee in allEmployees)
            {
                if (employee.Salary > givenSalary)
                {
                    resultedEmployees.Add(employee);
                }
            }

            return resultedEmployees;
        }

        public List<WorkerModel> FindSubordinates(string name)
        {
            List<WorkerModel> resultedEmployees = new List<WorkerModel>();
            List<ManagerModel> allEmployees = Director.Subordinates;

            foreach (var employee in allEmployees)
            {
                if (employee.Name.ToLower() == name.ToLower())
                {
                    resultedEmployees = employee.WorkerSubordinates;
                }
            }

            return resultedEmployees;
        }

        public List<EmployeeModel> FindByPosition(string position)
        {
            List<EmployeeModel> resultedEmployees = new List<EmployeeModel>();
            List<EmployeeModel> allEmployees = _structureStrategy.BuildStructure(Director);
            
            foreach (var employee in allEmployees)
            {
                if (employee.Position.ToLower() == position.ToLower() ||
                    employee.Position.ToLower().Contains(position.ToLower()))
                {
                    resultedEmployees.Add(employee);
                }

            }

            return resultedEmployees;
        }
        

        public WorkerModel AddEmployee(string name, string position, int salary)
        {
            WorkerModel employeeModel = new WorkerModel();
            employeeModel.Name = name;
            employeeModel.Position = position;
            employeeModel.Salary = salary;
            Director.Workers.Add(employeeModel);

            return employeeModel;
        }

        public WorkerModel FindWorkerModel(string name)
        {
            WorkerModel resultedWorker = new WorkerModel();
            List<EmployeeModel> allWorkers = FindByPosition("worker");
            foreach (var worker in allWorkers)
            {
                if (worker.Name.ToLower() == name.ToLower())
                {
                    WorkerModel newWorker = AddEmployee(worker.Name, worker.Position, worker.Salary);
                    resultedWorker = newWorker;
                }
            }
            
            return resultedWorker;
        }
        
    }
}