using MISA.AplicationCore.Entities;
using MISACukCuk.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{
    public interface IEmployeeService :IBaseService<Employee>
    {
        IEnumerable<Employee> GetEmployees();
        Customer GetEmployeeById(Guid employeeId);
        ServiceResult AddEmployee(Employee employee);
        ServiceResult UpdateEmployee(Employee employee);
        ServiceResult DeleteEmployee(Guid employeeId);
    }
}
