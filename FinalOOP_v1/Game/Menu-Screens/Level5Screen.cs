using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level5Screen : Level
    {
        public override void Render()
        {
            Console.WriteLine("Render5");
        }

        public override void ResetLevel()
        {

            Console.WriteLine("ResetLevel5");
        }

        public override void Update()
        {
            Console.WriteLine("UodateLevel5");
        }
    }
}
