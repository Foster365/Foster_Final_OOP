using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level2Screen : Screen
    {

        float enemySpawnerTimer = 0;
        float timetoCreate = 2f;

        float asteroidTimer = 0;
        float asteroidSpawnTime = 4f;

        float levelTimer = 0;
        float maxLevelTimer = 50;

        Animation levelCountdown;
        Animation deathAnimation;

        public enum Animations { levelCountdown, deathAnimation }

        Animations actualAnimstate = Animations.levelCountdown;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        public Level2Screen() : base()
        {

            Console.WriteLine("Level 2");
            //CleanAllElements();
            GameManager.Instance.EnemyKills = 0;
            //Program.Environment.Add(new Image(new Vector2(0, 0), new Vector2(1, 1), new Vector2(2560, 1080), 0, "Textures/Level_Backgrounds/Level_1.jpg"));

            //ResetLevel();

        }

        public override void Update()
        {

            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Update();

            }

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Update();

            }
            LevelCounter();
            EnemySpawn();
            CreateAsteroid();
            CheckPlayerLife();
            UpdateAnimation();
            //NextLevel();

        }

        public override void Render()
        {

            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Render();

            }

            for (var i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Render();

            }

            for (int i = 0; i < LifeStack.Count; i++)
            {
                LifeStack[i].Render();
            }

            if (ActualAnimstate == Animations.levelCountdown)
                Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);


        }

        void LevelCounter()
        {

            levelTimer += Time.DeltaTime;

            if (levelTimer >= maxLevelTimer)
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;

        }


        public override void ResetLevel()
        {

            Environment_Textures();
            CreateCharacters();
            AnimationParameters();
            //CreateLifeStack(5, "Textures/Heart.png");

        }

        void EnemySpawn()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));


            enemySpawnerTimer += Time.DeltaTime;

            if (enemySpawnerTimer >= timetoCreate)
            {

                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, enemyPosition));
                enemySpawnerTimer = 0;

            }

        }

        void CreateAsteroid()
        {

            asteroidTimer += Time.DeltaTime;

            Random random = new Random();

            Vector2 asteroidPosition = new Vector2(random.Next(800, 850), random.Next(0, 600));

            if (asteroidTimer >= asteroidSpawnTime)
            {

                Program.Characters.Add(AsteroidsFactory.CreateAsteroid(AsteroidsFactory.AsteroidFactory.asteroid1, asteroidPosition));
                Program.Characters.Add(AsteroidsFactory.CreateAsteroid(AsteroidsFactory.AsteroidFactory.asteroid2, asteroidPosition));
                asteroidTimer = 0;

            }

        }

        public void AnimationParameters()
        {

            List<Texture> countdownFrames = new List<Texture>();

            for (int i = 60; i >= 1; i--)
            {

                countdownFrames.Add(Engine.GetTexture("Textures/Countdown/" + i.ToString() + ".png"));

            }

            levelCountdown = new Animation(countdownFrames, 1f, false);

        }

        public void UpdateAnimation()
        {

            if (ActualAnimstate == Animations.levelCountdown)
            {
                ActualAnimstate = Animations.levelCountdown;
                levelCountdown.Play();
            }

        }

        void CreateCharacters()
        {

        }

        void Environment_Textures()
        {

            Program.Environment.Add(new Image(new Vector2(0, 150), new Vector2(1, 1), new Vector2(1200, 600), 0, "Textures/Level_Backgrounds/Level_2.jpg"));
        }

        public void NextLevel()
        {

            if (GameManager.Instance.EnemyKills >= 1)
            {

                //Program.ActualScreenState = Program.ScreenFlow.level3Screen;
                //CleanAllElements();

            }

        }

    }
}
