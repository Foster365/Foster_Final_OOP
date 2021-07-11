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
        float lifeTimer;
        bool isEnemy;
        bool isPlayer;

        public int MaxLife { get; set; }
        public int CurrentLife { get; set; }
        public float LifeTime { get; set; }
        public bool Damaged { get => damaged; set => damaged = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }
        public bool IsEnemy { get => isEnemy; set => isEnemy = value; }
        public bool IsPlayer { get => isPlayer; set => isPlayer = value; }

        public event Action<LifeController> OnDeactivate;

        //Animation Variables

        Animation deathAnimation;

        enum Animations { deathAnimation }

        Animations actualAnimstate = Animations.deathAnimation;
        //

        public LifeController(int _maxLife, Entity _entity, bool _isEnemy, bool _isPlayer)
        {

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            AnimationParameters();

        }

        public LifeController(int _maxLife, float _lifeTime, Entity _entity, bool _isEnemy, bool _isPlayer)
        {

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            LifeTime = _lifeTime;

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            AnimationParameters();

        }

        public LifeController(float _lifeTime, Entity _entity, bool _isEnemy, bool _isPlayer)
        {

            LifeTime = _lifeTime;
            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            AnimationParameters();

        }

        public LifeController(Entity _entity, bool _isEnemy, bool _isPlayer)
        {

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            AnimationParameters();

        }

        public void GetHealth(int healthPoints)
        {

            CurrentLife += healthPoints;

            if (CurrentLife > MaxLife)
                CurrentLife = MaxLife;

        }

        public void LifeTimer()
        {

            lifeTimer += Time.DeltaTime;
            //Console.WriteLine("LifeTiner" + lifeTimer);

            if (lifeTimer >= LifeTime)
                Deactivate();

        }
        
        public void GetDamage(int damagePoints)
        {

            damaged = true;
            CurrentLife -= damagePoints;

            Console.WriteLine(entity + "Life Points" + CurrentLife);
            if (CurrentLife <= 0)
            {

                Deactivate();

            }
        }

        public void Deactivate()
        {

            Console.WriteLine("Deactivating entity");

            RenderAnimation();

            OnDeactivate?.Invoke(this);

            Program.Characters.Remove(entity);

            Program.Environment.Remove(entity);

        }

        void AnimationParameters()
        {

            List<Texture> deathFrames = new List<Texture>();

            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion1.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion2.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion3.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion4.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion5.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion6.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion7.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion8.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion9.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion10.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion11.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion12.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion13.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion14.png"));
            deathFrames.Add(Engine.GetTexture("Textures/Explosion/Explosion15.png"));

            //for (int i = 1; i < 15; i++)
            //{

            //    deathFrames.Add(Engine.GetTexture("Textures/Explosion/" + i.ToString() + ".png"));

            //}

            deathAnimation = new Animation(deathFrames, .05f, false);

        }

        public void UpdateAnimation()
        {
            if (actualAnimstate == Animations.deathAnimation)
            {

                actualAnimstate = Animations.deathAnimation;
                deathAnimation.Play();

            }

        }

        public void RenderAnimation()
        {

            if (actualAnimstate == Animations.deathAnimation)
            {

                

            }
        }
    }
}
