using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1Screen : Screen
    {

        float enemySpawnerTimer = 0;
        float timetoCreate = 4f;

        float asteroidTimer = 0;
        float asteroidSpawnTime = 5f;

        float levelTimer = 0;
        float maxLevelTimer = 60;

        Animation levelCountdown;
        Animation deathAnimation;

        public enum Animations { levelCountdown, deathAnimation}

        Animations actualAnimstate = Animations.levelCountdown;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        public Level1Screen() : base()
        {

            GameManager.Instance.EnemyKills = 0;

        }

        public override void Update()
        {

            for (int i = 0; i < Program.Environment.Count; i++)
            {

                Program.Environment[i].Update();

            }

            for(int i = 0; i < Program.Characters.Count; i++)
            {

                Program.Characters[i].Update();

            }
            LevelCounter();
            EnemySpawn();
            CreateAsteroid();
            CheckPlayerLife();
            //UpdateAnimation();
            NextLevel();

        }

        public override void Render()
        {

            for (int j = 0; j < Program.Environment.Count; j++)
            {

                Program.Environment[j].Render();

            }

            for (var i = 0; i < Program.Characters.Count; i++ )
            {

                Program.Characters[i].Render();

            }

            for (int i = 0; i < LifeStack.Count; i++)
            {
                LifeStack[i].Render();
            }

            if (ActualAnimstate == Animations.levelCountdown)
                Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

            if (actualAnimstate == Animations.deathAnimation)
            {

                Engine.Draw(deathAnimation.AnimList[deathAnimation.ActualAnimationFrame], 300, 100, 3, 3, 0, 0, 0);
                //Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

            }

        }

        void LevelCounter()
        {

            levelTimer += Time.DeltaTime;
            //Console.WriteLine(levelTimer);

            if (levelTimer >= maxLevelTimer)
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;

        }


        public override void ResetLevel()
        {

            Environment_Textures();
            CreateCharacters();
            AnimationParameters();
            CreateLifeStack(5, "Textures/Heart.png");

        }

        void EnemySpawn()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));


            enemySpawnerTimer += Time.DeltaTime;

            if (enemySpawnerTimer >= timetoCreate)
            {

                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, enemyPosition));
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

            List<Texture> deathFrames = new List<Texture>();

            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion1.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion2.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion3.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion4.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion5.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion6.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion7.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion8.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion9.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion10.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion11.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion12.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion13.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion14.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion15.png"));

            //for (int i = 1; i < 15; i++)
            //{

            //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/" + i.ToString() + ".png"));

            //}

            deathAnimation = new Animation(deathFrames, .05f, false);

        }

        public void UpdateAnimation()
        {

            if (ActualAnimstate == Animations.levelCountdown)
            {
                ActualAnimstate = Animations.levelCountdown;
                levelCountdown.Play();
            }
            if (actualAnimstate == Animations.deathAnimation)
            {

                actualAnimstate = Animations.deathAnimation;
                deathAnimation.Play();

            }

        }

        //void AnimationParameters()
        //{

        //    List<Texture> deathFrames = new List<Texture>();

        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion1.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion2.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion3.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion4.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion5.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion6.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion7.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion8.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion9.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion10.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion11.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion12.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion13.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion14.png"));
        //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion15.png"));

        //    //for (int i = 1; i < 15; i++)
        //    //{

        //    //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/" + i.ToString() + ".png"));

        //    //}

        //    deathAnimation = new Animation(deathFrames, .05f, false);

        //}

        void CreateCharacters()
        {

            Program.Characters.Add(new Player(new Vector2(400, 400), new Vector2(0.15f, 0.15f), 0, new Vector2(166, 304), new Vector2(300, 300), 100, "Textures/Entities/Characters/Player.png", 10, 10));

        }

        void Environment_Textures()
        {

            Program.Environment.Add(new Image(new Vector2(0, 150), new Vector2(.8f, .8f), new Vector2(1920, 1200), 0, "Textures/Level_Backgrounds/Level1Background.jpg"));

            //Program.Environment.Add(new HealthIcon(new Vector2(10, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            //Program.Environment.Add(new HealthIcon(new Vector2(60, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            //Program.Environment.Add(new HealthIcon(new Vector2(110, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            //Program.Environment.Add(new HealthIcon(new Vector2(160, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            //Program.Environment.Add(new HealthIcon(new Vector2(210, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));

        }

        public void NextLevel()
        {

            if (GameManager.Instance.EnemyKills == 10)
            {

                Program.ActualScreenState = Program.ScreenFlow.level2Screen;
                CleanAllElements();

            }

        }

        //public void UpdateAnimation()
        //{
        //    if (actualAnimstate == Animations.deathAnimation)
        //    {

        //        actualAnimstate = Animations.deathAnimation;
        //        deathAnimation.Play();

        //    }

        //}

        //public void RenderAnimation()
        //{

        //    if (actualAnimstate == Animations.deathAnimation)
        //    {

        //        Engine.Draw(deathAnimation.AnimList[deathAnimation.ActualAnimationFrame], 300, 100, 3, 3, 0, 0, 0);
        //        //Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

        //    }

        //}
    }
}
