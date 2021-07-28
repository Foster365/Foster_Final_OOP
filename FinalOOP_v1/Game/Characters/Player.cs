using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Player : Entity
    {
        //Variables

        bool inmunity;
        float inmunityMaxTimer = 3; float inmunityTimer = 0;

        bool canShoot;
        float timerShoot = 0; float timetoShoot = .3f;

        bool canReceiveDamage;

        bool canRespawn;

        float collisionTimer = 0;
        float collisionMaxTimer = 1f;

        ObjectsPool<PlayerBullet> bulletsPool;

        //

        //Encapsuladas

        float respawnMaxTimer = 3f;
        float respawnTimer = 0f;

        //

        public Player(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, Vector2 _speed, int _maxLife, string _texture, int _damage, float _radius) : base(_position, _scale, _size, _rotation, _texture, _damage, _radius, _speed)
        {

            Speed = _speed;
            bulletsPool = new ObjectsPool<PlayerBullet>();

            inmunity = false;

            canReceiveDamage = true;

            canRespawn = false;

            LifeController = new LifeController(_maxLife, this, false, true);

        }

        public override void Update()
        {
            if (!LifeController.Destroyed)
            {

                //timer += Time.DeltaTime;
                //Console.WriteLine("Respawn in" + timer);

                ScreenLimits();
                Move();

                timerShoot += Time.DeltaTime;
                //Console.WriteLine("Shoot Timer" + timerShoot);

                if (Engine.GetKey(Keys.SPACE) && timerShoot >= timetoShoot)
                {

                    canShoot = true;
                    Shoot();
                    timerShoot = 0;

                }

                collisionTimer += Time.DeltaTime;
                //Console.WriteLine($"Collisiontimer {collisionTimer}");
                //if (/*canReceiveDamage && */collisionTimer >= collisionMaxTimer)
                CheckForCollisionsWEnemy();

                //Console.WriteLine("Can Respawn: " + canRespawn);

            }

        }

        //void CheckForCollisionsWEnemy()
        //{

        //    for (int i = 0; i < Program.Characters.Count; i++)
        //    {

        //        if (Program.Characters[i].LifeController.IsEnemy)
        //        {

        //            if (CircleCollider.CheckforCollisions(Program.Characters[i]))
        //            {

        //                Program.Characters[i].LifeController.GetDamage(Damage);
        //                Console.WriteLine("Collision with Player. CurrentLife" + Program.Characters[i].LifeController.CurrentLife);
        //                Program.Characters[i].LifeController.Deactivate();

        //            }

        //        }

        //    }


        //    for (int i = 0; i < Program.Characters.Count; i++)
        //    {

        //        if (collisionTimer >= collisionMaxTimer)
        //        {

        //            if (circleCollider.CheckforCollisions(Program.Characters[i]) && Program.Characters[i].LifeController.IsEnemy)
        //            {

        //                //LifeController.Damaged = true;
        //                Console.WriteLine("Changos me golpeé");
        //                //Program.Characters.Remove(Program.Characters[i]);
        //                //Console.WriteLine("Colliding with enemy");
        //                Console.WriteLine($"Current player health is {LifeController.CurrentLife}");
        //                LifeController.GetDamage(Program.Characters[i].Damage);

        //            }

        //        }

        //        collisionTimer = 0;
        //    }

        //}

        void CheckForCollisionsWEnemy()
        {

            //for (int i = 0; i < Program.Characters.Count; i++)
            //{

            //    if (circleCollider.CheckforCollisions(Program.Characters[i]))
            //    {
            //        if (Program.Characters[i].LifeController.IsEnemy)
            //        {

            //            LifeController.Damaged = true;
            //            Console.WriteLine("Changos me golpeé");
            //            LifeController.GetDamage(Program.Characters[i].Damage);
            //            Program.Characters[i].LifeController.Deactivate();

            if (LifeController.Damaged)
            {
                Respawn();
                canRespawn = true;
                canReceiveDamage = true;
                LifeController.Damaged = false;

            }

            //            Console.WriteLine("Can Respawn: " + canRespawn);
            //            Console.WriteLine("Player current health" + LifeController.CurrentLife);

            //        }
            //    }

            //}

            //collisionTimer = 0;

        }

        public void Respawn()
        {

            if (canRespawn)
            {

                //Console.WriteLine("Inmunity timer: " + inmunityTimer);
                //LifeController.Damaged = true;

                Random random = new Random();

                Vector2 randomPosition = new Vector2(random.Next(200, 600), random.Next(100, 500));

                Console.WriteLine("Respawning player");

                //if (LifeController.Damaged)
                //{

                Transform.Position = randomPosition;
                inmunity = true;
                canReceiveDamage = false;
                respawnTimer = 0;

                inmunityTimer += Time.DeltaTime;

                Console.WriteLine("Inmunity timer: " + inmunityTimer);

                while(inmunity)
                {

                    if(inmunityTimer<=inmunityMaxTimer)
                        PlayerInmunity();

                    inmunity = false;

                }

                inmunityTimer = 0;

            }
        }

        public void PlayerInmunity()
        {

            Console.WriteLine("Player inmune");
            canRespawn = false;
            canReceiveDamage = false;
            canShoot = false;
            //Renderizar burbuja (Podría tener un collider)

        }

        public void ScreenLimits()
        {

            if (Transform.Position.Y <= 0)
                Transform.Position = new Vector2(Transform.Position.X, 0);

            if (Transform.Position.Y > 600)
                Transform.Position = new Vector2(Transform.Position.X, 600);

            if (Transform.Position.X <= 0)
                Transform.Position = new Vector2(0, Transform.Position.Y);

            if (Transform.Position.X > 800)
                Transform.Position = new Vector2(800, Transform.Position.Y);

        }

        public override void Move()
        {

            if (Engine.GetKey(Keys.W))
                Transform.Position -= new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Engine.GetKey(Keys.S))
                Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Engine.GetKey(Keys.A))
                Transform.Position -= new Vector2(Speed.X * Time.DeltaTime, 0);

            if (Engine.GetKey(Keys.D))
                Transform.Position += new Vector2(Speed.X * Time.DeltaTime, 0);

        }

        public void Shoot()
        {
            if(canShoot)
            {

                var playerBullet = bulletsPool.Get();
                playerBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/Entities/Characters/BulletPj.png", 1, new Vector2(200, 200), 10, 1);

            }
        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight() / 2);
            }

        }


    }
}
