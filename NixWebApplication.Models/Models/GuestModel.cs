using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.Models
{
    public class GuestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public NixWebApplicationUserModel ApplicationUser { get; set; }
        public DateTime TimeStamp { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GuestModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Surname == model.Surname &&
                   Patronymic == model.Patronymic &&
                   BirthDate == model.BirthDate &&
                   Address == model.Address;
        }
    }
}
