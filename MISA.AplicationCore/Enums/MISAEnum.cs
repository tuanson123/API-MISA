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
            Success = 200
        }
        public enum EntityState
        {
            Insert=1,
            Update=2,
            Delete=3
        }
    
}
