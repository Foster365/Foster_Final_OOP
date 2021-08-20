using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossEnemy : Entity
    {

        //Variables
        Pursuit pursuitBehaviour;
        ObjectsPool<PlayerBullet> poolBullets = new ObjectsPool<PlayerBullet>();

        float timerShoot;
        float timetoShoot;


        Enemy[] enemiesCollection;


        Vector2 targetPosition = new Vector2(0, 0);

        //

        public BossEnemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _maxHealth, float _angle, float _lifetime, int _damage, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _enemySpeed)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            Speed = _enemySpeed;
            timetoShoot = 0.8f;

            LifeController = new LifeController(this, true, false);

            //pursuitBehaviour = new Pursuit(Transform.Position, player.Transform.Position, Speed, 1);

        }

        public override void Update()
        {

            //Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            //if (Transform.Position.Y >= 0)
            //    Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            //if (Transform.Position.Y < 600)
            //    Transform.Position += new Vector2(0, -Speed.Y * Time.DeltaTime);

            if (!LifeController.Destroyed)
            {

                Move();

                LifeController.LifeTimer();

                //lifeTimer += Time.DeltaTime;
                //Console.WriteLine(LifeController.LifeTime);
                //if (lifeTimer >= LifeController.LifeTime)
                //    Level1Screen.RenderizableObjects.Remove(this);

                //for (int i = 0; i < Program.Bullets.Count; i++)
                //{

                //    if (circleCollider.CheckforCollisions(Program.Bullets[i]))
                //    {

                //        Level1Screen.Enemies.Remove(this);
                //        Console.WriteLine("Enemy destroyed");

                //    }
                //}

                CreateEnemies();
            }

        }

        public void Shoot()
        {
            var enemyBullet = poolBullets.Get();
            enemyBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 10, new Vector2(50, 50), 10, 4);
            //Console.WriteLine("PlayerPos.X" + Transform.Position.X + "PlayerPos.Y" + Transform.Position.Y, "bulletScale.X" + enemyBullet.Transform.Scale.X + "bulletScale.Y" + enemyBullet.Transform.Scale.Y + "bulletSize.X"
            //    + enemyBullet.Renderer.Size.X + "bulletSize.Y" + enemyBullet.Renderer.Size.Y, "bulletRotation" + enemyBullet.Transform.Rotation + "bulletTexture" + enemyBullet.Renderer.Texture);

        }

        void CreateEnemies()
        {

            float createEnemiesTimer = 0;
            float createEnemiesMaxTimer = 10f;

            Random random = new Random();

            //Vector2 enemyPos = new Vector2(random.Next(850, 800), random.Next(200, 250));

            createEnemiesMaxTimer += Time.DeltaTime;

            //foreach (Enemy e in Program.Characters)
            //{

            if (createEnemiesTimer >= createEnemiesMaxTimer)
            {
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(500, 150)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(550, 200)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(600, 250)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(750, 300)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(800, 350)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(850, 400)));
            }

            //}

        }

        void EnemiesCollection()
        { 
            foreach(Enemy e in enemiesCollection)
            {
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(0, 0)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(0, 0)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(0, 0)));
                Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(0, 0)));
            };
        }

        public override void Move()
        {

            //Vector2 dir = pursuitBehaviour.GetDir();
            for (int i = 0; i < Program.Characters.Count; i++)
            {

                if (Program.Characters[i].LifeController.IsPlayer)
                    targetPosition = Program.Characters[i].Transform.Position;
                //targetPosition = new Vector2(Program.Characters[i].Transform.Position.X, Program.Characters[i].Transform.Position.Y);

                // angle is the arctan placed in the correct quadrant of the Y difference and X difference
                //float angleOfAttack =
                //     (float)Math.Atan2((float)(targetPosition.Y - transform.Position.Y),
                //     (float)(targetPosition.X - transform.Position.X));

                //// velocity is the cos(angle*speed), sin(angle*speed)
                //Vector2 velocity =
                //     new Vector2((float)Math.Sin(angleOfAttack) * speed.X,
                //     (float)Math.Cos(angleOfAttack) * speed.Y);

                //// new position is +velocity
                //transform.Position += new Vector2(velocity.X*Time.DeltaTime, 0);
                //transform.Position += new Vector2(0, velocity.Y * Time.DeltaTime);
          

            }

        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

            }
        }

    }
}
