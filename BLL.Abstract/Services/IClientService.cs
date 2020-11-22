using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract.Services
{
    public interface IClientService
    {
        EmployeeModel FindEmployeeWithMaxSalary();

        List<EmployeeModel> FindEmployeesWithBiggerSalary(int givenSalary);

        List<EmployeeModel> FindSubordinates(string name);

        List<EmployeeModel> FindByPosition(string position);

        List<string> GetEmployeesNames(List<EmployeeModel> employeeModels);
        
    }
}