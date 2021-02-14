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
        float levelMaxTimer;

        Image backgroundLevel1;

        Animation levelCountdown;

        public enum Animations { levelCountdown }

        Animations actualAnimstate = Animations.levelCountdown;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }

        //public Animation Explosion { get => explosion; set => explosion = value; }

        public Level1Screen()
        {
            timer = 0;
            timetoCreate = 4f;
            levelTimer = 0;
            levelMaxTimer = 1f;
            ResetLevel();
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

            UpdateLevelCounter();
            UpdateAnimation();

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.pauseScreen;
            }

        }

        public void Render()
        {

            backgroundLevel1.Render();

            for (int j = 0; j < RenderizableObjects.Count; j++)
            {
     
                    RenderizableObjects[j].Render();

            }

            for (int i = 0; i < Enemies.Count; i++)
            {

                Enemies[i].Render();

            }

            if (ActualAnimstate == Animations.levelCountdown)
                Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

        }

        public void ResetLevel()
        {

            Engine.Clear();
            AddTextures();
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

        void UpdateLevelCounter()
        {

            levelTimer += Time.DeltaTime;

            if (levelTimer >= levelMaxTimer) /*Console.WriteLine("Game over!");*/
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;

        }

        public void AnimationParameters()
        {

            List<Texture> lifeStackFrames = new List<Texture>();

            for (int i = 60; i >= 0; i--)
            {

                lifeStackFrames.Add(Engine.GetTexture("Textures/Countdown/" + i.ToString() + ".png"));

            }

            levelCountdown = new Animation(lifeStackFrames, 1f, false);

        }

        public void UpdateAnimation()
        {
            if (ActualAnimstate == Animations.levelCountdown)
            {
                ActualAnimstate = Animations.levelCountdown;
                levelCountdown.Play();
            }

        }

        public void AddTextures()
        {

            backgroundLevel1 = new Image(new Vector2(0, 150), new Vector2(.8f, .8f), new Vector2(1920, 1200), 0, "Textures/Level1Background.jpg");

            RenderizableObjects.Add(new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), 50, "Textures/Player.png", 100));

            RenderizableObjects.Add(new HealthIcon(new Vector2(10, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(40, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(70, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(100, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            RenderizableObjects.Add(new HealthIcon(new Vector2(130, 10), new Vector2(0.03f, 0.03f), 0, new Vector2(788, 663), "Textures/Heart.png"));

        }
    }
}
