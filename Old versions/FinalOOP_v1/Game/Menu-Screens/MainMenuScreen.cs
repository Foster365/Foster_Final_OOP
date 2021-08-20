using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenuScreen:GameScreen
    {
        Arrow arrow;
    
        Button newGameButton;
        Button exitButton;
        Button actualButton;
        //List<Button> buttons;
        //List<Image> images;

        //Vectores Backg
        public Vector2 Position { get; set; } = new Vector2(200, 455);
        public Vector2 Dimensions { get; set; } = new Vector2(509f, 339f);
        public Vector2 Scale { get; set; } = new Vector2(2f, 2f);

        //
        public Vector2 TextPosition { get; set; } = new Vector2(10, 10);
        public Vector2 TextScale { get; set; } = new Vector2(1.5f, 1.5f);
        //public List<Button> Buttons { get =>  buttons; set => buttons = new List<Button>(); }
        //public List<Image> Images { get => images; set => images = new List<Image>(); }

        public MainMenuScreen()
        {

            AddImages();
            AddbButtons();

            //Engine.Draw("Textures/ScreenFlow/TextMMenu.png", 100, 100, 0.8f, 0.8f);

            // Inicializo los Botones pasandoles la posicion y la textura
            //loadGameButton = new Button("Textures/ScreenFlow/TextLG.png", new Vector2(200f, 200f), new Vector2(0.5f, 0.5f), new Vector2(400, 240));
            //Buttons.Add(loadGameButton);

            newGameButton.SetButtons(null, exitButton);
            exitButton.SetButtons(newGameButton, null);

            actualButton = newGameButton;

            arrow = new Arrow(actualButton.Transform.Position, new Vector2(1, 1), 0, new Vector2(55, 108), "Textures/ScreenFlow/Select.png", 60);
            arrow.Update();
        }

        public override void Update()
        {

            actualButton = actualButton.Update();

            arrow.Update();

            if (Engine.GetKey(Keys.SPACE) && Program.canPressSpace)
            {

                Program.canPressSpace = false;
                Program.timerSpace = 0f;
                EnterButton();

            }

        }

        public override void Render()
        {

            arrow.Render();

            for (int i = 0; i < Images.Count; i++)
            {

                Images[i].Render();

            }

            // Dibujo los Botones
            foreach (var button in Buttons)
            {
                button.Render();
            }

            // Dibujo la flecha
        }

        protected override void AddImages()
        {

            Images.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));

        }

        protected override void AddbButtons()
        {

            newGameButton = new Button("Textures/ScreenFlow/TextNG.png", new Vector2(200f, 200f), new Vector2(0.5f, 0.5f), new Vector2(331, 71));
            Buttons.Add(newGameButton);

            exitButton = new Button("Textures/ScreenFlow/TextEx.png", new Vector2(230f, 400f), new Vector2(0.5f, 0.5f), new Vector2(96, 39));
            Buttons.Add(exitButton);

        }

        private void EnterButton()
        {
            if (actualButton == newGameButton)
            {
                Program.ActualScreenState = Program.ScreenFlow.level1Screen;
                ////Program.Level1Screen.ResetLevel();
            }
            //else if (actualButton == loadGameButton)
            //{
            //    Program.ActualScreenState = Program.ScreenFlow.level1Screen;
            //    //Estado de nivel
            //}
            else if (actualButton == exitButton)
                Program.ActualScreenState = Program.ScreenFlow.Exit;
        }
      
    }
}
