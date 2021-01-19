using MISA.AplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{
    public class ServiceResult
    {
        public object Data { get; set; }
        public string Messenger { get; set; }
        public MISACode MISACode { get; set; }
    }
}
