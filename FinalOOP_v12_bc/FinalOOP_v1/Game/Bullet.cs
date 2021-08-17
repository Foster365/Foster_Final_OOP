using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Bullet<T> : Entity, ICharacter, IPoolable<T>
    {

        //Entity target;

        public abstract event Action<T> OnDeactivate;

        public float BulletLifetime { get; private set; }

        protected float timer;

        public Bullet(/*Entity _target*/) : base ()
        {

            //target = _target;

        }

        public virtual void Init(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture, float radius, Vector2 speed, int damage, float lifeTime)
        {

            Initialize(position, scale, size, rotation, texture, damage, radius, speed);

            BulletLifetime = lifeTime;
            timer = 0;
            //LifeController.Destroyed = false;

            LifeController = new LifeController(this, false, false, lifeTime);

            //circleCollider = new CircleCollider(Transform, radius);

            Program.Characters.Add(this);
        }

        //public abstract void Deactivate();
    }
}
