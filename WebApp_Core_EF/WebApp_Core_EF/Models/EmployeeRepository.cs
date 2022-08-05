using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Core_EF.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly EmployeeDBContext db;
        public EmployeeRepository(EmployeeDBContext context)
        {
            db = context;
        }

        //Implementation codes
        public Employee AddEmployee(Employee employee)
        {
             db.Employees.Add(employee);
            db.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee emp = db.Employees.Find(Id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return db.Employees;
        }

        public Employee GetEmployeeByID(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee employeechanges)
        {
            //var employee = db.Employees.Attach(employeechanges);
            //employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //db.SaveChanges();
            //return employeechanges;

            //Alternatively we can check individual property state

            db.Employees.Attach(employeechanges);
            var entry = db.Entry(employeechanges);
            entry.Property(e => e.Name).IsModified = true;
            //same way for all properties
           // entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return employeechanges;
        }
    }
}
