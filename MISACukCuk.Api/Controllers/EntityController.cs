using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class EntityController<MISAEntity>: ControllerBase 
    {
        #region declare
       
        //Khởi tạo đối tượng kết nối tới database
        
        protected DbConnector _dbConnector;
        #endregion

        #region constructor
        public EntityController()
        {
            
            _dbConnector = new DbConnector();
        }
        #endregion
        [HttpGet]
        public virtual IActionResult Get()
        {
            

            //lấy dữ liệu từ database
            var customerGroups = _dbConnector.Get<MISAEntity>();
            //trả dữ liệu cho client
            return Ok(customerGroups);
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            

            //lấy dữ liệu từ database
            var customerGroups = _dbConnector.GetById<MISAEntity>(id);
            //trả dữ liệu cho client
            return Ok(customerGroups);
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok(1);
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok(1);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(1);
        }
    }
}
