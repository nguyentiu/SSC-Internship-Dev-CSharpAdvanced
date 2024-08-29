using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedExercises.Repositories
{
    public class GenericRepository<T>
    {
        private List<T> _items = new List<T>();

        public event Action<string> OnItemAdded;

        public void Add(T item)
        {
            _items.Add(item);
            OnItemAdded?.Invoke($"Item added: {item}");
        }

        public void Remove(T item) => _items.Remove(item);

        public T GetById(Func<T, bool> predicate) => _items.FirstOrDefault(predicate);

        public List<T> GetAll() => _items;

        public async Task<List<T>> GetAllAsync()
        {
            await Task.Delay(1000); // Simulate async work
            return _items;
        }
    }
}
