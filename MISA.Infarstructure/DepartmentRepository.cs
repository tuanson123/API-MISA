using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {/// <summary>
     /// Thao tác CSDL với phòng ban
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
