using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SpeedPowerUp : PowerUp
    {


        Vector2 speedIncreaser;

        Level1Screen level1;

        public SpeedPowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, Vector2 _speedIncreaser, float _lifeTime, float _rotation, float _colliderRadius, string _texture) : base(_position, _scale, _size, _speed, _lifeTime, _rotation, _colliderRadius, _texture)
        {

            speedIncreaser = _speedIncreaser;

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

                        GiveSpeed(Program.Characters[i]);
                        Console.WriteLine($"Player current speed: {Program.Characters[i].Speed}");
                        LifeController.Deactivate(this);

                    }
                }
            }
        }

        void GiveSpeed(Entity ent)
        {
            ent.Speed += speedIncreaser;
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
