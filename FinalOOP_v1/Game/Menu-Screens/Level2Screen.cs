using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level2Screen
    {
        //public Enemigo enemigo;
        public Player player;

        //Variables creación de enemies
        float timer = 0;
        float timetoCreate = 0.5f;
        //
        //Lista de enemigos
        public static List<Enemy> EnemiesLevel2 { get; set; } = new List<Enemy>();

        //Animation explosion;

        float levelTimer;
        float levelTime;

        public enum Animations { explosion }

        Animations actualAnimstate = Animations.explosion;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }
        //public Animation Explosion { get => explosion; set => explosion = value; }

        public float Timer { get => timer; set => timer = 0; }
        public float TimetoCreate { get => timetoCreate; set => timetoCreate = value; }

        public Level2Screen()
        {
            timer = 0;
            levelTimer = 60;
            levelTime = 0;
            ResetLevel();
        }

        public void Update()
        {
            levelTimer=
            Timer += Time.DeltaTime;
            //ChequearDerrota();

            //enemigo.Actualizar();

            for (int i = 0; i < EnemiesLevel2.Count; i++)
            {
                EnemiesLevel2[i].Update();
            }

            //UpdateAnimation();

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }

        public void Render()
        {

            for (int j = 0; j < EnemiesLevel2.Count; j++)
            {
                EnemiesLevel2[j].Render();
            }

            //if (ActualAnimstate == Animations.explosion)
            //    Engine.Draw(Explosion.animFrames[Explosion.actualAnimationFrame], 200, 100, 0.5f, 0.5f, 0, 0, 0);
        }

        public void ResetLevel()
        {
            levelTimer = 0;
            timer = 0;

            //player = new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), 50, "Textures/Player.png");
            //AnimationParameters();

            CreateEnemy();

        }

        public void CreateEnemy()
        {
            
            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));

            EnemiesLevel2.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, enemyPosition));

        }

        //public void AnimationParameters()
        //{

        //    List<Texture> explosionFrames = new List<Texture>();

        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion1.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion2.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion3.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion4.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion5.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion6.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion7.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion8.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion9.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion10.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion11.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion12.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion13.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion14.png"));
        //    explosionFrames.Add(Engine.GetTexture("Textures/Animations/Explosion/Explosion15.png"));

        //    Explosion = new Animation(explosionFrames, true, 0.1f);

        //}

        //public void UpdateAnimation()
        //{
        //    if (ActualAnimstate == Animations.explosion)
        //    {
        //        ActualAnimstate = Animations.explosion;
        //        Explosion.Play();
        //    }
        //}
    }
}
