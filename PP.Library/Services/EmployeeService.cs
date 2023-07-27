//Singleton for Employee
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;

        private static object _lock = new object();

        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }

        private List<Employee> employees;

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        private EmployeeService()
        {
            employees = new List<Employee>()
            {
                new Employee{Name = "Alan" , ID = 1 , Rate=7.25m} ,
                new Employee{Name = "Vicki" , ID = 2 , Rate=7.25m } ,
            };
        }

        public Employee? Get(int id)
        {
            return employees.FirstOrDefault(e => e.ID == id);
        }

        public void Add(Employee? employee)
        {
            if (employee != null && employee.ID == 0)
            {
                employee.ID = LastId + 1;
                employees.Add(employee);
            }
        }

        public void Read()
        {
            employees.ForEach(Console.WriteLine);
        }

        public void Delete(int empID)
        {
            var employeeToRemove = Get(empID);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
            }
        }

        public bool IdExists(int? empid)
        {
            var E = employees.FirstOrDefault(e => e.ID == empid);
            if (E == null)
                return false;
            return true;
        }

        private int LastId
        {
            get
            {
                return Employees.Any() ? Employees.Select(e => e.ID).Max() : 0;
            }
        }

        public IEnumerable<Employee> Search(string query)
        {
            return Employees
                .Where(c => c.Name.ToUpper()
                .Contains(query.ToUpper()));
        }

    }

}
