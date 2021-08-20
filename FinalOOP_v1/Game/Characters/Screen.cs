using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Screen
    {

        public Screen()
        {

            ResetLevel();
            Console.Write("Level" + this);
        }

        //public Screen(float _maxLevelTimer)
        //{
        //    maxLevelTimer = _maxLevelTimer;
        //    Engine.Clear();
        //    ResetLevel();
        //    Console.Write("Level" + this);

        //}

        public abstract void ResetLevel();
        public abstract void Update();
        public abstract void Render();
        public virtual void CleanAllElements()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                if (!Program.Characters[i].LifeController.IsPlayer)
                    Program.Characters.Remove(Program.Characters[i]);

            }

            Program.Environment.Clear();
            Program.Characters.Clear();/*RemoveRange(0, Program.Characters.Count);*/
        }

    }
}
