using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISACukCuk.Api.Controllers
{
    
    public class DepartmentsController : BaseEntityController<Department>
    {
        IBaseService<Department> _baseService;
        public DepartmentsController(IBaseService<Department> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
