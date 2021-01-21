using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Enums
{
 
        public enum MISACode

        {   /// <summary>
            /// Dữ liệu hợp lệ
            /// </summary>
            IsValid = 100,
            /// <summary>
            /// Dữ liệu chưa hợp lệ
            /// </summary>
            NotValid = 900,
            /// <summary>
            /// Thành công
            /// </summary>
            Success = 200,
            Exception=500
        }
    /// <summary>
    /// Xác định trạng thái của object
    /// </summary>
        public enum EntityState
        {
            AddNew=1,
            Update=2,
            Delete=3,

        }
    
}
