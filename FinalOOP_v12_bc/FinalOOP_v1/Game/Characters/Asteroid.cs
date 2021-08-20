using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Asteroid : Entity
    {
        List<Item> powerUps;
        //MCU
        //float angle;
        //float angularSpeed;

        public Asteroid(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, float _lifeTime, Vector2 _speed) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _lifeTime, _speed)
        {

            Speed = _speed;

            powerUps = new List<Item>();

            LifeController = new LifeController(this, false, false, _lifeTime);

        }

        public override void Move()
        {

            Transform.Position -= new Vector2(Speed.X * Time.DeltaTime, 0);

        }

        public override void Update()
        {
            if(!LifeController.Destroyed)
            {

                Move();

                CheckForCollisionsWPlayer();

            }
            else
            {


                //Lógica ruleta powerups
            }
        }

        void CheckForCollisionsWPlayer()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {
                if (Program.Characters[i].LifeController.IsPlayer && CircleCollider.CheckforCollisions(Program.Characters[i]))
                {

                    if (CircleCollider.CheckforCollisions(Program.Characters[i]))
                    {

                        //Program.Characters[i].LifeController.GetDamage(Damage);

                        LifeController.Destroyed = true;
                        LifeController.Deactivate(this);

                    }

                }
                //Console.WriteLine("Collision W/ Player");

            }

        }

        void SpawnPowerUp()
        {
            //Random random = new Random();
            //random = random.Next(1, 4);
        }
        void CreatePowerUpsArray()
        {
            powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.damage, Transform.Position));
            powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.life, Transform.Position));
            powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.speed, Transform.Position));
            powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.random, Transform.Position));
        }

        public override void Render()
        {

            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

        }

 
    }
}
