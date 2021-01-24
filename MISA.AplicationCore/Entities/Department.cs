using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{
    public class Department:BaseEntity
    { /// <summary>
      /// Phòng ban
      /// CreateBy:DTSON(01/14/2021)
      /// </summary>


        /// <summary>
        /// ID Phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
    }
}
