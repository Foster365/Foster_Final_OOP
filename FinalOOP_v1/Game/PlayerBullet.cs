using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerBullet : Bullet
    { 
        public PlayerBullet() : base()
        {

        }

        public override event Action<Bullet> OnDeactivate;

        public override void Update()
        {
            Move();
            timer += Time.DeltaTime;

            if (timer >= BulletLifetime)
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
            OnDeactivate?.Invoke(this);
        }
        public override void Move()
        {
            Transform.Position += new Vector2(speed.X * Time.DeltaTime, 0);
            Engine.Debug(transform.Position.X);
        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight()/2);
        }
    }
}
