using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player: ICharacter
    {
        //Variables
        
        float rotation;
        Vector2 scale;

        Vector2 playerPos;
        Vector2 playerSpeed;

        Vector2 size;
        string texture;
        float radius;

        /*int maxLife;*/ int currentLife;

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
        public Vector2 PlayerPos { get => playerPos; set => playerPos = value; }
        public Vector2 PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }

        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Size { get => size; set => size = value; }
        public string Texture { get => texture; set => texture = value; }
        public float Radius { get => radius; set => radius = value; }

        public int CurrentLife { get => currentLife; set => currentLife = value; }

        public bool Destroyed { get => destroyed; set => destroyed = false; }


        Transform IUpdatable.Transform { get => transform; set => transform = value; }
        Renderer IRenderizable.Renderer { get =>renderer; set => renderer = value; }
        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        //Renderer ICharacter.Renderer { get => renderer; set => renderer=value; }
        //public Renderer Rendererer { get => renderer; set => renderer = value; }

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }

        //

        public Player(Vector2 playerPos, Vector2 scale, float rotation, Vector2 size, Vector2 playerSpeed, int maxLife, string texture, float radius)/* : base(radius)*/
        {

            transform = new Transform(playerPos, scale, rotation);
            renderer = new Renderer(size, texture, transform);

            circleCollider = new CircleCollider(playerPos, scale, rotation, size, radius);

            this.radius = radius;
            currentLife = maxLife;
            PlayerPos = transform.Position;
            PlayerSpeed = playerSpeed;
            timetoShoot = 0.8f;
            bulletsPool = new ObjectsPool<PlayerBullet>();
        }

        public void Update()
        {
            if (!destroyed)
            {
                ScreenLimits();
                CheckInputs();

                TimerShoot += Time.DeltaTime;

                if (Engine.GetKey(Keys.SPACE) && TimerShoot >= TimetoShoot)
                {

                    Shoot();
                    TimerShoot = 0;

                }
                for (int i = 0; i < Level1Screen.Enemies.Count; i++)
                {

                    circleCollider.CheckforCollisions(Level1Screen.Enemies[i]);
                }

            }
            
        }
        
        public void ScreenLimits()
        {
            if (playerPos.Y <= 0)
                playerPos.Y=0;

            if (playerPos.Y > 600)
                playerPos.Y = 0;

            if (playerPos.X <= 0)
                playerPos.X = 0;

            if (playerPos.X > 800)
                playerPos.X = 0;
        }

        public void CheckInputs()
        {
            if (Engine.GetKey(Keys.W))
                playerPos.Y -= playerSpeed.Y * Time.DeltaTime;

            if (Engine.GetKey(Keys.S))
                playerPos.Y += playerSpeed.Y * Time.DeltaTime;

            if (Engine.GetKey(Keys.A))
                playerPos.X -= playerSpeed.X * Time.DeltaTime;

            if (Engine.GetKey(Keys.D))
                playerPos.X += playerSpeed.X * Time.DeltaTime;
            //Console.WriteLine("Moving");

        }

        public void Shoot()
        {
            var playerBullet = bulletsPool.Get();
            playerBullet.Init(playerPos, new Vector2(1, 1), new Vector2(20, 10), 0, "Textures/BulletPj.png", 1, 3, new Vector2(100, 100));
            //Console.Write("Playerposition" + playerPos.X, playerPos.Y);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public void Render()
        {
            if (!destroyed)
            {

                Engine.Draw(renderer.Texture, PlayerPos.X, PlayerPos.Y, transform.Scale.X, transform.Scale.Y, 0, renderer.GetRealWidth()/2, renderer.GetRealHeight() / 2);
            
            }
        }
        
        
    }
}
