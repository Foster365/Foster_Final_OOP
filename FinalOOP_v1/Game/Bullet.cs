using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Bullet: Entity, ICharacter, IPoolable<Bullet>
    {
        public abstract event Action<Bullet> OnDeactivate;

        public float BulletLifetime { get; private set; }

        protected float timer;

        public Bullet() : base ()
        {
        }

        public virtual void Init(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture, float radius, Vector2 speed, float lifeTime)
        {
            Initialize(position, scale, size, rotation, texture, radius, speed);

            BulletLifetime = lifeTime;
            timer = 0;
            Destroyed = false;

            Level1Screen.RenderizableObjects.Add(this);
        }

        public abstract void Deactivate();
    }
}
