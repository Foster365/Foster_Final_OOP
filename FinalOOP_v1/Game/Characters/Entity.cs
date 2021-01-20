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

        bool destroyed;

        ////


        public float CurrentHealth { get => currentHealth; set => currentHealth = maxHealth; }

        //Encapsuladas
        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Size { get => size; set => size = value; }
        public string Texture { get => texture; set => texture = value; }
        public float Radius { get => radius; set => radius = value; }

        public Renderer Renderer { get; set; }
        public Transform Transform { get; set; }
        public float ColliderRadius { get => colliderRadius; set => colliderRadius = value; }

        public bool Destroyed { get => destroyed; set => destroyed = value; }

        public float LifeTime { get => lifeTime; set => lifeTime = value; }
        public float LifeTimer { get => lifeTimer; set => lifeTimer = value; }
        public float Angle { get => angle; set => angle = value; }

        public Entity(/*Transform _transform, Renderer _renderer, */float _colliderRadius)
        {
            colliderRadius = _colliderRadius;

            //circleCollider = new CircleCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, radius);
            //boxCollider = new BoxCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, radius);
        }

        public abstract void Render();

        public abstract void Update();

        public abstract void TakeDamage();
        public abstract void Die();

    }
}
