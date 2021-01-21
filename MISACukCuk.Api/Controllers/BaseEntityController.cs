using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISACukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #region Method


        // GET: api/<CustomersController>
        /// <summary>
        /// Lấy toàn bộ khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:DTSON(08/01/2020)
        [HttpGet]
        public IActionResult Get()
        {


            //lấy dữ liệu từ database
            var entities = _baseService.GetEntities();
            //trả dữ liệu cho client
            return Ok(entities);
        }

        // GET api/<CustomersController>/5
        /// <summary>
        /// Lấy ds khách hàng theo id và tên
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <param name="name">tên khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:DTSON(08/01/2020)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            var entity = _baseService.GetEntityId(id);
            return Ok(entity);

        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {

            var serviceResult = _baseService.Add(entity);
            if(serviceResult.MISACode==MISA.AplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
         

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if(keyProperty.PropertyType==typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if(keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity,id);

            }
            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == MISA.AplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            return Ok(res);
        }
        #endregion
    }
}
