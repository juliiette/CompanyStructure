using System.Collections.Generic;
using System.Linq;
using BLL.Abstract;
using BLL.Abstract.Services;
using BLL.Implementation.Services;
using BLL.Models;
using NUnit.Framework;

namespace BLL.Implementation.Tests
{
    [TestFixture]
    public class Tests
    {
        private DirectorModel Director { get; set; }
        
        private IClientService ClientService { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Director = Serializer.Deserialize("/Users/juliastanko/Documents/university/trpz/trpz-2/Company/CompanyStructure/View/Company.json");
            
            ClientService = new ClientService(Director);
        }

        [Test]
        public void FindEmployeeWithMaxSalary_directorReturned()
        {
            // arrange
            EmployeeModel expected = Director;
            
            // act
            var actual = ClientService.FindEmployeeWithMaxSalary();
            
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindEmployeesWithBiggerSalary_2000given_directorReturned()
        {
            // arrange
            int givenSalary = 2000;
            List<EmployeeModel> actual = new List<EmployeeModel>();
            List<EmployeeModel> expected = new List<EmployeeModel>();
            expected.Add(Director);
            
            // act
            actual = ClientService.FindEmployeesWithBiggerSalary(givenSalary);
            
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindSubordinates_NadaFreemanGiven_nullExpected()
        {
            // arrange
            string givenName = "Nada Freeman";
            List<WorkerModel> actual;
            List<WorkerModel> expected = new List<WorkerModel>();
            
            // act
            actual = ClientService.FindSubordinates(givenName);
            
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByPosition_hrManagerGiven_NadaFreemanReturned()
        {
            // arrange
            string givenPosition = "HR manager";
            string expected = "Nada Freeman";
            string actual;

            // act
            actual = ClientService.FindByPosition(givenPosition).ElementAt(0).Name;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByPosition_kekGiven_nullReturned()
        {
            // arrange
            string givenPosition = "kek";
            List<EmployeeModel> actual;

            // act
            actual = ClientService.FindByPosition(givenPosition);

            // assert
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void AddEmployee_paramsGiven_workerReturned()
        {
            string name = "Luka";
            string position = "Worker simple";
            int salary = 1000;
            WorkerModel expected = new WorkerModel();
            expected.Name = name;
            expected.Position = position;
            expected.Salary = salary;

            var actual = ClientService.AddEmployee(name, position, salary);
            
            Assert.AreEqual(expected, actual);
        }
    }
}