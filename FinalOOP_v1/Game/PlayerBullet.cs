using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBullet : Bullet<PlayerBullet>
    {
        Vector2 bulletPos;

        public Vector2 BulletPos { get => bulletPos; set => bulletPos = value; }

        public override event SimpleEventHandler<PlayerBullet> OnDeactivate;

        public override void Init(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture, float radius, float lifetime, Vector2 speed)
        {

            Transform = new Transform(position, scale, rotation);
            Renderer = new Renderer(size, texture, Transform);

            BulletLifetime = lifetime;
            BulletSpeed = speed;

            Timer = 0;
            Destroyed = false;
             
            Level1Screen.RenderizableObjects.Add(this);

        }

        public override void Update()
        {

            Move();
            Timer += Time.DeltaTime;

            if (Timer >= BulletLifetime)
            {
                Console.WriteLine("Deactivating");
                Deactivate();
            }
            //else
            //{

                //CheckforCollisions()

            //}
        }

        public override void Deactivate()
        {
            Destroyed = true;
            Level1Screen.RenderizableObjects.Remove(this);

            if (OnDeactivate != null)
            {
                OnDeactivate.Invoke(this);
            }
        }
        public override void Move()
        {
            Transform.Position += new Vector2(BulletSpeed.X * Time.DeltaTime, 0);
            Engine.Debug(bulletPos.X);
        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight()/2);
        }

    }
}
