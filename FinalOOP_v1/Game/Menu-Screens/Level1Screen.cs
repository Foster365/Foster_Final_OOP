using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1Screen
    {

        float timer;
        float timetoCreate;

        int points;

        public static List<ICharacter> RenderizableObjects { get; set; } = new List<ICharacter>();

        public static List<Enemy> Enemies { get; set; } = new List<Enemy>();

        float levelTimer;

        Animation lifeStack;

        public enum Animations { lifeStack }

        Animations actualAnimstate = Animations.lifeStack;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        //public Animation Explosion { get => explosion; set => explosion = value; }

        public Level1Screen()
        {
            timer = 0;
            timetoCreate = 4f;
            levelTimer = 60;
            ResetLevel();
            AddTextures();
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

            if (timer >= timetoCreate)
            {
                CreateEnemy();
                timer = 0;
            }

            UpdateLifeStack();
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

            //if (ActualAnimstate == Animations.lifeStack)
            //    Engine.Draw(lifeStack.AnimList[lifeStack.ActualAnimationFrame], 10, 10, 0.05f, 0.05f, 0, 0, 0);

        }

        public void ResetLevel()
        {

            Engine.Clear();
            //Timer para crear enemigos
            timer += Time.DeltaTime;

            AnimationParameters();

        }

        public void CreateEnemy()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));

            Enemies.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, enemyPosition));

        }

        void UpdateLifeStack()
        {

            //for (var i = 0; i < Level1Screen.RenderizableObjects.Count; i--)
            //{
                
            //    if (_player.CurrentLife == (_player.CurrentLife - 0.2f))
            //        Level1Screen.RenderizableObjects.Remove(Level1Screen.RenderizableObjects[Level1Screen.RenderizableObjects.Count]);

            //}

        }

        public void AnimationParameters()
        {

            //List<Texture> lifeStackFrames = new List<Texture>();

            //lifeStackFrames.Add(Engine.GetTexture("Textures/Heart.png"));
            //lifeStackFrames.Add(Engine.GetTexture("Textures/Heart.png"));
            //lifeStackFrames.Add(Engine.GetTexture("Textures/Heart.png"));
            //lifeStackFrames.Add(Engine.GetTexture("Textures/Heart.png"));
            //lifeStackFrames.Add(Engine.GetTexture("Textures/Heart.png"));

            //lifeStack = new Animation(lifeStackFrames, 0.1f, false);

        }

        public void UpdateAnimation()
        {
            if (ActualAnimstate == Animations.lifeStack)
            {
                ActualAnimstate = Animations.lifeStack;
                lifeStack.Play();
            }
        }

        public void AddTextures()
        {

            RenderizableObjects.Add(new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), 50, "Textures/Player.png", 100));

            RenderizableObjects.Add(new HealthIcon(new Vector2(10, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(40, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(70, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(100, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(130, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));

        }
    }
}
