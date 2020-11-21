using System.Collections.Generic;
using BLL.Models;
using BLL.Models.Interfaces;

namespace BLL.Abstract.Visitor
{
    public interface IEmployeeSubordinatesVisitor : IEmployeeVisitor
    {
        List<EmployeeModel> GetSubordinates(IEmployee employee);
    }
}