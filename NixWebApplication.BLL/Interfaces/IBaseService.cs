using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Interfaces
{
    public interface IBaseService<T> 
        where T : class
    {
        void Create(T booking);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
