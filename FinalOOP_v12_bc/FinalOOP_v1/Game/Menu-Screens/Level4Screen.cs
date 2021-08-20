using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level4Screen : Screen
    {

        float enemySpawnerTimer = 0;
        float timetoCreate = 3f;

        float asteroidTimer = 0;
        float asteroidSpawnTime = 2.5f;

        float levelTimer = 0;
        float maxLevelTimer = 50;

        Animation levelCountdown;

        public enum Animations { levelCountdown }

        Animations actualAnimstate = Animations.levelCountdown;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        public Level4Screen() : base()
        {

            GameManager.Instance.EnemyKills = 0;
            ResetLevel();

        }

        public override void Update()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Update();

            }

            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Update();

            }

            //LevelCounter();
            EnemySpawn();
            CreateAsteroid();
            UpdateAnimation();
            NextLevel();

        }

        public override void Render()
        {

            for (int j = 0; j < Program.Environment.Count; j++)
            {

                Program.Environment[j].Render();

            }

            for (var i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Render();

            }

            //if (ActualAnimstate == Animations.levelCountdown)
            //    Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

        }

        void LevelCounter()
        {

            levelTimer += Time.DeltaTime;
            Console.WriteLine(levelTimer);

            if (levelTimer >= maxLevelTimer)
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;

        }


        public override void ResetLevel()
        {

            if (Program.ActualScreenState == Program.ScreenFlow.level4Screen)
            {

                //Environment_Textures();
                AnimationParameters();
                CreateCharacters();

            }

        }

        void EnemySpawn()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));


            enemySpawnerTimer += Time.DeltaTime;

            if (enemySpawnerTimer >= timetoCreate)
            {

                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, enemyPosition));

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

                Program.Environment.Add(AsteroidsFactory.CreateAsteroid(AsteroidsFactory.AsteroidFactory.asteroid4, asteroidPosition));
                asteroidTimer = 0;

            }

        }

        public void AnimationParameters()
        {

            List<Texture> countdownFrames = new List<Texture>();

            for (int i = 50; i >= 1; i--)
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

            Program.Environment.Add(new Image(new Vector2(0, 0), new Vector2(.8f, .8f), new Vector2(2048, 1152), 0, "Textures/Level_Backgrounds/Level_4.jpg"));

        }

        public void NextLevel()
        {

            if (GameManager.Instance.EnemyKills >= 10)
            {

                Program.ActualScreenState = Program.ScreenFlow.level5Screen;

            }

        }

    }
}

