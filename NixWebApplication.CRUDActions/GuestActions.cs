using AutoMapper;
using NixWebApplication.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.CRUDActions
{
    public class GuestActions
    {
        private readonly IGuestService _service;
        private readonly IMapper _mapper;

        public GuestActions(IGuestService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public
    }
}
