using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Asteroid : Entity
    {

        //MCU
        //float angle;
        //float angularSpeed;

        public Asteroid(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, float _lifeTime, Vector2 _speed) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _lifeTime, _speed)
        {

            speed = _speed;

            LifeController = new LifeController(_lifeTime, this, false, false);


        }

        public override void Move()
        {

            Transform.Position -= new Vector2(speed.X * Time.DeltaTime, 0);
            //Transform.Position += new Vector2(0, speed.Y * Time.DeltaTime);

            //angularSpeed += angularAceleration * Time.DeltaTime;
            //angle += angularSpeed * Time.DeltaTime + 0.5f * angularAceleration * Time.DeltaTime * Time.DeltaTime;

        }

        public override void Update()
        {

            Move();

            for(int i = 0; i < Program.Characters.Count; i++)
            {
                if(Program.Characters[i].LifeController.IsPlayer)
                    if(CircleCollider.CheckforCollisions(Program.Characters[i]))
                        Program.Characters[i].LifeController.GetDamage(Damage);

                //Console.WriteLine("Collision W/ Player");

            }
        }

        public override void Render()
        {

            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

        }

 
    }
}
