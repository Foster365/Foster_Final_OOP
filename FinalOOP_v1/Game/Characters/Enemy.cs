using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy :/* EnemyAbs, */ICharacter //Clase abstracta de la cual heredan los enemigos. overraid en update (Aplico las trayectorias como en los métodos)
    {
        //Variables

        //

        float rotation;
        Vector2 scale;

        Vector2 enemyPosition;
        Vector2 enemySpeed;

        Vector2 size;
        string texture;
        float radius;

        int life;

        bool destroyed;

        float lifeTime;
        float lifeTimer;

        float angle;

        Transform transform;
        Renderer renderer;
        CircleCollider circleCollider;

        //ObjectsPool<EnemyBullet> bulletsPool;

        float timerShoot;
        float timetoShoot;

        //

        //Encapsuladas
        public Vector2 EnemyPosition { get => enemyPosition; set => enemyPosition = value; }
        public Vector2 EnemySpeed { get => enemySpeed; set => enemySpeed = value; }

        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Size { get => size; set => size = value; }
        public string Texture { get => texture; set => texture = value; }
        public float Radius { get => radius; set => radius = value; }

        public int Life { get => life; set => life = value; }

        Transform IUpdatable.Transform { get => transform; set => transform = value; }
        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        //Renderer ICharacter.Renderer { get => renderer; set => renderer=value; }
        //public Renderer Rendererer { get => renderer; set => renderer = value; }

        public float TimerShoot { get => timerShoot; set => timerShoot = value; }
        public float TimetoShoot { get => timetoShoot; set => timetoShoot = value; }
        public float Angle { get => angle; set => angle = value; }
        public Renderer Renderer { get => renderer; set => renderer=value; }


        //

        public Enemy(Vector2 position, float rotation, Vector2 scale, Vector2 size, Vector2 enemySpeed, string texture, int life, float angle = 0)/* : base(position, rotation, scale, size, enemySpeed, texture, life)*/
        {
            
            transform = new Transform(enemyPosition, scale, rotation);
            renderer = new Renderer(size, texture, transform);

            this.enemyPosition = position;
            this.Angle = angle - 90;

            circleCollider = new CircleCollider(enemyPosition, scale, rotation, size, radius);

            this.life = life;

            lifeTime = 5;
            EnemySpeed = enemySpeed;
            timetoShoot = 0.8f;


        }

        public void Update()//Ver bien esto
        {
            if (!destroyed)
            {
                lifeTimer += Time.DeltaTime;
                if (lifeTimer >= lifeTime)
                    Level1Screen.RenderizableObjects.Remove(this);

                CheckforCollisions();

            }

        }
          
        public void Shoot()
        {
            //var enemyBullet = bulletsPool.Get();
            //enemyBullet.Init(enemyPosition, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 3);
            //Console.WriteLine("PlayerPos.X"+ playerPos.X + "PlayerPos.Y" + playerPos.Y, "bulletScale.X" + bullet.BulletScale.X + "bulletScale.Y" + bullet.BulletScale.Y + "bulletSize.X" + bullet.BulletSize.X + "bulletSize.Y" + bullet.BulletSize.Y, "bulletRotation" + bullet.BulletRotation + "bulletTexture" + bullet.BulletTexture);

        }

        public void CheckforCollisions()
        {
            //circleCollider.CheckforCollisions(Enemy enemy[i]);
        }

        public void Render()
        {
            if (!destroyed)
            {

                Engine.Draw(renderer.Texture, enemyPosition.X, enemyPosition.Y, transform.Scale.X, transform.Scale.Y, 0, renderer.GetRealWidth() / 2, renderer.GetRealHeight() / 2);

            }
        }
    }
}
