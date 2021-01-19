using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreateBy:DTSON(1/18/2021)
        IEnumerable<Employee> GetEmployees();
        /// <summary>
        /// Lấy danh sách nhân viên theo ID
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Employee GetEmployeeById(Guid employeeId);

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <returns> số bản ghi thêm thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int AddCustomer(Employee employee);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <returns> Số bản ghi cập nhật thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int UpdateEmployee(Employee employee);

        /// <summary>
        /// Xóa nhân viên theo ID
        /// </summary>
        /// <returns> Số bản ghi xóa thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int DeleteEmployee(Guid employeeId);

        /// <summary>
        /// Lấy danh sách nhân viên theo ID
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Employee GetEmployeeByCode(string employeeCode);
    }
}
