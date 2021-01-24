using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Api.Controllers
{
    public class PositionsController : BaseEntityController<Position>
    {
        IBaseService<Position> _baseService;
        public PositionsController(IBaseService<Position> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
