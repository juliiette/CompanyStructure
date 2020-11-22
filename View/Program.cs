using System;
using System.Collections.Generic;
using BLL.Abstract.Services;
using BLL.Implementation.Services;
using BLL.Models;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorModel director = new DirectorModel();
            director = Serializer.Deserialize("Company.json");
            
            
            
            Console.ReadKey();
        }
    }
}