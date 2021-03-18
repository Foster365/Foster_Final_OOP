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
        Vector2 position;

        float lifeTimer = 0;

        float timerShoot;
        float timetoShoot;

        //

        public BossEnemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _maxHealth, float _angle, float _lifetime, int _damage, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _enemySpeed)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            Speed = _enemySpeed;
            timetoShoot = 0.8f;

            LifeController = new LifeController(_maxHealth, _lifetime, this, true, false);

            //pursuitBehaviour = new Pursuit(Transform.Position, player.Transform.Position, Speed, 1);

        }

        public override void Update()//Ver bien esto
        {
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
            }

        }

        public void Shoot()
        {
            var enemyBullet = poolBullets.Get();
            enemyBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 10, new Vector2(50, 50), 10, 4);
            Console.WriteLine("PlayerPos.X" + Transform.Position.X + "PlayerPos.Y" + Transform.Position.Y, "bulletScale.X" + enemyBullet.Transform.Scale.X + "bulletScale.Y" + enemyBullet.Transform.Scale.Y + "bulletSize.X"
                + enemyBullet.Renderer.Size.X + "bulletSize.Y" + enemyBullet.Renderer.Size.Y, "bulletRotation" + enemyBullet.Transform.Rotation + "bulletTexture" + enemyBullet.Renderer.Texture);

        }

        public override void Move()
        {
            Vector2 dir = pursuitBehaviour.GetDir();
            Transform.Position += new Vector2(dir.X * speed.X * Time.DeltaTime, 0);
            Transform.Position += new Vector2(0, dir.Y * speed.X * Time.DeltaTime);

                //Transform.Position = new Vector2(Transform.Position.X - Speed.X * Time.DeltaTime, Transform.Position.Y);

                //Transform.Rotation += 5;

                //float dirX = (float)Math.Cos((Transform.Rotation - 90) * Math.PI / 180);
                //float dirY = (float)Math.Sin((Transform.Rotation - 90) * Math.PI / 180);

                //Transform.Position += new Vector2(dirX * Speed.X, 0);
                //Transform.Position += new Vector2(0, dirY * Speed.Y);

        }

        public void MoveTowards()
        {

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
