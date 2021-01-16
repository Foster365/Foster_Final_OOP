using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SplashScreen
    {

        Arrow arrow;
        Button playBtn;
        Button actualBtn;

        Background background;

        Renderer renderer;
        Transform transform;
        List<Button> buttons = new List<Button>();

        Vector2 position;
        Vector2 scale;
        float rotation;

        string texture;
        Vector2 size;
        
        public Vector2 Position { get => position; set => position = new Vector2(200,455); }
        public Vector2 Scale { get => scale; set => scale = new Vector2(1,1); }
        public float Rotation { get => rotation; set => rotation = value; }
        
        public string Texture { get => texture; set => texture = value; }
        public Vector2 Size { get => size; set => size = new Vector2(1920,1080); }

        public SplashScreen()
        {
            background = new Background(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png");
            playBtn = new Button("Textures/ScreenFlow/TextPlay.png", new Vector2(300f, 400f), new Vector2(1f, 1f), new Vector2(166, 87));
            buttons.Add(playBtn);


            playBtn.SetButtons(null, playBtn);
            playBtn.SetButtons(playBtn, null);

            actualBtn = playBtn;

            arrow = new Arrow();
            arrow.Update(new Vector2(actualBtn.Transform.Position.X, actualBtn.Transform.Position.Y));

        }

        public void Update()
        {
            actualBtn = actualBtn.Update();
            arrow.Update(new Vector2(actualBtn.Transform.Position.X, actualBtn.Transform.Position.Y));

            if (Engine.GetKey(Keys.SPACE) && Program.canPressSpace)
            {
                Program. canPressSpace= false;
                Program.timerSpace = 0f;
                EnterButton();//MMenuS
            }
        }

        public void Render()
        {

            background.Draw();

            foreach (var boton in buttons)
            {
                boton.Draw();
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
