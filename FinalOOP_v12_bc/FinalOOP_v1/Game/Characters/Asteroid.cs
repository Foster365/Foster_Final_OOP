using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Asteroid : Entity
    {

        List<PowerUp> powerUps = new List<PowerUp>();

        Roulette roulette;
        Dictionary<Node, int> dict = new Dictionary<Node, int>();
        Node initNode;

        //MCU
        //float angle;
        //float angularSpeed;

        public Asteroid(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, float _lifeTime, Vector2 _speed) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _lifeTime, _speed)
        {

            Speed = _speed;



            //powerUps = new List<PowerUp>();

            LifeController = new LifeController(this, false, false, _lifeTime);

            InitRouletteWheel();

        }

        #region Power Up Roulette Wheel

        public void InitRouletteWheel()
        {
            roulette = new Roulette();

            ActionNode healthPowerUp = new ActionNode(SpawnHealthPowerUp);
            ActionNode damagePowerUp = new ActionNode(SpawnDamagePowerUp);
            ActionNode speedPowerUp = new ActionNode(SpawnSpeedPowerUp);
            ActionNode noPowerUp = new ActionNode(SpawnNonePowerUp);

            dict.Add(healthPowerUp, 60);
            dict.Add(damagePowerUp, 20);
            dict.Add(speedPowerUp, 10);
            dict.Add(noPowerUp, 30);

            ActionNode rouletteAction = new ActionNode(RouletteAction);

        }

        public void RouletteAction()
        {
            Console.WriteLine("Power Up Roulette Wheel initialized");
            Node nodeRoulette = roulette.Run(dict);
            nodeRoulette.Execute();
        }

        public void SpawnDamagePowerUp()
        {

            Program.Environment.Add(new DamagePowerUp(new Vector2(750, 300), new Vector2(.1f, .1f), new Vector2(206, 205), new Vector2(20, 20), 5, 0, 10, 30, "Textures/PowerUps/DamagePowerUp.png"));

            Console.WriteLine("Damage Power Up Deployed");

        }
        public void SpawnHealthPowerUp()
        {

            Program.Environment.Add(new HealthPowerUp(new Vector2(750, 300), new Vector2(.15f, .15f), new Vector2(179, 118), new Vector2(1, 1), 10, 0, 10, 10, "Textures/PowerUps/HealthPowerUp.png"));

            Console.WriteLine("Health Power Up Deployed");

        }
        public void SpawnSpeedPowerUp()
        {
            Program.Environment.Add(new SpeedPowerUp(new Vector2(750, 300), new Vector2(.1f, .1f), new Vector2(296, 558), new Vector2(10, 10), new Vector2(5, 5), 2.5f, 0, 10, "Textures/PowerUps/SpeedPowerUp.png"));

            Console.WriteLine("Speed Power Up Deployed");

        }

        public void SpawnNonePowerUp()
        {
            //powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.damage, Transform.Position));
            Console.WriteLine("No PowerUp");

        }
        #endregion;

        public override void Move()
        {

            Transform.Position -= new Vector2(Speed.X * Time.DeltaTime, 0);

        }

        public override void Update()
        {
            if (!LifeController.Destroyed)
            {

                Move();

                CheckForCollisionsWPlayer();

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

                        RouletteAction();

                        //Program.Characters[i].LifeController.GetDamage(Damage);

                        LifeController.Destroyed = true;

                        //powerUps.Add(PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.damage, new Vector2(400, 400)));


                        LifeController.Deactivate(this);

                    }

                }
                //Console.WriteLine("Collision W/ Player");

            }

        }
        public override void Render()
        {

            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

        }

    }
}
