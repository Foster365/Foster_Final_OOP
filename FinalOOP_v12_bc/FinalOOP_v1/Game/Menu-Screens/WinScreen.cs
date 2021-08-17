using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WinScreen
    {

        public WinScreen()
        {

            ResetScreen();

        }

        void ResetScreen()
        {
            Engine.Clear();
            AddTextures();
        }

        void AddTextures()
        {

            //Program.Renderizable.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));
            //Program.Renderizable.Add(new Image(new Vector2(300, 100), new Vector2(1, 1), new Vector2(238, 84), 0, "Textures/ScreenFlow/Win.png"));

        }

        public void Update()
        {

        }

        public void Render()
        {
            //for(int i = 0; i<Program.Renderizable.Count; i++)
            //{

            //    Program.Renderizable[i].Render();

            //}
        }
    }
}
