using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Player : Entity, ICharacter
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
            timetoShoot = 0.8f;
            bulletsPool = new ObjectsPool<PlayerBullet>();

            inmunity = false;

            canReceiveDamage = true;

            canRespawn = false;

            lifeController = new LifeController(_maxLife, this);

        }

        public override void Update()
        {
            if (!lifeController.Destroyed)
            {
                ScreenLimits();
                Move();

                TimerShoot += Time.DeltaTime;

                if (Engine.GetKey(Keys.SPACE) && TimerShoot >= TimetoShoot)
                {
                    canShoot = true;
                    Shoot();
                    TimerShoot = 0;

                }

                if (canReceiveDamage)
                    CheckforCollisions();

            }

        }

        void CheckforCollisions()
        {

            timer += Time.DeltaTime;
            Console.WriteLine("Respawn in" + timer);

            for (int i = 0; i < Level1Screen.Enemies.Count; i++)
            {

                CircleCollider.CheckforCollisions(Level1Screen.Enemies[i]);

                if (CircleCollider.CheckforCollisions(Level1Screen.Enemies[i]) && timer > respawnTimer && lifeController.CurrentLife > 0)
                {

                    lifeController.GetDamage(Level1Screen.Enemies[i].Damage);
                    canRespawn = true;
                    Respawn();
                    timer = 0;

                    if (lifeController.CurrentLife <= 0) lifeController.Die();

                }

            }
        }

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

            lifeController.Damaged = true;

            Random random = new Random();

            Vector2 randomPosition = new Vector2(random.Next(200, 600), random.Next(100, 500));

            Console.WriteLine("Respawning player");

            if (lifeController.Damaged)
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
                playerBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/BulletPj.png", 1, new Vector2(100, 100), 10, 3);

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
            if (!lifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight() / 2);
            
            }
        }
        
        
    }
}
