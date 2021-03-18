using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level3Screen : Level
    {
        public override void Render()
        {
            Console.WriteLine("Render3");
        }

        public override void ResetLevel()
        {
            Console.WriteLine("ResetLevel3");
        }

        public override void Update()
        {
            Console.WriteLine("Update3");
        }
    }
}
