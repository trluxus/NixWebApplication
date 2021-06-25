using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService : IService<BookingDTO>
    {
        private IWorkUnit Database { get; set; }

        public BookingService(IWorkUnit database)
        {
            Database = database;
        }

        public void Create(BookingDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookingDTO Get(int id)
        {
            var booking = Database.Bookings.Get(id);

            return new BookingDTO()
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                EnterDate = booking.EnterDate,
                LeaveDate = booking.LeaveDate,
                BookingGuest = new GuestDTO()
                {
                    Id = booking.BookingGuest.Id,
                    Name = booking.BookingGuest.Name,
                    Surname = booking.BookingGuest.Surname,
                    Patronymic = booking.BookingGuest.Patronymic,
                    BirthDate = booking.BookingGuest.BirthDate,
                    Address = booking.BookingGuest.Address
                },
                BookingRoom = new RoomDTO()
                {
                    Id = booking.BookingRoom.Id,
                    Name = booking.BookingRoom.Name,
                    IsActive = booking.BookingRoom.IsActive,
                    RoomCategory = new CategoryDTO
                    {
                        Id = booking.BookingRoom.RoomCategory.Id,
                        Name = booking.BookingRoom.RoomCategory.Name,
                        Beds = booking.BookingRoom.RoomCategory.Beds
                    }
                }
            };
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Booking, BookingDTO>()
            ).CreateMapper();

            return mapper.Map<IEnumerable<Booking>, List<BookingDTO>>(Database.Bookings.GetAll());
        }
    }
}
