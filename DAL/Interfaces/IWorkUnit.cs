using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWorkUnit
    {
        IRepository<Booking> Bookings { get; }
        IRepository<Category> Categories { get; }
        IRepository<Guest> Guests { get; }
        IRepository<PriceToCategory> PricesToCategories { get; }
        IRepository<Room> Rooms { get; }

        void Save();
    }
}
