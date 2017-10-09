using System.Collections.Generic;

namespace People.Repositories
{
    public interface IRepository
    {
        void Save<T>(string id, T instance);
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>();
    }
}