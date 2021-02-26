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
        float inmunityMaxTimer = 3;
        float inmunityTimer = 0;

        bool canShoot;
        float timerShoot;
        float timetoShoot;

        ObjectsPool<PlayerBullet> bulletsPool;

        //

        //Encapsuladas

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }

        float timertest = 5;
        float timer = 0;
        //

        public Player(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, Vector2 _speed, int _maxLife, string _texture, float _radius) : base(_position, _scale, _size, _rotation, _texture, _radius)
        {

            //Console.WriteLine("Transform player x " + position.X + "Transform player y" + position.Y);

            CurrentHealth = _maxLife;
            Speed = _speed;
            timetoShoot = 0.8f;
            bulletsPool = new ObjectsPool<PlayerBullet>();

            inmunity = false;
            //inmunityTimer = 5f;

            //timertest = 3f;

            //OnInmunity += OnInmunityHandler();
        }

        public override void Update()
        {
            if (!Destroyed)
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

                CheckforCollisions();

                //Test();

            }

        }

        public void Test()
        {


            timer += Time.DeltaTime;
            Console.WriteLine(timer);

            if (timer >= timertest)
            {

                Respawn();
                Console.WriteLine("Hi");
                timer = 0;

            }


        }

        void CheckforCollisions()
        {

            for (int i = 0; i < Level1Screen.Enemies.Count; i++)
            {
                CircleCollider.CheckforCollisions(Level1Screen.Enemies[i]);
                //if (CircleCollider.CheckforCollisions(Level1Screen.Enemies[i]) && CurrentHealth > 0) Respawn();

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

            //Vector2 pos = new Vector2(Transform.Position.X, Transform.Position.Y);
            if (Engine.GetKey(Keys.W))
                //Transform.Position = new Vector2(Transform.Position.X, (Transform.Position.Y - Speed.Y * Time.DeltaTime));
                Transform.Position -= new Vector2(0, Speed.Y * Time.DeltaTime);

            //position.Y += Speed.Y * Time.DeltaTime;
            ////Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Engine.GetKey(Keys.S))
                //position += new Vector2(Transform.Position.X, (Transform.Position.Y + Speed.Y * Time.DeltaTime));
                Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Engine.GetKey(Keys.A))
                //position -= new Vector2((Transform.Position.X - Speed.X * Time.DeltaTime), Transform.Position.Y);
                Transform.Position -= new Vector2(Speed.X * Time.DeltaTime, 0);

            if (Engine.GetKey(Keys.D))
                //position += new Vector2((Transform.Position.X + Speed.X * Time.DeltaTime), Transform.Position.Y);
                Transform.Position += new Vector2(Speed.X * Time.DeltaTime, 0);

            //Console.WriteLine("Transform player x " + Transform.Position.X + "Transform player y" + Transform.Position.Y);

        }

        public void Respawn()
        {
            Damaged = true;

            Random random = new Random();

            Vector2 randomPosition = new Vector2(random.Next(200, 600), random.Next(100, 500));

            if (Damaged)
            {
                Transform.Position = randomPosition;
                inmunity = true;
                PlayerInmunity();
                //OnInmunity.Invoke(this);
            }
        }

        public void Shoot()
        {
            if(canShoot)
            {

                var playerBullet = bulletsPool.Get();
                playerBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/BulletPj.png", 1, new Vector2(100, 100), 3);
                //Console.Write("Playerposition" + playerPos.X, playerPos.Y);
                //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

            }
        }

        public void PlayerInmunity()
        {
            inmunity = true;
            canShoot = false;

            inmunityTimer += Time.DeltaTime;

            if (inmunityTimer >= inmunityMaxTimer)
            {

                inmunity = false;
                canShoot = false;

                //Damaged = false;

            }

            inmunityTimer = 0;

        }

        //public override void TakeDamage(float damage)
        //{
        //    if (Damaged)
        //    {

        //        CurrentHealth -= Damage;

        //        if (CurrentHealth <= 0)
        //            Die();

        //    }
        //}

        //public override void Die()
        //{
        //    Destroyed = true;
        //    //Level1Screen.RenderizableObjects.Remove(this);
        //}

        public override void Render()
        {
            if (!Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight() / 2);
            
            }
        }
        
        
    }
}
