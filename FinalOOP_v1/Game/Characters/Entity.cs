using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : ICharacter
    {
        protected Transform transform;
        protected Renderer renderer;

        protected float colliderRadius;

        protected LifeController lifeController;
        protected CircleCollider circleCollider;
        //protected BoxCollider boxCollider;

        protected Vector2 speed;
        private int damage;

        public Vector2 Speed { get => speed; set => speed = value; }
        public int Damage { get => damage; set => damage = value; }

        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Transform Transform { get => transform; set => transform = value; }
        public float ColliderRadius { get => colliderRadius; set => colliderRadius = value; }

        public CircleCollider CircleCollider { get => circleCollider; set => circleCollider = value; }
        //public BoxCollider BoxCollider { get => boxCollider; set => boxCollider = value; }
        public LifeController LifeController { get => lifeController; set => lifeController = value; }

        #region Constructors
        public Entity()
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);
        }

        public Entity(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, Vector2 _speed)
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
            Initialize(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _speed);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);

        }

        public Entity(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, int _maxHealth, Vector2 _speed)
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
            Initialize(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _maxHealth, _speed);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);

        }

        public Entity(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, float _lifeTime, Vector2 _speed)
        {
            transform = new Transform(new Vector2(0f, 0f), new Vector2(1, 1), 0f);
            renderer = new Renderer(new Vector2(1, 1), null, transform);
            Initialize(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _lifeTime, _speed);
            Console.WriteLine($"colliderRadius: {colliderRadius}");
            //CircleCollider.Colliders.Add(this);
        }
        #endregion

        #region Initializers
        public void Initialize(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, int _maxHealth, Vector2 _speed)
        {
            colliderRadius = _colliderRadius;

            speed = _speed;
            Damage = _damage;

            transform.Position = _position;
            transform.Scale = _scale;
            transform.Rotation = _rotation;

            renderer.Texture = _texture;
            renderer.Size = _size;

            //boxCollider = new BoxCollider(transform, colliderRadius);
            circleCollider = new CircleCollider(transform, colliderRadius);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);

        }

        public void Initialize(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, Vector2 _speed)
        {
            colliderRadius = _colliderRadius;

            speed = _speed;
            Damage = _damage;

            transform.Position = _position;
            transform.Scale = _scale;
            transform.Rotation = _rotation;

            renderer.Texture = _texture;
            renderer.Size = _size;

            boxCollider = new BoxCollider(transform, colliderRadius);
            circleCollider = new CircleCollider(transform, colliderRadius);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);
        }
        
        public void Initialize(Vector2 _position, Vector2 _scale, Vector2 _size, float _rotation, string _texture, int _damage, float _colliderRadius, float _lifeTime, Vector2 _speed)
        {

            colliderRadius = _colliderRadius;

            speed = _speed;
            Damage = _damage;

            transform.Position = _position;
            transform.Scale = _scale;
            transform.Rotation = _rotation;

            renderer.Texture = _texture;
            renderer.Size = _size;

            boxCollider = new BoxCollider(transform, colliderRadius);
            circleCollider = new CircleCollider(transform, colliderRadius);
            Console.WriteLine($"colliderRadius: {colliderRadius}");

            //CircleCollider.Colliders.Add(this);

        }
        #endregion
        public abstract void Render();
        public abstract void Update();
        public abstract void Move();

    }
}
