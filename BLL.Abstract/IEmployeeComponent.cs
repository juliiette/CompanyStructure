using System;
using BLL.Models;

namespace BLL.Abstract
{
    public interface IEmployeeComponent
    {
        void Component(string name, string position, int salary);

        void AddChild(EmployeeModel employee, EmployeeModel child);

        void Display(EmployeeModel employee);

        void Remove();

        void Accept();
    }
}