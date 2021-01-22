using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using MISACukCuk.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }    
        public ServiceResult AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Customer GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
           return _employeeRepository.GetEmployees();
        }

        public ServiceResult UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
