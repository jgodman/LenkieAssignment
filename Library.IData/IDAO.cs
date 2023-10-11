namespace Library.IData
{
    public interface IDAO<T> : IBaseDAO<T> where T : class
    {
        public T Update(T entity);
        /// <summary>
        /// Fetches an item by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id);
    }
}
