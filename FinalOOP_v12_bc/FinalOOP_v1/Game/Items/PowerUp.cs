using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class PowerUp : Item
    {

        Vector2 speed;
        protected float lifeTime;

        CircleCollider circleCollider;

        LifeController lifeController;

        public Vector2 Speed { get => speed; set => speed = value; }

        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        public LifeController LifeController { get => lifeController; set => lifeController = value; }

        public PowerUp(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _lifeTime, float _rotation, float _colliderRadius, string _texture) : base(_position, _size, _scale, _rotation, _texture)
        {

            Speed = _speed;
            lifeTime = _lifeTime;

            circleCollider = new CircleCollider(Transform, _colliderRadius);
            lifeController = new LifeController(this, lifeTime);

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

        public abstract void Move();

        public override void Render()
        {

            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

        }

        protected virtual void CheckForCollisionsWithPlayer()
        {

        }
    }
}
