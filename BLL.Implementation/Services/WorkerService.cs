using BLL.Abstract.Visitor;

namespace BLL.Implementation.Services
{
    public class WorkerService : IVisitable
    {
        public void Accept(IEmployeeVisitor employeeVisitor)
        {
            throw new System.NotImplementedException();
        }
    }
}