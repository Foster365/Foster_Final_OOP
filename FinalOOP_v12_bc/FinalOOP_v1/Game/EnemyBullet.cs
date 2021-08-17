using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyBullet : Bullet<EnemyBullet>
    {

        public EnemyBullet():base()
        {

        }

        public override event Action<EnemyBullet> OnDeactivate;

        public override void Update()
        {

            Move();
            //CheckForCollisions();

        }

        void CheckForCollisions()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                if (Program.Characters[i].LifeController.IsPlayer)
                {

                    if (CircleCollider.CheckforCollisions(Program.Characters[i]))
                    {

                        CircleCollider.IsCollision = true;
                        Program.Characters[i].LifeController.GetDamage(Damage);
                        Console.WriteLine("Collision with Player. CurrentLife" + Program.Characters[i].LifeController.CurrentLife);
                        LifeController.Deactivate(Program.Characters[i]);

                    }

                }

            }

        }

        public override void Move()
        {

            Transform.Position += new Vector2(-Speed.X * Time.DeltaTime, 0);

        }

        public override void Render()
        {

            if (!LifeController.Destroyed)
                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

        }

    }
}
