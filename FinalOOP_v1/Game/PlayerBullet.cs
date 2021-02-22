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

        public PlayerBullet(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _rotation, string _texture, float _bulletRadius, float _lifetime) : base (_position, _scale, _size, _speed, _rotation, _texture, _bulletRadius, _lifetime)
        {

            BulletLifetime = _lifetime;

             
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
            Transform.Position += new Vector2 (BulletSpeed.X * Time.DeltaTime, Transform.Position.Y);

        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth()/2, Renderer.GetRealHeight()/2);
        }

    }
}
