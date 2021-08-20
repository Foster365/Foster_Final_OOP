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

        ObjectsPool<EnemyBullet> bulletsPool;

        float shootTimer;
        float shootMaxTimer;

        public Enemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _maxLife, float _angle, float _lifetime, int _damage, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _enemySpeed)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            Speed = _enemySpeed;
            shootMaxTimer = 1.5f;

            bulletsPool = new ObjectsPool<EnemyBullet>();

            LifeController = new LifeController(this, true, false, _maxLife, _lifetime);
                
        }

        public override void Update()
        {

            if (!LifeController.Destroyed)
            {

                Move();

                LifeController.LifeTimer();

                //CheckForCollisions();

                //CheckForCollisionsWithPlayer();
                
                if(LifeController.Destroyed)
                    LifeController.UpdateAnimation();

                shootTimer += Time.DeltaTime;

                if (shootTimer >= shootMaxTimer)
                {

                    Shoot();
                    shootTimer = 0;

                }

            }

        }

        void CheckForCollisions()
        {
            for (int i = 0; i < Program.Characters.Count; i++)
            {
                if (Program.Characters[i].LifeController.IsPlayer)
                {

                    if (CircleCollider.CheckforCollisions(Program.Characters[i]))
                    {

                        Console.WriteLine("Collision with player");
                        Program.Characters[i].LifeController.GetDamage(Damage);
                        //CircleCollider.IsCollision = true;
                        //Program.Characters[i].LifeController.Damaged = true;
                        LifeController.Deactivate(this);

                        Console.WriteLine($"Player current life {Program.Characters[i].LifeController.CurrentLife}");
                        //LifeController.Destroyed = true;
                        //LifeController.Deactivate();

                    }

                }
            }
        }


        public void Shoot()
        {

            var enemybullet = bulletsPool.Get();
            enemybullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/Entities/Characters/BulletEnemy1.png", 3, new Vector2(200, 200), 10, 5);

        }

        public override void Move()
        {

            Transform.Position = new Vector2(Transform.Position.X - Speed.X * Time.DeltaTime, Transform.Position.Y);
            //Console.WriteLine($"Enemy speed {Speed.X}");

        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

            }
            //else
            //    LifeController.RenderAnimation();
        }
    }
}
