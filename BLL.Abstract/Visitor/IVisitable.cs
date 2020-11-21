namespace BLL.Abstract.Visitor
{
    public interface IVisitable
    {
        void Accept(IEmployeeVisitor employeeVisitor);
    }
}