using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {

        static public List<ICharacter> Environment { get; set; } = new List<ICharacter>();
        static public List<Entity> Characters { get; set; } = new List<Entity>();

        //static public List<Bullet<PlayerBullet>> Bullets { get; set; } = new List<Bullet<PlayerBullet>>();
        //Objetos pantallas

        public static bool canPressSpace;
        public static float timerSpace;

        private static SplashScreen splashScreen;
        private static MainMenuScreen mainMenuScreen;
        private static Level1Screen level1Screen;
        private static Level2Screen level2Screen;
        private static Level3Screen level3Screen;
        private static Level4Screen level4Screen;
        private static Level5Screen level5Screen;
        private static WinScreen winScreen;
        private static GameOverScreen gameOverScreen;
        private static PauseScreen pauseScreen;

        //static readonly List<IManager> managers = new List<IManager>();
        public static float maxTimerSpace = 0.5f;

        public enum ScreenFlow { splashScreen, mainMenuScreen, level1Screen, level2Screen, level3Screen, level4Screen, level5Screen,
            winScreen, gameOverScreen, pauseScreen, Exit } //Crear clase para máquinas de estados

        static ScreenFlow actualScreenState;

        //public static bool CanPressSpace { get => canPressSpace; set => canPressSpace = true; }
        //public static float TimerSpace { get => timerSpace; set => timerSpace = value; }
        //public static float MaxTimerSpace { get => maxTimerSpace; set => maxTimerSpace = value; }

        public static ScreenFlow ActualScreenState { get => actualScreenState; set => actualScreenState = value; }

        public static SplashScreen SplashScreen { get => splashScreen; set => splashScreen = value; }
        public static MainMenuScreen MainMenuScreen { get => mainMenuScreen; set => mainMenuScreen = value; }
        public static Level1Screen Level1Screen { get => level1Screen; set => level1Screen = value; }
        public static Level2Screen Level2Screen { get => level2Screen; set => level2Screen = value; }
        public static Level3Screen Level3Screen { get => level3Screen; set => level3Screen = value; }
        public static Level4Screen Level4Screen { get => level4Screen; set => level4Screen = value; }
        public static Level5Screen Level5Screen { get => level5Screen; set => level5Screen = value; }
        public static WinScreen WinScreen { get => winScreen; set => winScreen = value; }
        public static GameOverScreen GameOverScreen { get => gameOverScreen; set => gameOverScreen = value; }
        public static PauseScreen PauseScreen { get => pauseScreen; set => pauseScreen = value; }

        //public static List<IManager> Managers => managers;

        static void Main(string[] args)
        {

            InitializeGame();
            ActualScreen();

            while (true)
            {
                TimerSpace();
                Time.DeltaTimeUpdate();
                Update();
                Render();
            }

        }

        static void TimerSpace()
        {
            timerSpace += Time.DeltaTime;
            if (timerSpace >= maxTimerSpace)
            {
                canPressSpace = true;
                timerSpace = 0f;
            }
        }

        static public void InitializeGame()
        {

            Engine.Initialize();

            SplashScreen = new SplashScreen();
            MainMenuScreen = new MainMenuScreen();
            Level1Screen = new Level1Screen();
            Level2Screen = new Level2Screen();
            Level3Screen = new Level3Screen();
            Level4Screen = new Level4Screen();
            Level5Screen = new Level5Screen();
            WinScreen = new WinScreen();
            GameOverScreen = new GameOverScreen();
            PauseScreen = new PauseScreen();


        }

        static public void ActualScreen()
        {

            actualScreenState = ScreenFlow.level1Screen;

        }

        static public void Update()
        {

            UpdateScreenFlow();
            GameManager.Instance.CheckVictory();
            GameManager.Instance.CheckDefeat();

        }

        static public void UpdateScreenFlow()
        {

            if (ActualScreenState == ScreenFlow.splashScreen)
                SplashScreen.Update();

            else if (ActualScreenState == ScreenFlow.mainMenuScreen)
                MainMenuScreen.Update();

            else if (ActualScreenState == ScreenFlow.level1Screen)
                Level1Screen.Update();

            else if (ActualScreenState == ScreenFlow.level2Screen)
                Level2Screen.Update();

            else if (ActualScreenState == ScreenFlow.level3Screen)
                Level3Screen.Update();

            else if (ActualScreenState == ScreenFlow.level4Screen)
                Level4Screen.Update();

            else if (ActualScreenState == ScreenFlow.level5Screen)
                Level5Screen.Update();

            else if (ActualScreenState == ScreenFlow.pauseScreen)
                PauseScreen.Update();

            else if (ActualScreenState == ScreenFlow.winScreen)
                WinScreen.Update();

            else if (ActualScreenState == ScreenFlow.gameOverScreen)
                GameOverScreen.Update();

            else if (ActualScreenState == ScreenFlow.Exit)
                System.Environment.Exit(1);

        }

        static public void Render()
        {
            Engine.Clear();
            ScreenFlowRender();
            Engine.Show();
        }

        static public void ScreenFlowRender()
        {

            if (ActualScreenState == ScreenFlow.splashScreen)
                SplashScreen.Render();

            else if (ActualScreenState == ScreenFlow.mainMenuScreen)
                MainMenuScreen.Render();

            else if (ActualScreenState == ScreenFlow.level1Screen)
                Level1Screen.Render();

            else if (ActualScreenState == ScreenFlow.level2Screen)
                Level2Screen.Render();

            else if (ActualScreenState == ScreenFlow.level3Screen)
                Level3Screen.Render();

            else if (ActualScreenState == ScreenFlow.level4Screen)
                Level4Screen.Render();

            else if (ActualScreenState == ScreenFlow.level5Screen)
                Level5Screen.Render();

            else if (ActualScreenState == ScreenFlow.pauseScreen)
                PauseScreen.Render();

            else if (ActualScreenState == ScreenFlow.winScreen)
                WinScreen.Render();

            else if (ActualScreenState == ScreenFlow.gameOverScreen)
                GameOverScreen.Render();

        }
    }
}