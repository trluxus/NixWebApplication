using NixWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetAll();
        BookingDTO Get(int id);
        void Create(BookingDTO booking);
        decimal Income(DateTime date);
    }
}
