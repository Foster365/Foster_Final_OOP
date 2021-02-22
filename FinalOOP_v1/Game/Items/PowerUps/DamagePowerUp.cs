using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class DamagePowerUp : PowerUp
    {

        float damageIncreaser;

        Level1Screen level1;

        public DamagePowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _rotation, float _colliderRadius, float _damageIncreaser, string _texture) : base(_position, _scale, _size, _speed, _rotation, _colliderRadius, _texture)
        {

            damageIncreaser = _damageIncreaser;

        }

        public override void Update()
        {

            //CircleCollider.CheckforCollisions(level1.Player);

            Move();

        }

        public void GiveDamage()
        {
            //if (CircleCollider.CheckforCollisions());
            //  player.Damage = player.Damage + damageIncreaser;
        }

        public override void Move()
        {

            Transform.Position -= new Vector2(Speed.X * Time.DeltaTime, 0);

        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, 0, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);
        }

    }
}
