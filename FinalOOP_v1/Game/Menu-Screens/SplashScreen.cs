using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SplashScreen:GameScreen
    {

        Arrow arrow;
        Button playBtn;
        Button actualBtn;

        Image background;

        Renderer renderer;
        Transform transform;

        public SplashScreen():base()
        {

            playBtn.SetButtons(null, playBtn);
            playBtn.SetButtons(playBtn, null);

            actualBtn = playBtn;

            arrow = new Arrow(actualBtn.Transform.Position, new Vector2(1, 1), 0, new Vector2(55, 108), "Textures/ScreenFlow/Select.png", 60);
            arrow.Update();

        }

        protected override void AddImages()
        {

            Images.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));

        }

        protected override void AddbButtons()
        {

            playBtn = new Button("Textures/ScreenFlow/TextPlay.png", new Vector2(300f, 400f), new Vector2(1f, 1f), new Vector2(155, 80));
            Buttons.Add(playBtn);

        }

        public override void Update()
        {
            actualBtn = actualBtn.Update();
            if (Engine.GetKey(Keys.SPACE) && Program.canPressSpace)
            {
                Program. canPressSpace= false;
                Program.timerSpace = 0f;
                EnterButton();//MMenuS
                arrow.Update();

            }
        }

        public override void Render()
        {

            foreach (var image in Images)
            {
                image.Render();
            }

            foreach (var boton in Buttons)
            {
                boton.Render();
            }
        }

        private void EnterButton()
        {
            if (actualBtn == playBtn)
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }
    }
}
