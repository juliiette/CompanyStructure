using System.Collections.Generic;
using BLL.Abstract;
using BLL.Abstract.Visitor;
using BLL.Models;

namespace BLL.Implementation.Visitors
{
    public class EmployeeSubordinatesVisitor : IEmployeeVisitor
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

        public List<EmployeeModel> GetSubordinates(EmployeeModel employee)
        {
            throw new System.NotImplementedException();
        }
    }
}