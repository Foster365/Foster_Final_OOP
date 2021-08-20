using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level4Screen : Screen
    {
        public override void Render()
        {
            Console.WriteLine("Render4");
        }

        public override void ResetLevel()
        {
            Console.WriteLine("ResetLevel4");
        }

        public override void Update()
        {
            Console.WriteLine("Update4");
        }
    }
}
