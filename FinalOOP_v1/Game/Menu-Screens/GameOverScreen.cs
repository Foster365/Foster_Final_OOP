using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOverScreen
    {
        Image backgroundGameOverScreen;

        Button backButton;
        Button actualButton;
        

        public GameOverScreen()
        {
            backgroundGameOverScreen = new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png");

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

            backgroundGameOverScreen.Render();

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
