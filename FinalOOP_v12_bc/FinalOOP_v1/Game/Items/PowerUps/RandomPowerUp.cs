using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class RandomPowerUp : PowerUp
    {


        float hp;

        Level1Screen level1;

        Roulette _roulette;
        Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
        Node _initNode;

        public RandomPowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _rotation, float _colliderRadius, string _texture) : base(_position, _scale, _size, _speed, _rotation, _colliderRadius, _texture)
        {

        }

        void RouletteWheel()
        {

            _roulette = new Roulette();

            ActionNode speedPowerUp = new ActionNode(SpeedPowerUpAN);
            ActionNode healthPowerUp = new ActionNode(HealthPowerUpAN);
            ActionNode damagePowerUp = new ActionNode(DamagePowerUpAN);

            ActionNode rouletteNode = new ActionNode(RouletteAction);

        }
        
        void RouletteAction()
        {

            Node nodeRoulette = _roulette.Run(_rouletteNodes);
            nodeRoulette.Execute();

        }

        void SpeedPowerUpAN()
        {
            PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.speed, Transform.Position);
        }

        void HealthPowerUpAN()
        {
            PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.life, Transform.Position);
        }

        void DamagePowerUpAN()
        {
            PowerUpsFactory.CreatePowerUp(PowerUpsFactory.PowerUps.damage, Transform.Position);
        }
        public override void Update()
        {

            //CircleCollider.CheckforCollisions(level1.Player);

            Move();

        }

        public void Heal()
        {
            //if (CircleCollider.CheckforCollisions());
            //  player.CurrentLife = player.CurrentLife + hp;
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
