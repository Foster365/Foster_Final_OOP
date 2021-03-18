using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : Entity, /* EnemyAbs, */ICharacter //Clase abstracta de la cual heredan los enemigos. overraid en update (Aplico las trayectorias como en los métodos)
    {
        //Variables

        Vector2 position;

        float lifeTimer = 0;

        //ObjectsPool<EnemyBullet> bulletsPool;

        float timerShoot;
        float timetoShoot;

        ////

        ////Encapsuladas
        //public Vector2 EnemyPosition { get => enemyPosition; set => enemyPosition = value; }
        //public Vector2 EnemySpeed { get => enemySpeed; set => enemySpeed = value; }

        //public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        //public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }
        //public float Angle { get => angle; set => angle = value; }

        //

        public Enemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _maxHealth, float _angle, float _lifetime, int _damage, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _enemySpeed)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            Speed = _enemySpeed;
            timetoShoot = 0.8f;

            LifeController = new LifeController(_maxHealth, _lifetime, this, true, false);
                
        }

        public override void Update()//Ver bien esto
        {
            if (!LifeController.Destroyed)
            {

                Move();

                //LifeController.LifeTimer();

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
            }

        }

        public void Shoot()
        {
            //var enemyBullet = bulletsPool.Get();
            //enemyBullet.Init(enemyPosition, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 3);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public override void Move()
        {

            Transform.Position = new Vector2(Transform.Position.X - Speed.X * Time.DeltaTime, Transform.Position.Y);

        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

            }
        }
    }
}
