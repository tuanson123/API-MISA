using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Services
{
    public class PositionService:BaseService<Position>, IPositionService
    {/// <summary>
     /// check nghiệp vụ của vị trí
     /// CreateBy:DTSON(19/01/2021)
     /// </summary>
        IPositionRepository _positionRepository;
        //Hàm khởi tạo
        public PositionService(IPositionRepository positionRepository) : base(positionRepository)
        {
            _positionRepository = positionRepository;
        }
    }
}
