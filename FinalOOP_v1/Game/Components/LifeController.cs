using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {
        Entity entity;
        bool damaged;
        bool destroyed;

        public int MaxLife { get; set; }
        public int CurrentLife { get; set; }
        public float LifeTime { get; set; }
        public bool Damaged { get => damaged; set => damaged = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }

        public LifeController(int _maxLife, Entity _entity)
        {

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            entity = _entity;

        }

        public LifeController(int _maxLife, float _lifeTime, Entity _entity)
        {

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            LifeTime = _lifeTime;

            entity = _entity;

        }

        public LifeController(float _lifeTime, Entity _entity)
        {

            LifeTime = _lifeTime;
            entity = _entity;

        }

        public LifeController(Entity _entity)
        {
            entity = _entity;
        }

        public void GetHealth(int healthPoints)
        {
            CurrentLife += healthPoints;

            if (CurrentLife > MaxLife)
                CurrentLife = MaxLife;

        }

        public void GetDamage(int damagePoints)
        {
            damaged = true;
            CurrentLife -= damagePoints;

            Console.WriteLine("Life Points" + CurrentLife);

            if (CurrentLife <= 0) Die();

        }

        public void Die()
        {
            Level1Screen.RenderizableObjects.Remove(entity);
        }
    }
}
