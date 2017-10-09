using System;
using System.Collections.Generic;
using System.Linq;

namespace People.Repositories
{
    internal class InMemoryRepository : IRepository
    {
        private static readonly Dictionary<Type, Dictionary<string, object>> database = new Dictionary<Type, Dictionary<string, object>>();

        public void Save<T>(string id, T instance)
        {
            var type = typeof (T);
            var dataSegment = GetTypeSegment(type);

            if (!dataSegment.ContainsKey(id))
            {
                dataSegment.Add(id, instance);
                return;
            }

            dataSegment[id] = instance;
        }

        public T Get<T>(string id) where T : class
        {
            var dataSegment = GetTypeSegment(typeof (T));

            if (!dataSegment.ContainsKey(id))
                return default(T);

            return dataSegment[id] as T;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var dataSegment = GetTypeSegment(typeof (T));

            return dataSegment
                .Select(s => s.Value)
                .Cast<T>();
        }

        private Dictionary<string, object> GetTypeSegment(Type type)
        {
            if (!database.ContainsKey(type))
            {
                database.Add(type, new Dictionary<string, object>());
            }

            return database[type];
        }
    }
}