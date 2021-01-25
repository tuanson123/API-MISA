using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;
using MISA.AplicationCore.Interfaces;
using MISACukCuk.AplicationCore.Entities;
using MISACukCuk.Entities.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>,IDisposable where TEntity:BaseEntity
    {/// <summary>
     /// Thao tác thực thi với CSDL
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
     
        #region Declare
        //Khai báo biến
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion
        #region Contructor
        //HÀM khởi tạo
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion
        #region Method
        //Thêm dữ liệu
        public int Add(TEntity entity)
        {
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var parameters = MappingDbType(entity);
                    // Thực hiện thêm khách hàng:
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            // Trả về kết quả (số bản ghi thêm mới được)
            return rowAffects;
        }
        //Xóa dữ liệu
        public int Delete(Guid entityId)
        {

            var dictionary = new Dictionary<string, object>
            {
                { $"{_tableName}Id", entityId.ToString() }
            };
            DynamicParameters parameter = new DynamicParameters(dictionary);
            var res = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                res = _dbConnection.Execute($"Proc_Delete{_tableName}ById", param: parameter, commandType: CommandType.StoredProcedure);
                transaction.Commit();
            }
            return res;
        }
        //Lấy dữ liệu
        public virtual IEnumerable<TEntity> GetEntities()
        {
            //Lấy dữ liệu data base
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        public virtual IEnumerable<TEntity> GetEntities(string storeName)
        {
            //Lấy dữ liệu data base
            var entities = _dbConnection.Query<TEntity>($"storeName", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }
        //Lấy dữ liệu theo Id
        public TEntity GetEntityId(Guid entityId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { $"{_tableName}Id", entityId.ToString() }
            };
            DynamicParameters parameter = new DynamicParameters(dictionary);
            // tạo commandText
            var entity = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            // trả về dữ liệu 
            return entity;
        }
        //Sửa dữ liệu
        public int Update(TEntity entity)
        {

            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                var parameters = MappingDbType(entity);
                // Thực hiện sửa khách hàng:
                rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", parameters, commandType: CommandType.StoredProcedure);
                transaction.Commit();

            }
            // Trả về kết quả (số bản ghi thêm mới được)
            return rowAffects;
        }
        //Hàm dùng cho những cho cái chung
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var dynamicParameters = new DynamicParameters();
            // Xử lí các kiểu dữ liệu (mapping database)
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                //Nếu property có kiểu dữ liệu là Guid thì chuyển value sang toString
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(entity).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return dynamicParameters;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue =property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if(entity.EntityState==EntityState.AddNew)
            {
                query = $"SELECT *FROM {_tableName} WHERE {propertyName}='{propertyValue}'";
            }    
            else if(entity.EntityState == EntityState.Update)
            {
                query = $"SELECT *FROM {_tableName} WHERE {propertyName}='{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        #endregion
    }
}
