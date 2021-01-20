using Microsoft.AspNetCore.Mvc;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.AplicationCore;
using MISA.AplicationCore.Interfaces;

using MISACukCuk.AplicationCore.Entities;
using MISA.AplicationCore.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISACukCuk.Api.Controllers
{
    /// <summary>
    /// Api danh mục kháCH HÀNG
    /// CreatedBy:DTSON(08/01/2021)
    /// </summary>
   
    public class CustomersController : BaseEntityController<Customer>
    {
        ICustomerService _baseService;
        public CustomersController(ICustomerService baseService):base(baseService)
        {
            _baseService = baseService;
        }
    }
}
