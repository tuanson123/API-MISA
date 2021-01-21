using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;


namespace MISA.AplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode=Enums.MISACode.Success};
        }
        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.AddNew;
            //Thực hiện validate:
            var isValidate = Validate(entity);
            if(isValidate==true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;

                return _serviceResult;
            }
            else
            {
                
                return _serviceResult;
            }
           
        }

        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            return _serviceResult;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public TEntity GetEntityId(Guid entityId)
        {
            return _baseRepository.GetEntityId(entityId);
        }

        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;

                return _serviceResult;
            }
            else
            {

                return _serviceResult;
            }

        }
        private bool Validate(TEntity entity)
        {
            var mesArrayError = new List<string>();
            var serviceResult = new ServiceResult();
            var isValidate = true;

            //Đọc các Property:
            var properties = entity.GetType().GetProperties();
            foreach(var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = property.GetCustomAttributes(typeof(DisplayName), true);
                //Kiểm tra xem có atribute cần phải validate không:
                if (property.IsDefined(typeof(Requied),false))
                {
                    //Check bắt buộc nhập:
                    
                    if(propertyValue==null)
                    {
                        isValidate = false;
                        mesArrayError.Add($"Thông tin {displayName} không được phép để trống");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }    
                }

                if(property.IsDefined(typeof(CheckDuplicate),false))
                {
                    //Check trùng dữ liệu:
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity,property);
                    if(entityDuplicate!=null)
                    {
                        isValidate = false;
                        mesArrayError.Add($"Thông tin {displayName} đã tồn tại trên hệ thống");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }    
                }

                if (property.IsDefined(typeof(MaxLengh), false))
                {
                    //Lấy độ dài hiện tại:
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLengh), true)[0];

                    var length = (attributeMaxLength as MaxLengh).Value;
                    var msg= (attributeMaxLength as MaxLengh).ErrorMsg;
                    if(propertyValue.ToString().Trim().Length>length)
                    {
                        isValidate = false;
                        mesArrayError.Add(msg??$"Thông tin vượt quá {length} kí tự cho phép.");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }    
                }

            }
            _serviceResult.Data = mesArrayError;

            return isValidate;
        }
    }
}
