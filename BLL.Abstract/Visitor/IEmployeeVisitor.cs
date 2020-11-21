using BLL.Models;

namespace BLL.Abstract.Visitor
{
    public interface IEmployeeVisitor
    {
        void Visit(WorkerModel worker);

        void Visit(ManagerModel manager);
        
        void Visit(DirectorModel director);
    }
}