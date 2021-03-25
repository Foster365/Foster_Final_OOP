using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBullet : Bullet<PlayerBullet>
    { 
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
                LifeController.Deactivate();
            }

            CheckForCollisionsWEnemy();
        }

        //public override void Deactivate()
        //{
        //    LifeController.Destroyed = true;
        //    OnDeactivate?.Invoke(this);
        //    Program.Environment.Remove(this);
        //}

        void CheckForCollisionsWEnemy()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                if (Program.Characters[i].LifeController.IsEnemy)
                {

                    if(circleCollider.CheckforCollisions(Program.Characters[i]))
                    {

                        Console.WriteLine("Colliding with enemy");
                        Program.Characters[i].LifeController.GetDamage(Damage);
                        LifeController.Deactivate();
                        GameManager.Instance.EnemyKills++;
                        Console.WriteLine("Killcount" + GameManager.Instance.EnemyKills);
                        //Console.WriteLine("Enemy current life" + Level1Screen.Enemies[i].LifeController.CurrentLife);

                    }

                }

            }

        }

        public override void Move()
        {
            Transform.Position += new Vector2(speed.X * Time.DeltaTime, 0);
            //Engine.Debug(transform.Position.X);
        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight()/2);
        }
    }
}
