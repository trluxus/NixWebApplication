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
        void Create(RoomDTO room);
        void Delete(int id);
        IEnumerable<RoomDTO> FindEmpty(DateTime enterDate, DateTime leaveDate);
        RoomDTO Get(int id);
        IEnumerable<RoomDTO> GetAll();      
    }
}
