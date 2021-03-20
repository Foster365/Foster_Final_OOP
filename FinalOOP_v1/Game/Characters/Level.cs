﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Level
    {

        public Level()
        {

            Engine.Clear();
            ResetLevel();
            Console.Write("Level" + this);

        }

        public abstract void ResetLevel();
        public abstract void Update();
        public abstract void Render();

    }
}
