using System;
using System.Collections.Generic;
using BLL.Abstract.Services;
using BLL.Implementation.Services;
using BLL.Implementation.Strategy;
using BLL.Models;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorModel director = new DirectorModel();
            director = Serializer.Deserialize("Company.json");
            
            
            IClientService clientService = new ClientService(director);
            IManagerService managerService = new ManagerService();
            IDirectorService directorService = new DirectorService();
            
            Console.Write("client$ ");

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "+")
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Position: ");
                    string position = Console.ReadLine();
                    Console.Write("Salary: ");
                    int salary = Int32.Parse(Console.ReadLine());
                    
                    string[] words = position.ToLower().Split(new char[] {' '});
                    foreach (var item in words)
                    {
                        if (item == "manager")
                        {
                            managerService.CreateManager(name, position, salary);
                        }

                        if (item == "worker")
                        {
                            clientService.AddEmployee(name, position, salary);
                        }
                    }
                }
                
                if (command == "straight")
                {
                    StraightStructureStrategy straightStructure = new StraightStructureStrategy();

                    List<string> result =
                        clientService.GetEmployeesNames(straightStructure.BuildStructure(director));
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }

                if (command == "position")
                {
                    PositionHeightStructureStrategy positionHeight = new PositionHeightStructureStrategy();
                    List<string> result =
                        clientService.GetEmployeesNames(positionHeight.BuildStructure(director));
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }

                if (command == "find max")
                {
                    EmployeeModel result = clientService.FindEmployeeWithMaxSalary();
                    Console.WriteLine("{0}  {1}", result.Name, result.Salary);
                }

                if (command == "find bigger")
                {
                    Console.Write("Enter int number: ");
                    int value = Int32.Parse(Console.ReadLine());
                    List<EmployeeModel> resultEmployees = clientService.FindEmployeesWithBiggerSalary(value);
                    
                    foreach (var item in resultEmployees)
                    {
                        Console.WriteLine("{0} : {1}, ", item.Name, item.Salary);
                    }
                }

                if (command == "subordinates")
                {
                    Console.Write("Enter name: ");
                    string enteredName = Console.ReadLine();

                    List<WorkerModel> resultedEmployees = clientService.FindSubordinates(enteredName);
                    foreach (var item in resultedEmployees)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                if (command == "find position")
                {
                    Console.Write("Position: ");
                    string enteredValue = Console.ReadLine();

                    List<EmployeeModel> resultEmployees = clientService.FindByPosition(enteredValue);
                    
                    foreach (var item in resultEmployees)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

            }
            
        }
    }
}