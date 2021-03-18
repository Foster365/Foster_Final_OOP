using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IManager
    {
        void Start();
        void Execute();
        void Destroy();
    }
}
