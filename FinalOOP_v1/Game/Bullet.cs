using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Bullet<T>: ICharacter, IPoolable<T>
    {
        Vector2 bulletPosition;
        Vector2 bulletSpeed;

        float bulletRotation;
        Vector2 bulletScale;

        Vector2 bulletSize;
        string bulletTexture;

        float bulletLifetime;
        float timer;
        bool destroyed;
        int direction;

        float bulletRadius;

        Transform transform;
        Renderer renderer;
        Collider circleCollider;

        public abstract event SimpleEventHandler<T> OnDeactivate;

        public Vector2 BulletPosition { get => bulletPosition; set => bulletPosition = value; }
        public Vector2 BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

        public float BulletRotation { get => bulletRotation; set => bulletRotation = value; }
        public Vector2 BulletScale { get => bulletScale; set => bulletScale = value; }

        public Vector2 BulletSize { get => bulletSize; set => bulletSize = value; }
        public string BulletTexture { get => bulletTexture; set => bulletTexture = value; }

        public float BulletLifetime { get => bulletLifetime; set => bulletLifetime = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Collider CircleCollider { get => circleCollider; set => circleCollider = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public float Timer { get => timer; set => timer = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }
        public int Direction { get => direction; set => direction = value; }
        public float BulletRadius { get => bulletRadius; set => bulletRadius = value; }


        //public Bullet(Vector2 bulletPosition, Vector2 bulletSpeed, float bulletRotation, Vector2 bulletScale, Vector2 bulletSize, int bulletLifetime, string texture)
        public Bullet()
        {

        }

        public abstract void Init(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture, float radius, float lifeTime, Vector2 speed);

        public abstract void Update();
        public abstract void Render();
        public abstract void Move();
        public abstract void Deactivate();

    }
}
