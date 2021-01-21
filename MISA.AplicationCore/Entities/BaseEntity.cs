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

    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string Name { get; set; }
        public DisplayName(string name=null)
        {
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengh:Attribute
    {
        public int Value { get; set; }
        public string ErrorMsg { get; set; }
        public MaxLengh(int lengh,string errorMsg)
        {
            this.Value = lengh;
            this.ErrorMsg = errorMsg;
        }    
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
