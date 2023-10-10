using System.Collections.Generic;

namespace Library.IData
{
    public interface IBaseDAO<T> where T : class
    {
        public int Insert(T entity);
        public List<T> GetAll();
    }
}
