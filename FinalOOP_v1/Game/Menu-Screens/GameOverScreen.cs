using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOverScreen
    {
        Background backgroundGameOverScreen;

        Button backButton;
        Button actualButton;
        

        public GameOverScreen()
        {
            backgroundGameOverScreen = new Background(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png");

        }

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }

        public void Render()
        {

            backgroundGameOverScreen.Draw();

        }
        private void EnterButon()
        {
            if (actualButton == backButton)
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }
    }
}
