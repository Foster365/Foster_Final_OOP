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

        //float rotation;
        //Vector2 scale;

        Vector2 position;

        event SimpleEventHandler<Player> OnInmunity;

        bool inmunity;
        float inmunityTimer = 3;

        //Vector2 size;
        //string texture;
        //float radius;

        /*int maxLife;*/
        //int currentLife;

        //PoolBullets bulletsPool;

        float timerShoot;
        float timetoShoot;

        ObjectsPool<PlayerBullet> bulletsPool;

        //

        //Encapsuladas
        public Vector2 PlayerPos { get => position; set => position = value; }

        //public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        //Renderer ICharacter.Renderer { get => renderer; set => renderer=value; }
        //public Renderer Rendererer { get => renderer; set => renderer = value; }

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }

        float timertest = 3;
        float timer = 0;
        //

        public Player(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, Vector2 _speed, int _maxLife, string _texture, float _radius) : base(_position, _scale, _size, _rotation, _texture, _radius)
        {

            //Transform = new Transform(_position, _scale, _rotation);
            //Renderer = new Renderer(_size, _texture, Transform);

            //CircleCollider = new CircleCollider(Transform, Renderer, _radius);
            //BoxCollider = new BoxCollider(Transform, Renderer, _radius);

            //Console.WriteLine("Position" + circleCollider.Transform.Position);
            //Console.WriteLine("Scale" + circleCollider.Transform.Scale);
            //Console.Write("Rotation" + circleCollider.Transform.Rotation);
            //Console.WriteLine("Size" + circleCollider.Renderer.Size);
            //Console.WriteLine("Radius" + _radius);

            CurrentHealth = _maxLife;
            position = Transform.Position;
            Speed = _speed;
            timetoShoot = 0.8f;
            bulletsPool = new ObjectsPool<PlayerBullet>();

            inmunity = true;
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

                BoxCollider.CheckforCollisions(Level1Screen.Enemies[i]);

            }

        }
        
        public void ScreenLimits()
        {
            if (position.Y <= 0)
                position.Y=0;

            if (position.Y > 600)
                position.Y = 0;

            if (position.X <= 0)
                position.X = 0;

            if (position.X > 800)
                position.X = 0;
        }

        public override void Move()
        {
            if (Engine.GetKey(Keys.W))
                position.Y -= Speed.Y * Time.DeltaTime;

            if (Engine.GetKey(Keys.S))
                position.Y += Speed.Y * Time.DeltaTime;

            if (Engine.GetKey(Keys.A))
                position.X -= Speed.X * Time.DeltaTime;

            if (Engine.GetKey(Keys.D))
                position.X += Speed.X * Time.DeltaTime;
            //Console.WriteLine("Moving");

        }

        public void Respawn()
        {
            Damaged = true;

            Random random = new Random();

            Vector2 randomPosition = new Vector2(random.Next(200, 600), random.Next(100, 500));

            if (Damaged)
            {
                position = randomPosition;
                inmunity = true;
                PlayerInmunity();
                //OnInmunity.Invoke(this);
            }
        }

        public void Shoot()
        {
            var playerBullet = bulletsPool.Get();
            playerBullet.Init(position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/BulletPj.png", 1, 3, new Vector2(100, 100));
            //Console.Write("Playerposition" + playerPos.X, playerPos.Y);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public void PlayerInmunity()
        {
            float timer = 0;

            timer += Time.DeltaTime;

            if (timer >= inmunityTimer)
                Damaged = false;

            Console.Write("Inmune");

            inmunity = false;

        }

        public override void TakeDamage(float damage)
        {
            if (Damaged)
            {

                CurrentHealth -= Damage;

                if (CurrentHealth <= 0)
                    Die();

            }
        }

        public override void Die()
        {
            Destroyed = true;
            //Level1Screen.RenderizableObjects.Remove(this);
        }

        public override void Render()
        {
            if (!Destroyed)
            {

                Engine.Draw(Renderer.Texture, PlayerPos.X, PlayerPos.Y, Transform.Scale.X, Transform.Scale.Y, 0, Renderer.GetRealWidth()/2, Renderer.GetRealHeight() / 2);
            
            }
        }
        
        
    }
}
