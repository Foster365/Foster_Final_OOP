using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Roulette
    {
        Random rnd = new Random();

        public T Run<T>(Dictionary<T, int> dic)
        {
            int total = 0;
            foreach (var item in dic)
            {
                total += item.Value;
            }
            float random = rnd.Next(0, total);

            foreach (var item in dic)
            {
                random -= item.Value;
                if (random < 0)
                {
                    return item.Key;
                }
            }
            return default(T);
        }
    }
}
