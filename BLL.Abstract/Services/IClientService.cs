using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract.Services
{
    public interface IClientService
    {
        EmployeeModel FindEmployeeWithMaxSalary();

        List<EmployeeModel> FindEmployeesWithBiggerSalary(int givenSalary);

        List<WorkerModel> FindSubordinates(string name);

        List<EmployeeModel> FindByPosition(string position);
        
        WorkerModel AddEmployee(string name, string position, int salary);

        WorkerModel FindWorkerModel(string name);
    }
}