using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level2Screen : Level
    {
        public override void Render()
        {
            Console.WriteLine("Render2");
        }

        public override void ResetLevel()
        {
            Console.WriteLine("ResetLevel2");
        }

        public override void Update()
        {
            Console.WriteLine("UpdateLevel2");
        }
    }
}
