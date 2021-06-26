using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Interfaces
{
    public interface IGuestService
    {
        IEnumerable<GuestDTO> GetAll();
        GuestDTO Get(int id);
        void Create(GuestDTO guest);
    }
}
