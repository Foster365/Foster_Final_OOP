using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Bullet<T>: ICharacter, IPoolable<T>
    {

        Vector2 bulletSpeed;

        float bulletRotation;
        Vector2 bulletScale;

        Vector2 bulletSize;
        string bulletTexture;

        float bulletLifetime;
        float timer;
        bool destroyed;

        float colliderRadius;

        Transform transform;
        Renderer renderer;
        Collider circleCollider;

        public abstract event SimpleEventHandler<T> OnDeactivate;

        public float ColliderRadius { get => colliderRadius; set => colliderRadius = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Collider CircleCollider { get => circleCollider; set => circleCollider = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public float BulletLifetime { get => bulletLifetime; set => bulletLifetime = value; }
        public float Timer { get => timer; set => timer = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }
        public Vector2 BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

        public Bullet(Vector2 _position, Vector2 _scale, Vector2 _size, Vector2 _speed, float _rotation, string _texture, float _colliderRadius, float _lifeTime)
        {

            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, _texture, transform);

            circleCollider = new CircleCollider(transform, _colliderRadius);

            colliderRadius = _colliderRadius;

        }

        //public abstract void Init(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture, float radius, float lifeTime, Vector2 speed);

        public abstract void Update();
        public abstract void Render();
        public abstract void Move();
        public abstract void Deactivate();

    }
}
