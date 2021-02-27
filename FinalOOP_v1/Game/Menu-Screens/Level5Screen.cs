using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level5Screen
    {
        float timer;
        float timetoCreate;

        int points;

        public static List<ICharacter> RenderizableObjects { get; set; } = new List<ICharacter>();

        public static List<Enemy> Enemies { get; set; } = new List<Enemy>();

        float levelTimer;

        Animation levelCountdown;

        public enum Animations { levelTimer }

        Animations actualAnimstate = Animations.levelTimer;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = Animations.levelTimer; }

        public Animation LevelCountdown { get => levelCountdown; set => levelCountdown = value; }

        public Level5Screen()
        {
            timer = 0;
            //timetoCreate = 4f;
            levelTimer = 60;
            ResetLevel();
            //AddTextures();
        }

        public void Update()
        {

            levelTimer -= Time.DeltaTime;
            //Console.WriteLine("LevelTimer" + levelTimer);
            timer += Time.DeltaTime;

            for (int i = 0; i < RenderizableObjects.Count; i++)
            {
                for (int j = 0; j < Enemies.Count; j++)
                {
                    Enemies[j].Update();
                }

                RenderizableObjects[i].Update();
            }

            //if (timer >= timetoCreate)
            //{
            //    timer = 0;
            //}

            //UpdateLifeStack();
            //UpdateAnimation();

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.pauseScreen;
            }

        }

        public void Render()
        {

            for (int j = 0; j < RenderizableObjects.Count; j++)
            {
                for (int i = 0; i < Enemies.Count; i++)
                {

                    RenderizableObjects[j].Render();
                    Enemies[i].Render();

                }
            }

            //if (actualAnimstate == Animations.levelTimer)
            //    Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 10, 550, 0.05f, 0.05f, 0, 0, 0);

        }

        public void ResetLevel()
        {

            Engine.Clear();
            //Timer para crear enemigos
            //timer += Time.DeltaTime;

            CreateEnemy();

            //AnimationParameters();

        }

        public void CreateEnemy()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 900), random.Next(0, 500));

            Enemies.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.finalBossEnemy, enemyPosition));

        }


        public void AnimationParameters()
        {

            List<Texture> levelCountdownFrames = new List<Texture>();

            for (int i = 30; i > 0; i--)
            {

                levelCountdownFrames.Add(Engine.GetTexture("Textures/Countdown/" + i.ToString() + ".png"));

            }

            levelCountdown = new Animation(levelCountdownFrames, 1f, false);

        }

        public void UpdateAnimation()
        {

            if (actualAnimstate == Animations.levelTimer)
            {
                actualAnimstate = Animations.levelTimer;
                levelCountdown.Play();
            }
            
        }

        public void AddTextures()
        {

            RenderizableObjects.Add(new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), 50, "Textures/Player.png", 10, 10));

            RenderizableObjects.Add(new HealthIcon(new Vector2(10, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(40, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(70, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(100, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(130, 10), new Vector2(0.03f, 0.03f), new Vector2(788, 663), 0, "Textures/Heart.png"));

        }
    }
}
