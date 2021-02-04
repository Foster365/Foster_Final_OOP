using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : ICharacter
    {

        //Transform and Renderer Variables
        Vector2 position;
        float rotation;
        Vector2 scale;

        Vector2 size;
        string texture;
        float radius;

        Transform transform;
        Renderer renderer;
        //

        //Collider Variables
        float colliderRadius;

        CircleCollider circleCollider;
        BoxCollider boxCollider;

        //

        //Vector2 enemySpeed;

        //Character attributes

        float maxHealth = 100; float currentHealth;
        float damage;

        float lifeTime; float lifeTimer;

        Vector2 speed;

        float angle;

        bool damaged;
        bool destroyed;

        ////

        //Encapsuladas

        public float CurrentHealth { get => currentHealth; set => currentHealth = maxHealth; }
        public float Damage { get => damage; set => damage = value; }

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Size { get => size; set => size = value; }
        public string Texture { get => texture; set => texture = value; }

        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Transform Transform { get => transform; set => transform = value; }
        public float ColliderRadius { get => colliderRadius; set => colliderRadius = value; }

        public bool Damaged { get => damaged; set => damaged = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }

        public float LifeTime { get => lifeTime; set => lifeTime = value; }
        public float LifeTimer { get => lifeTimer; set => lifeTimer = value; }
        public float Angle { get => angle; set => angle = value; }
        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }

        public Entity(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, float _colliderRadius)
        {

            ColliderRadius = _colliderRadius;

            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, _texture, Transform);

            boxCollider = new BoxCollider(transform, renderer, colliderRadius);
            circleCollider = new CircleCollider(transform, renderer, colliderRadius);

            //circleCollider = new CircleCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, radius);
            //boxCollider = new BoxCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, radius);
        }

        public abstract void Render();
        public abstract void Update();
        public abstract void Move();
        public abstract void TakeDamage(float damage);
        public abstract void Die();

    }
}
