using MISA.AplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{/// <summary>
 /// Trả về Service
 /// CreateBy:DTSON(19/01/2021)
 /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Trả ra dữ liệu
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// Các loại lỗi API
        /// </summary>
        public MISACode MISACode { get; set; }
    }
}
