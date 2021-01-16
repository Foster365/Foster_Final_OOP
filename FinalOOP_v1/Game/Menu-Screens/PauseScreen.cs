using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PauseScreen
    {
        Button backButton;
        Button actualButton;

        Background backgroundPauseScreen;
        
        //
        public Vector2 TextPosition { get; set; } = new Vector2(300, 200);
        public Vector2 TextScale { get; set; } = new Vector2(0.15f, 0.15f);

        public PauseScreen()
        {
            backgroundPauseScreen = new Background(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png");
        }

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.level1Screen;
            }
            
        }

        public void Render()
        {
            backgroundPauseScreen.Draw();

            Engine.Draw("Textures/ScreenFlow/PauseB.png", TextPosition.X, TextPosition.Y, TextScale.X, TextScale.Y);
        }

    }
}

