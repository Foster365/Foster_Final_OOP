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

            LifeController = new LifeController(this, false, true, _maxLife);//TODO Sacar _maxLife del constructor, correspondería ponerlo en el lifeController.

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

                if (Engine.GetKey(Keys.Q))
                    LifeController.GetDamage(10);

                collisionTimer += Time.DeltaTime;

                Console.WriteLine($"Player damaged: {LifeController.Damaged}");

                if (LifeController.Damaged)
                    Respawn();

                //if(canReceiveDamage && !LifeController.Damaged)
                //CheckForCollisionsWEnemy();

            }
            
        }

        void CheckForCollisionsWEnemy()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {

                if (Program.Characters[i].LifeController.IsEnemy)
                {
                    if (CircleCollider.CheckforCollisions(Program.Characters[i]))
                    {

                        //Console.WriteLine("Collision with enemy, respawning");

                        LifeController.Damaged = true;
                        canRespawn = true;
                        //Console.WriteLine("Changos me golpeé");


                        if (LifeController.Damaged)
                        {


                            Console.WriteLine("Respawn player");

                            if (canRespawn)
                                Respawn();

                        }

                        Console.WriteLine($"Player inmunity outside PlayerInmunity(): {inmunity}");

                        Console.WriteLine($"Can Respawn outside PlayerInmunity(): {canRespawn}");

                        //LifeController.Damaged = false;
                        //canReceiveDamage = true;

                        //Console.WriteLine("Can Respawn: " + canRespawn);
                        //Console.WriteLine("Player current health" + LifeController.CurrentLife);

                    }
                }


                //inmunity = false;

                //canReceiveDamage = true;
                //LifeController.Damaged = false;

                //canShoot = true;
                //canRespawn = true;


            }

            collisionTimer = 0;

          
        }

        public void Respawn()
        {

            respawnTimer = 0;
            inmunityTimer = 0;

            canReceiveDamage = false;

            //Console.WriteLine("Inmunity timer: " + inmunityTimer);
            //LifeController.Damaged = true;

            Random random = new Random();

            //Vector2 randomPosition = ;

            Console.WriteLine("Respawning player");

            //if (LifeController.Damaged)
            //{

            Transform.Position = new Vector2(random.Next(200, 600), random.Next(100, 500))/*randomPosition*/;
            Console.WriteLine($"Player new pos {Transform.Position.X}, {Transform.Position.Y}");
            //canReceiveDamage = false;

            inmunity = true;
            canRespawn = false;

            inmunityTimer += Time.DeltaTime;

            if(inmunity && inmunityTimer <= inmunityMaxTimer)
            {
                Console.WriteLine("Hi");

                Console.WriteLine($"InmunityTimer is {inmunityTimer}");

                //Console.WriteLine($"Player is inmune for {inmunityTimer} sec");
                //if(inmunity)
                //if ()
                PlayerInmunity();

            }

                
            if (canRespawn)
            {

           
            }

            inmunity = false;
            canReceiveDamage = true;
            LifeController.Damaged = false;
            canShoot = true;
            canRespawn = false;

        }

        public void PlayerInmunity()
        {

            Console.WriteLine("Player inmune");
            //inmunity = true;
            //canRespawn = false;
            canReceiveDamage = false;
            canShoot = false;
            canRespawn = false;
            Console.WriteLine($"Player inmunity inside PlayerInmunity(): {inmunity}");

            Console.WriteLine($"Can Respawn inside PlayerInmunity(): {canRespawn}");
            //Renderizar burbuja (Podría tener un collider)
            //return;
            
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
                playerBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/Entities/Characters/BulletPj.png", 3, new Vector2(200, 200), Damage, 1);

            }
        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight() / 2);
            }

        }


    }
}
