using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenuScreen
    {
        Arrow arrow;
        Button newGameButton;
        Button exitButton;
        Button actualButton;
        List<Button> buttons = new List<Button>();

        Image mainMenuBackground;

        //Vectores Backg
        public Vector2 Position { get; set; } = new Vector2(200, 455);
        public Vector2 Dimensions { get; set; } = new Vector2(509f, 339f);
        public Vector2 Scale { get; set; } = new Vector2(2f, 2f);

        //
        public Vector2 TextPosition { get; set; } = new Vector2(10, 10);
        public Vector2 TextScale { get; set; } = new Vector2(1.5f, 1.5f);
        public List<Button> Buttons { get; set; } = new List<Button>();

        public MainMenuScreen()
        {

            //Background
            mainMenuBackground = new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png");

            //// Dibujo el fondo

            Engine.Draw("Textures/ScreenFlow/TextMMenu.png", 100, 100, 0.8f, 0.8f);

            // Inicializo los Botones pasandoles la posicion y la textura
            newGameButton = new Button("Textures/ScreenFlow/TextNG.png", new Vector2(200f, 100f), new Vector2(0.5f, 0.5f), new Vector2(400, 240));
            Buttons.Add(newGameButton);

            //loadGameButton = new Button("Textures/ScreenFlow/TextLG.png", new Vector2(200f, 200f), new Vector2(0.5f, 0.5f), new Vector2(400, 240));
            //Buttons.Add(loadGameButton);
            
            exitButton = new Button("Textures/ScreenFlow/TextEx.png", new Vector2(200f, 400f), new Vector2(0.5f, 0.5f), new Vector2(129, 212));
            Buttons.Add(exitButton);


            newGameButton.SetButtons(null, exitButton);
            exitButton.SetButtons(newGameButton, null);

            actualButton = newGameButton;

            arrow = new Arrow();
            arrow.Update(new Vector2(actualButton.Transform.Position.X, actualButton.Transform.Position.Y));
        }

        public void Update()
        {

            actualButton = actualButton.Update();


            arrow.Update(new Vector2(actualButton.Transform.Position.X, actualButton.Transform.Position.Y));


            if (Engine.GetKey(Keys.SPACE) && Program.canPressSpace)
            {
                Program.canPressSpace = false;
                Program.timerSpace = 0f;
                EnterButton();
            }
        }

        public void Render()
        {

            mainMenuBackground.Render();

            // Dibujo los Botones
            foreach (var button in Buttons)
            {
                button.Draw();
            }

            // Dibujo la flecha
            arrow.Draw();
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
