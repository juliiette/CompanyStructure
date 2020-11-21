using System.Collections.Generic;
using BLL.Abstract.Visitor;
using BLL.Models;

namespace BLL.Implementation.Visitors
{
    public class EmployeeSalaryVisitor : IEmployeeVisitor
    {
        public void Visit(WorkerModel worker)
        {
            
        }

        public void Visit(ManagerModel manager)
        {
            
        }

        public void Visit(DirectorModel director)
        {
            
        }

        public EmployeeModel GetEmployeeWithMaxSalary()
        {

            throw new System.NotImplementedException();
        }

        public List<EmployeeModel> GetEmployeesWithBiggerSalary(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}