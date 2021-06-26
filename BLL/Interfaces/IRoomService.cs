using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAll();
        RoomDTO Get(int id);
        void Create(RoomDTO room);
        IEnumerable<RoomDTO> FindEmpty(DateTime enterDate, DateTime leaveDate);
    }
}
