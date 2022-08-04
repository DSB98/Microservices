using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Core_EF.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeechanges);
        Employee DeleteEmployee(int Id);

    }
}
