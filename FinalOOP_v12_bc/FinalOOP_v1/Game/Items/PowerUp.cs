using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PowerUp : Item
    {

        Vector2 speed;
        float lifeTime;

        CircleCollider circleCollider;

        LifeController lifeController;

        public Vector2 Speed { get => speed; set => speed = value; }

        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }

        public PowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _rotation, float _colliderRadius, string _texture) : base(_position, _size, _scale, _rotation, _texture)
        {

            Speed = _speed;

            circleCollider = new CircleCollider(Transform, _colliderRadius);
            lifeController = new LifeController(this, 2.3f);

        }

        void PowerUpLifetime()
        {
            float counter = 0;

            counter += Time.DeltaTime;
            //if (counter >= lifeTime)
                //Level1Screen.RenderizableObjects.Remove(this);
        }

        public override void Update()
        {
            lifeController.LifeTimer();
        }

        public virtual void Move()
        {

        }

        public override void Render()
        {
        }



        protected virtual void CheckForCollisionsWithPlayer()
        {

        }
    }
}
