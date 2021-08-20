using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOverScreen:Screen
    {

        Button backButton;
        Button actualButton;

        public GameOverScreen():base()
        {

            ResetLevel();

        }

        public override void Update()
        {

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }

        }

        public override void Render()
        {
            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Render();
                Console.WriteLine("Rendering Game Over Sxreen");
            }

        }

        void EnterButon()
        {
            if (actualButton == backButton)
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }

        public override void ResetLevel()
        {
            Engine.Clear();
            AddTextures();
        }

        void AddTextures()
        {

            if (Program.ActualScreenState == Program.ScreenFlow.gameOverScreen)
            {

                Program.Environment.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));
                Program.Environment.Add(new Image(new Vector2(200, 100), new Vector2(.6f, .6f), new Vector2(448, 56), 0, "Textures/ScreenFlow/Game_Over.png"));

            }

        }
    }
}
