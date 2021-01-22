using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player: Entity, ICharacter
    {
        //Variables

        //float rotation;
        //Vector2 scale;

        Vector2 position;

        //Vector2 size;
        //string texture;
        //float radius;

        /*int maxLife;*/
        //int currentLife;

        bool destroyed;

        Transform transform;
        Renderer renderer;
        CircleCollider circleCollider;

        //PoolBullets bulletsPool;

        float timerShoot;
        float timetoShoot;

        ObjectsPool<PlayerBullet> bulletsPool;

        //

        //Encapsuladas
        public Vector2 PlayerPos { get => position; set => position = value; }

        Transform IUpdatable.Transform { get => transform; set => transform = value; }
        Renderer IRenderizable.Renderer { get =>renderer; set => renderer = value; }
        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        //Renderer ICharacter.Renderer { get => renderer; set => renderer=value; }
        //public Renderer Rendererer { get => renderer; set => renderer = value; }

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }

        //

        public Player(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, Vector2 _speed, int _maxLife, string _texture, float _radius) : base(_position, _scale, _size, _rotation, _texture, _radius)
        {

            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, _texture, transform);

            circleCollider = new CircleCollider(transform.Position, _scale, _rotation, _size, _radius);

            Radius = _radius;
            CurrentHealth = _maxLife;
            position = transform.Position;
            Speed = _speed;
            timetoShoot = 0.8f;
            bulletsPool = new ObjectsPool<PlayerBullet>();
        }

        public override void Update()
        {
            if (!destroyed)
            {
                ScreenLimits();
                Move();

                TimerShoot += Time.DeltaTime;

                if (Engine.GetKey(Keys.SPACE) && TimerShoot >= TimetoShoot)
                {

                    Shoot();
                    TimerShoot = 0;

                }
                for (int i = 0; i < Level1Screen.Enemies.Count; i++)
                {

                    if (circleCollider.CheckforCollisions(Level1Screen.Enemies[i]))
                        Console.Write("Collision");
                }

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

        public void Shoot()
        {
            var playerBullet = bulletsPool.Get();
            playerBullet.Init(position, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/BulletPj.png", 1, 3, new Vector2(100, 100));
            //Console.Write("Playerposition" + playerPos.X, playerPos.Y);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public override void TakeDamage()
        {

        }

        public override void Die()
        {

        }

        public override void Render()
        {
            if (!destroyed)
            {

                Engine.Draw(renderer.Texture, PlayerPos.X, PlayerPos.Y, transform.Scale.X, transform.Scale.Y, 0, renderer.GetRealWidth()/2, renderer.GetRealHeight() / 2);
            
            }
        }
        
        
    }
}
