using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthPowerUp : PowerUp
    {

        int hp;

        Level1Screen level1;

        public HealthPowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _lifeTime, float _rotation, float _colliderRadius, int _hp, string _texture) : base(_position, _scale, _size, _speed, _lifeTime, _rotation, _colliderRadius, _texture)
        {

            hp = _hp;

        }

        public override void Update()
        {

            //CircleCollider.CheckforCollisions(level1.Player);
            CheckForCollisionsWithPlayer();

            Move();

        }

        protected override void CheckForCollisionsWithPlayer()
        {
            for (int i = 0; i < Program.Characters.Count; i++)
            {
                if (Program.Characters[i].LifeController.IsPlayer)
                {
                    if (CircleCollider.CheckforCollisions(Program.Characters[i]))
                    {
                        Heal(Program.Characters[i]);
                        Console.WriteLine($"Player current life: {Program.Characters[i].LifeController.CurrentLife}");
                        LifeController.Deactivate(this);
                    }
                }
            }
        }

        void Heal(Entity ent)
        {
            ent.LifeController.CurrentLife += hp;
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
