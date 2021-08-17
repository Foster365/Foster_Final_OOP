using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IPoolable<T>
    {

        event Action<T> OnDeactivate;

    }

    public class ObjectsPool<T> where T : IPoolable<T>, new()
    {
        private List<T> inUse = new List<T>();
        private List<T> available = new List<T>();

        public T Get()
        {
            T bullet;

            if (available.Count > 0)
            {
                bullet = available[0];
                available.Remove(bullet);
            }
            else
            {
                bullet = new T();
                bullet.OnDeactivate += OnBulletDeactivateHandler;
            }

            inUse.Add(bullet);
            return bullet;
        }

        private void OnBulletDeactivateHandler(T bullet)
        {
            Release(bullet);
        }

        public void Release(T bullet)
        {
            inUse.Remove(bullet);
            available.Add(bullet);
        }

    }
}
