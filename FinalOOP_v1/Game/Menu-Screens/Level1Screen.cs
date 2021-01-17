﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1Screen
    {

        //public Enemigo enemigo;
        
        float timer;
        float timetoCreate = 0.5f;

        int points;

        public static List<IRenderizable>RenderizableObjects { get; set; } = new List<IRenderizable>();
        public static List<IUpdatable> UpdatableObjects { get; set; } = new List<IUpdatable>();

        float levelTimer;

        //Animation explosion;

        public enum Animations { explosion }

        Animations actualAnimstate = Animations.explosion;

        public Animations ActualAnimstate { get => actualAnimstate; set => actualAnimstate = value; }
        //public Animation Explosion { get => explosion; set => explosion = value; }

        public float Timer { get => timer; set => timer = 0; }
        public float TimetoCreate { get => timetoCreate; set => timetoCreate = value; }

        public Level1Screen()
        {
            timer = 0;
            timetoCreate = 0.5f;
            levelTimer = 60;
            ResetLevel();
            AddTextures();
            RenderizableObjects.Add(new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), "Textures/Player.png"));

        }

        public void Update()
        {
            //PlayerBullet playerBullet = playerBullet;
            //Aplicar temporizadores acá

            levelTimer -= Time.DeltaTime;
            //Console.WriteLine("LevelTimer" + levelTimer);
            timer += Time.DeltaTime;
            //Console.WriteLine("Enemycreator" + timer);
            CreateRenderizableObjects();
            //CreateUpdatableObjects();

            for (int i = 0; i < UpdatableObjects.Count; i++)
            {
                UpdatableObjects[i].Update();
            }

            if (timer>=timetoCreate)
            {
                CreateEnemy();
                timer = 0;
            }

            //ChequearDerrota();

            //for (int i = 0; i < RenderizableObjects.Count; i++)
            //{
            //    RenderizableObjects[i].Update();
            //}

            //UpdateAnimation();

            if (Engine.GetKey(Keys.ESCAPE))
            {
                Program.ActualScreenState = Program.ScreenFlow.pauseScreen;
            }

        }

        public void Render()
        {

            //for (var i = 0; i < Program.Bullets.Count; i++)
            //{
            //    Program.Bullets[i].Render();
            //}

            for (int j = 0; j < RenderizableObjects.Count; j++)
            {
                RenderizableObjects[j].Render();
            }

            //if (ActualAnimstate == Animations.explosion)
            //    Engine.Draw(Explosion.animFrames[Explosion.actualAnimationFrame], 200, 100, 0.5f, 0.5f, 0, 0, 0);
        }

        public void ResetLevel()
        {
            Engine.Clear();
            //Timer para crear enemigos
            Timer += Time.DeltaTime;

            //AnimationParameters();
            
        }

        public void CreateEnemy()
        {

            Random random = new Random();

            Vector2 enemyPosition = new Vector2(random.Next(600, 750), random.Next(0, 500));

            RenderizableObjects.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, enemyPosition));
            UpdatableObjects.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, enemyPosition));

        }

        public void CreateRenderizableObjects()
        {

        }

        //public void CreateUpdatableObjects()
        //{
        //    UpdatableObjects.Add(new Player(new Vector2(200, 400), new Vector2(0.15f, 0.15f), 90, new Vector2(166, 304), new Vector2(200, 200), "Textures/Player.png"));
        //}

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

        public void AddTextures()
        {
            Level1Screen.RenderizableObjects.Add(new HealthIcon(new Vector2(10, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            Level1Screen.RenderizableObjects.Add(new HealthIcon(new Vector2(30, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            Level1Screen.RenderizableObjects.Add(new HealthIcon(new Vector2(50, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));

            Level1Screen.UpdatableObjects.Add(new HealthIcon(new Vector2(50, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            Level1Screen.UpdatableObjects.Add(new HealthIcon(new Vector2(50, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));
            Level1Screen.UpdatableObjects.Add(new HealthIcon(new Vector2(50, 10), new Vector2(0.1f, 0.1f), 0, new Vector2(788, 663), "Textures/Heart.png"));

        }
    }
}
