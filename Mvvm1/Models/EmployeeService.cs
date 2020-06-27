using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm1.Models
{
    class EmployeeService
    {
        List<Employee> empList = new List<Employee>();

        public EmployeeService()
        {
            empList.Add(new Employee() { Id = 100, Age = 100, Name = "Alex" }); 
        }

        public List<Employee> GetAll()
        {
            return empList;
        }

        public void Add(Employee newEmp)
        {
            empList.Add(newEmp);
        }

        public bool Update(Employee empToBeUpdated)
        {
            bool isUpdated = false;

            int index = empList.FindIndex((emp) => emp.Id == empToBeUpdated.Id);

            if (index >= 0)
            {
                empList[index] = empToBeUpdated;
                return true;
            }

            return false;
        }

        public bool Delete(Employee emp)
        {
            int index = empList.FindIndex((e) => e.Id == emp.Id);

            if(index >= 0)
            {
                empList.RemoveAt(index);
                return true;
            }

            return false;
        }

        public Employee Search(int id)
        {
            return empList[empList.FindIndex((e) => e.Id == id)];
        }
    }
}
