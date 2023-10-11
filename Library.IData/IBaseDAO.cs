using System.Collections.Generic;

namespace Library.IData
{
    public interface IBaseDAO<T> where T : class
    {
        /// <summary>
        /// This inserts a record for the entity and returns the number of rows affected, usually 1.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity);
        public List<T> GetAll();
    }
}
