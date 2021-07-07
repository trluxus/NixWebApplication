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
        void Create(BookingDTO booking);
        void Delete(int id);
        BookingDTO Get(int id);
        IEnumerable<BookingDTO> GetAll();    
        decimal Income(DateTime date);
    }
}
