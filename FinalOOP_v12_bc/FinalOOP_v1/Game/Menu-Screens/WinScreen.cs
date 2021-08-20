using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WinScreen : Screen
    {

        public WinScreen()
        {

            ResetLevel();

        }

        public override void ResetLevel()
        {
            Engine.Clear();
            AddTextures();
        }

        void AddTextures()
        {
            if(Program.ActualScreenState == Program.ScreenFlow.winScreen)
            {

                Program.Environment.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));
                Program.Environment.Add(new Image(new Vector2(300, 100), new Vector2(1, 1), new Vector2(238, 84), 0, "Textures/ScreenFlow/Win.png"));

            }

        }

        public override void Update()
        {

        }

        public override void Render()
        {
            RenderTextures();
        }

        void RenderTextures()
        {
            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Render();

            }
        }
    }
}
