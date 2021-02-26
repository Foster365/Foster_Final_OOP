using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : Collideable, ICharacter
    {
        protected Transform transform;
        protected Renderer renderer;
        protected float colliderRadius;
        protected CircleCollider circleCollider;
        protected BoxCollider boxCollider;
        protected Vector2 speed;

        // TODO: esto tendria que estar en componentes diferentes (HealthController por ejemplo)

        protected float maxHealth = 100; float currentHealth;
        protected float damage;
        protected float lifeTime;
        protected float lifeTimer;
        protected bool damaged;
        protected bool destroyed;

        public float CurrentHealth { get => currentHealth; set => currentHealth = maxHealth; }
        public float Damage { get => damage; set => damage = value; }

        public Vector2 Speed { get => speed; set => speed = value; }

        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Transform Transform { get => transform; set => transform = value; }
        public float ColliderRadius { get => colliderRadius; set => colliderRadius = value; }

        public bool Damaged { get => damaged; set => damaged = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }

        public float LifeTime { get => lifeTime; set => lifeTime = value; }
        public float LifeTimer { get => lifeTimer; set => lifeTimer = value; }
        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }

        public Entity()
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
        }

        public Entity(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, float _colliderRadius, Vector2 _speed)
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
            Initialize(_position, _scale, _size, _rotation, _texture, _colliderRadius, _speed);
        }

        public void Initialize(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, float _colliderRadius, Vector2 _speed)
        {
            colliderRadius = _colliderRadius;
            speed = _speed;

            transform.Position = _position;
            transform.Scale = _scale;
            transform.Rotation = _rotation;

            renderer.Texture = _texture;
            renderer.Size = _size;

            Console.WriteLine(this + "Transform x " + transform.Position.X + "Transform y " + transform.Position.Y);

            boxCollider = new BoxCollider(transform, colliderRadius);
            circleCollider = new CircleCollider(transform, colliderRadius);
        }

        public abstract void Render();
        public abstract void Update();
        public abstract void Move();
        //public abstract void TakeDamage(float damage);
        //public abstract void Die();

    }
}
