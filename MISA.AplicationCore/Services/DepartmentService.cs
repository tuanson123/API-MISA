using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Services
{
    public class DepartmentService: BaseService<Department>, IDepartmentService
    {/// <summary>
     /// nghiệp vụ của phòng ban
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
        IDepartmentRepository _departmentRepository;
        //Hàm khởi tạo
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
