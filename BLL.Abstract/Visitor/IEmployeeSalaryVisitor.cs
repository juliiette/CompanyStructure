using BLL.Models;

namespace BLL.Abstract.Visitor
{
    public interface IEmployeeSalaryVisitor : IEmployeeVisitor
    {
        EmployeeModel GetEmployeeWithMaxSalary(int value);
        
        
    }
}