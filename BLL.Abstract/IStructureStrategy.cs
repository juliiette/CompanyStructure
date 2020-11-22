using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstract
{
    public interface IStructureStrategy
    {
        List<EmployeeModel> BuildStructure(DirectorModel directorModel);
    }
}