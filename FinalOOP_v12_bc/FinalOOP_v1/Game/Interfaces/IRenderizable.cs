﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IRenderizable
    {
        Renderer Renderer { get; set; }
        void Render();
    }
}
