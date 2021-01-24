using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
  
   

        

        /// <summary>
        /// Lấy danh sách nhân viên theo mã
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Employee GetEmployeeByCode(string employeeCode);
    }
}
