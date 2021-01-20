using MISA.AplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{
    //Bắt buộc nhập
    [AttributeUsage(AttributeTargets.Property)]
    public class Requied:Attribute
    {

    }
    //Check trùng mã
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    public class BaseEntity
    {
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
