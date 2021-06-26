using NixWebApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.DAL.EF
{
    public static class SeedData
    {
        public static IEnumerable<Guest> GuestInitializer()
        {
            var guestList = new List<Guest>()
            {
                new Guest()
                {
                    Id = 1,
                    Name = "Guest1_Name",
                    Surname = "Guest1_Surname",
                    Patronymic = "Guest1_Patronymic",
                    BirthDate = null,
                    Address = "Guest1_Addres",
                },
                new Guest()
                {
                    Id = 2,
                    Name = "Guest2_Name",
                    Surname = "Guest2_Surname",
                    Patronymic = "Guest2_Patronymic",
                    BirthDate = null,
                    Address = "Guest2_Addres",
                }
            };

            return guestList;
        }

        public static IEnumerable<Category> CategoryInitializer()
        {
            var categoryList = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Standart",
                    Beds = 2
                }
            };

            return categoryList;
        }

        public static IEnumerable<PriceToCategory> PriceToCategoryInitializer()
        {
            var priceToCategoryList = new List<PriceToCategory>()
            {
                new PriceToCategory()
                {
                    Id = 1,
                    CategoryId = 1,
                    Price = 1000,
                    StartDate = new DateTime(2021, 1, 1),
                    EndDate = new DateTime(2021, 2, 28)
                },
                new PriceToCategory()
                {
                    Id = 2,
                    CategoryId = 1,
                    Price = 1000,
                    StartDate = new DateTime(2021, 3, 1),
                    EndDate = new DateTime(2021, 5, 31)
                },
                new PriceToCategory()
                {
                    Id = 3,
                    CategoryId = 1,
                    Price = 1000,
                    StartDate = new DateTime(2021, 6, 1),
                    EndDate = new DateTime(2021, 8, 31)
                }
            };

            return priceToCategoryList;
        }
        
        public static IEnumerable<Room> RoomInitializer()
        {
            var roomtList = new List<Room>()
            {
                new Room()
                {
                    Id = 1,
                    Name = "1A",
                    CategoryId = 1,
                    IsActive = true,
                },
                new Room()
                {
                    Id = 2,
                    Name = "1B",
                    CategoryId = 1,
                    IsActive = true,
                }
            };

            return roomtList;
        }
    }
}
