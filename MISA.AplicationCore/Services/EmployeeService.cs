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
    {/// <summary>
     /// check nghiệp vụ của nhân viên
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
        #region Contructor
        IEmployeeRepository _employeeRepository;
        //Hàm khởi tạo
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion


    }
}
