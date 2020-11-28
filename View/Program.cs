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
            DirectorModel director = Serializer.Deserialize("Company.json");
            
            
            IClientService clientService = new ClientService(director);
            IManagerService managerService = new ManagerService(director);
            IDirectorService directorService = new DirectorService(director);
            
            
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
                            Console.WriteLine(managerService.CreateManager(name, position, salary).Name);
                        }

                        if (item == "worker")
                        {
                            Console.WriteLine(clientService.AddEmployee(name, position, salary).Name);
                        }

                        if (item == "director")
                        {
                            Console.WriteLine(directorService.CreateDirector(name, position, salary).Name);
                        }
                    }
                }
                
                if (command == "straight")
                {
                    StraightStructureStrategy straightStructure = new StraightStructureStrategy();

                    List<EmployeeModel> result = straightStructure.BuildStructure(director);
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                if (command == "height")
                {
                    PositionHeightStructureStrategy positionHeight = new PositionHeightStructureStrategy();
                    List<EmployeeModel> result = positionHeight.BuildStructure(director);
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
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

                if (command == "add sub")
                {
                    Console.WriteLine("To manager or director? m or n");
                    string input = Console.ReadLine();
                    if (input == "m")
                    {
                        Console.Write("Daddy: ");
                        string daddyName = Console.ReadLine();
                        Console.Write("Child: ");
                        string childName = Console.ReadLine();
                        managerService.AddSubordinate(daddyName, childName);
                    }

                    if (input == "d")
                    {
                        Console.Write("Child: ");
                        string childName = Console.ReadLine();
                        directorService.AddSubordinate(director, childName);
                    }
                }

                if (command == "remove sub")
                {
                    Console.WriteLine("To manager or director? m or n");
                    string input = Console.ReadLine();
                    if (input == "m")
                    {
                        Console.Write("Daddy: ");
                        string daddyName = Console.ReadLine();
                        Console.Write("Child: ");
                        string childName = Console.ReadLine();
                        managerService.RemoveSubordinate(daddyName, childName);
                    }

                    if (input == "d")
                    {
                        Console.Write("Child: ");
                        string childName = Console.ReadLine();
                        directorService.RemoveSubordinate(director, childName);
                    }
                }
                
                if (command == "exit")
                {
                    Console.WriteLine("Save changes? y or n");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        Serializer.Serialize(director);
                        break;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                if (command == "help")
                {
                    Console.Write("+    to add new worker \n straight    to build straight position structure " +
                                  "\n height    to build position height structure" +
                                  "\n find max    to find employee with max salary" +
                                  "\n find bigger    find employees with bigger wage than you entered" +
                                  "\n subordinates    to output subordinates of given employee (only manager)" +
                                  "\n find position    finds all employes within given position" +
                                  "\n add sub    adds subordinate to given supervisor" +
                                  "\n remove sub    removes subordinate" +
                                  "\n exit \n");
                }
                
                Console.Write("client$ ");

            }
            
        }
    }
}