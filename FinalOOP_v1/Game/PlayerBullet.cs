using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBullet : Bullet<PlayerBullet>
    {

        float collTimer = 0;
        float maxCollTimer = .5f;

        public PlayerBullet() : base()
        {

        }

        public override event Action<PlayerBullet> OnDeactivate;

        public override void Update()
        {
            Move();
            timer += Time.DeltaTime;

            if (timer >= BulletLifetime)
            {
                LifeController.Deactivate(this);
            }

            collTimer += Time.DeltaTime;

            //if(collTimer >= maxCollTimer)
            CheckForCollisionsWEnemy();
            //CheckForCollisionsWithAsteroids();

            //Console.WriteLine($"Is collider {isCollider}");

        }

        void CheckForCollisionsWEnemy()
        {
            for (int i = 0; i < Program.Characters.Count; i++)
            {

                //if (circleCollider.CheckforCollisions(Program.Characters[i]) && Program.Characters[i].LifeController.IsEnemy)
                if(CircleCollider.)
                {
                    //if(isCollider)
                    //{
                        circleCollider.IsCollision = false;
                        Console.WriteLine("Colliding with enemy");
                        GameManager.Instance.EnemyKills++;
                        Program.Characters[i].LifeController.GetDamage(Damage);
                        //LifeController.Deactivate(this);
                        //Program.Characters.Remove(Program.Characters[i]);
                        Console.WriteLine("Killcount" + GameManager.Instance.EnemyKills);
                        //Console.WriteLine("Enemy current life" + Level1Screen.Enemies[i].LifeController.CurrentLife);
                        
                    //}
                }

            }

            //isCollider = true;
        }

        void CheckForCollisionsWithAsteroids()
        {
            for(var i = 0; i < Program.Characters.Count; i++)
            {
                if (circleCollider.CheckforCollisions(Program.Characters[i]) && !Program.Characters[i].LifeController.IsPlayer)
                {
                    Console.WriteLine("Collision with asteroid, deactivating");
                    Program.Characters[i].LifeController.Deactivate(Program.Characters[i]);
                }
            }
        }

        public override void Move()
        {

            Transform.Position += new Vector2(speed.X * Time.DeltaTime, 0);

        }

        public override void Render()
        {

            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight()/2);

        }
    }
}
