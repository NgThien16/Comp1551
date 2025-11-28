using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(string name);
    }
}
