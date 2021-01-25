using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;


namespace MISA.AplicationCore.Services
{
    /// <summary>
    /// Check nghiệp vụ 
    /// CreateBy:DTSON(19/01/2021)
    /// </summary>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {

        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        //Hàm Khởi tạo 
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode=Enums.MISACode.Success};
        }
        //Check nghiệp vụ thêm
        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.AddNew;
            //Thực hiện validate:
            var isValidate = Validate(entity);
               
            if(isValidate==true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Messenger = Properties.Resources.Msg_AddSuccess;
                return _serviceResult;
            }
            else
            {
                
                return _serviceResult;
            }
           
        }
        //Check nghiệp vụ xóa
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            _serviceResult.MISACode = Enums.MISACode.Success;
            _serviceResult.Messenger = Properties.Resources.Msg_DeleteSuscess;

            return _serviceResult;
        }
        //Check nghiệp vụ lấy tất cả
        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }
        //Check nghiệp vụ theo lấy theo Id
        public TEntity GetEntityId(Guid entityId)
        {
            return _baseRepository.GetEntityId(entityId);
        }
        //Check nghiệp vụ sửa
        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
                _serviceResult.Messenger = Properties.Resources.Msg_UpdateSuccess;

                return _serviceResult;
            }
            else
            {

                return _serviceResult;
            }

        }
        //Nghiệp vụ check
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
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayNameAttributes.Length>0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;
                }    
                //Kiểm tra xem có atribute cần phải validate không:
                if (property.IsDefined(typeof(Requied),false))
                {
                    //Check bắt buộc nhập:
                    
                    if(propertyValue==null)
                    {
                        isValidate = false;
                        mesArrayError.Add(string.Format(Properties.Resources.Msg_IsNotValid, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
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
                        mesArrayError.Add(string.Format(Properties.Resources.Msg_Duplicate,displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
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
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }    
                }

            }
            _serviceResult.Data = mesArrayError;
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }
            return isValidate;
        }
        /// <summary>
        /// Hàm thực hiện kiểm tra  nghiệp vụ
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
    }
}
