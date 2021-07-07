﻿using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Interfaces
{
    public interface IGuestService
    {    
        void Create(GuestDTO guest);
        void Delete(int id);
        IEnumerable<GuestDTO> GetAll();
        GuestDTO Get(int id);
    }
}
