using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual int Add(TEntity entity)
        {
            //Thực hiện validate:

            return _baseRepository.Add(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public TEntity GetEntityId(Guid entityId)
        {
            return _baseRepository.GetEntityId(entityId);
        }

        public int Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }
        private bool Validate(TEntity entity)
        {
            var isValidate = true;
            //Đọc các Property:
            var properties = entity.GetType().GetProperties();
            foreach(var property in properties)
            {
                //Kiểm tra xem có atribute cần phải validate không:
                if(property.IsDefined(typeof(Requied),false))
                {
                    //Check bắt buộc nhập:
                    var propertyValue = property.GetValue(entity);
                    if(propertyValue==null)
                    {
                        isValidate = false;
                    }    
                }
                else if(property.IsDefined(typeof(CheckDuplicate),false))
                {
                    //Check trùng dữ liệu:
                    var propertyName = property.Name;
                    var entity = _baseRepository.GetEntityByProperty(property);
                }    

            }
            return isValidate;
        }
    }
}
