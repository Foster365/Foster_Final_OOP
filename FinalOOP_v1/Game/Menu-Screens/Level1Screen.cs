using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1Screen : Level
    {

        float enemySpawnerTimer = 0;
        float timetoCreate = 4f ;

        float asteroidTimer = 0;
        float asteroidSpawnTime = 5f;

        float levelTimer = 0;
        float levelMaxTimer = 60;

        Animation levelCountdown;

        public enum Animations { levelCountdown }

        Animations actualAnimstate = Animations.levelCountdown;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        //public Animation Explosion { get => explosion; set => explosion = value; }

        public Level1Screen() : base()
        {

            GameManager.Instance.EnemyKills = 0;

        }

        public override void Update()
        {

            levelTimer -= Time.DeltaTime;

            for(int i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Update();

            }

            //for (int i = 0; i < Program.Environment.Count; i++)
            //{

            //    Program.Environment[i].Update();

            //}

        }

        public override void Render()
        {

            //for (int j = 0; j < Program.Environment.Count; j++)
            //{

            //    Program.Environment[j].Render();

            //}

            for (var i = 0; i < Program.Characters.Count; i++ )
            {

                Program.Characters[i].Render();

            }

            //if (ActualAnimstate == Animations.levelCountdown)
            //    Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

        }

        public override void ResetLevel()
        {

            //Environment_Textures();
            CreateCharacters();
            EnemySpawn();
            //CreateAsteroid();
            //UpdateAnimation();
            //AnimationParameters();

        }

        void EnemySpawn()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));


            enemySpawnerTimer += Time.DeltaTime;

            Console.WriteLine("Enemy timer" + enemySpawnerTimer);

            if (enemySpawnerTimer >= timetoCreate)
            {

                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, enemyPosition));
                enemySpawnerTimer = 0;

            }

        }

        void CreateAsteroid()
        {

            asteroidTimer += Time.DeltaTime;
            //Console.WriteLine("Asteroid timer" + asteroidTimer);

            Random random = new Random();

            Vector2 asteroidPosition = new Vector2(random.Next(800, 850), random.Next(0, 150));

            if (asteroidTimer >= asteroidSpawnTime)
            {
                Program.Environment.Add(AsteroidsFactory.CreateAsteroid(AsteroidsFactory.AsteroidFactory.asteroid1, asteroidPosition));
                asteroidTimer = 0;
            }

        }

        void UpdateLevelCounter()
        {

            levelTimer += Time.DeltaTime;

            if (levelTimer >= levelMaxTimer) /*Console.WriteLine("Game over!");*/
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;

        }

        public void AnimationParameters()
        {

            List<Texture> countdownFrames = new List<Texture>();

            for (int i = 60; i >= 0; i--)
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

            Program.Characters.Add(new Player(new Vector2(400, 400), new Vector2(0.15f, 0.15f), 0, new Vector2(166, 304), new Vector2(100, 100), 80, "Textures/Entities/Characters/Player.png", 10, 10));


        }

        void Environment_Textures()
        {

            Program.Environment.Add(new HealthIcon(new Vector2(10, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(40, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(70, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(100, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(130, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));

            Program.Environment.Add(new Image(new Vector2(0, 150), new Vector2(.8f, .8f), new Vector2(1920, 1200), 0, "Textures/Level1Background.jpg"));

        }

        //public void NextLevel()
        //{

        //    if (GameManager.Instance.EnemyKills == 10)
        //    {

        //        Program.ActualScreenState = Program.ScreenFlow.level2Screen;
        //        Engine.Clear();

        //    }

        //}

    }
}
