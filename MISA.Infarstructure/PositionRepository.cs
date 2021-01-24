using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class PositionRepository: BaseRepository<Position>, IPositionRepository
    {/// <summary>
     /// Thao tác dữ liệu là Vị trí
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
        public PositionRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
