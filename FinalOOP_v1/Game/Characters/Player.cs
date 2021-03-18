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
        float timerShoot; float timetoShoot;

        bool canReceiveDamage;

        bool canRespawn;

        ObjectsPool<PlayerBullet> bulletsPool;

        //

        //Encapsuladas

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }

        float respawnTimer = 3f;
        float timer = 0f;

        //

        public Player(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, Vector2 _speed, int _maxLife, string _texture, int _damage, float _radius) : base(_position, _scale, _size, _rotation, _texture, _damage, _radius, _speed)
        {

            Speed = _speed;
            timetoShoot = 0.5f;
            bulletsPool = new ObjectsPool<PlayerBullet>();

            inmunity = false;

            canReceiveDamage = true;

            canRespawn = false;

            LifeController = new LifeController(_maxLife, this, false, true);
            Console.WriteLine("Is Player?" + LifeController.IsPlayer);
            Console.WriteLine("Is Enemy?" + LifeController.IsEnemy);

        }

        public override void Update()
        {
            if (!LifeController.Destroyed)
            {

                //timer += Time.DeltaTime;
                //Console.WriteLine("Respawn in" + timer);

                ScreenLimits();
                Move();

                TimerShoot += Time.DeltaTime;

                if (Engine.GetKey(Keys.SPACE) && TimerShoot >= TimetoShoot)
                {
                    canShoot = true;
                    Shoot();
                    TimerShoot = 0;

                }

                //if (canReceiveDamage)
                CheckForCollisions();

            }

        }

        void CheckForCollisions()
        {
            for (int i = 0; i < Program.Enemies.Count; i++)
            {

                if (circleCollider.CheckforCollisions(Program.Enemies[i]) && Program.Enemies[i].LifeController.IsEnemy == true)
                {

                    //if(inmunityTimer >= inmunityMaxTimer/*&& timer > respawnTimer*/ )
                    //            //{

                    //            //}

                    LifeController.GetDamage(Program.Characters[i].Damage);
                    canReceiveDamage = false;
                    inmunityTimer = 0;
                    canRespawn = true;
                    Respawn();
                    timer = 0;
                }
            }
        }

        //void CheckforCollisions()
        //{
        //    inmunityTimer += Time.DeltaTime;

        //    for (int i = 0; i < Program.Characters.Count; i++)
        //    {

        //        if (CircleCollider.CheckforCollisions(Program.Characters[i]) && Program.Characters[i].LifeController.IsEnemy == true && LifeController.CurrentLife > 0)
        //        {

        //            //if(inmunityTimer >= inmunityMaxTimer/*&& timer > respawnTimer*/ )
        //            //{

        //            //}
        //            Console.WriteLine("Colliding with myself");
        //            LifeController.GetDamage(Program.Characters[i].Damage);
        //            canReceiveDamage = false;
        //            inmunityTimer = 0;
        //            //canRespawn = true;
        //            //Respawn();
        //            //timer = 0;

        //        }

        //    }
        //}
        public void ScreenLimits()
        {
            if (Transform.Position.Y <= 0)
                Transform.Position = new Vector2(Transform.Position.X, 0);

            if (Transform.Position.Y > 600)
                Transform.Position = new Vector2(Transform.Position.X, 0);

            if (Transform.Position.X <= 0)
                Transform.Position = new Vector2(0, Transform.Position.Y);

            if (Transform.Position.X > 800)
                Transform.Position = new Vector2(0, Transform.Position.Y);
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

        public void Respawn()
        {

            LifeController.Damaged = true;

            Random random = new Random();

            Vector2 randomPosition = new Vector2(random.Next(200, 600), random.Next(100, 500));

            Console.WriteLine("Respawning player");

            if (LifeController.Damaged)
            {

                Transform.Position = randomPosition;
                inmunity = true;
                PlayerInmunity();

            }

        }

        public void Shoot()
        {
            if(canShoot)
            {

                var playerBullet = bulletsPool.Get();
                playerBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/Entities/Characters/BulletPj.png", 1, new Vector2(30, 30), 10, 3);

            }
        }

        public void PlayerInmunity()
        {

            canRespawn = false;
            inmunity = true;
            canShoot = false;

            inmunityTimer += Time.DeltaTime;

            if (inmunityTimer >= inmunityMaxTimer)
            {

                inmunity = false;
                canShoot = false;

                //Damaged = false;

            }

            canReceiveDamage = true;
            inmunityTimer = 0;

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
