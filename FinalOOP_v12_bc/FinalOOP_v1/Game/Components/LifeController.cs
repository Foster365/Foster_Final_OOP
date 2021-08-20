using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {

        #region Variables
        Entity entity;
        Item item;
        bool damaged;
        bool destroyed;
        float lifeTimer;
        bool isEnemy;
        bool isPlayer;
        Vector2 entityPos;

        Image damageArea;

        public int MaxLife { get; set; }
        public int CurrentLife { get; set; }
        public float LifeTime { get; set; }
        public bool Damaged { get => damaged; set => damaged = value; }
        public bool Destroyed { get => destroyed; set => destroyed = value; }
        public bool IsEnemy { get => isEnemy; set => isEnemy = value; }
        public bool IsPlayer { get => isPlayer; set => isPlayer = value; }

        public Vector2 EntityPos { get => entityPos; set => entityPos = value; }

        public event Action<LifeController> OnDeactivate;

        //Animation Variables

        Animation deathAnimation;

        enum Animations { deathAnimation }

        Animations actualAnimstate = Animations.deathAnimation;
        //

        #endregion

        #region constructors

        public LifeController(Entity _entity, bool _isEnemy, bool _isPlayer, int _maxLife)
        {

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            damageArea = new Image(entity.Transform.Position, new Vector2(.5f, .5f), new Vector2(739, 731), 0, "Textures/Entities/Characters/Character_damage.png");

            destroyed = false;

            AnimationParameters();

        }

        public LifeController(Entity _entity, bool _isEnemy, bool _isPlayer, int _maxLife, float _lifeTime)
        {

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            MaxLife = _maxLife;
            CurrentLife = _maxLife;

            LifeTime = _lifeTime;

            damageArea = new Image(entity.Transform.Position, new Vector2(.5f, .5f), new Vector2(739, 731), 0, "Textures/Entities/Characters/Character_damage.png");

            destroyed = false;

            AnimationParameters();

        }

        public LifeController(Entity _entity, bool _isEnemy, bool _isPlayer, float _lifeTime)
        {

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;
            LifeTime = _lifeTime;

            damageArea = new Image(entity.Transform.Position, new Vector2(.5f, .5f), new Vector2(739, 731), 0, "Textures/Entities/Characters/Character_damage.png");

            destroyed = false;

            AnimationParameters();

        }

        public LifeController(Entity _entity, bool _isEnemy, bool _isPlayer)
        {

            entity = _entity;
            isEnemy = _isEnemy;
            isPlayer = _isPlayer;

            damageArea = new Image(entity.Transform.Position, new Vector2(.5f, .5f), new Vector2(739, 731), 0, "Textures/Entities/Characters/Character_damage.png");

            destroyed = false;

            AnimationParameters();

        }

        public LifeController(Item _item, float _lifeTime)
        {
            item = _item;
            LifeTime = _lifeTime;
        }

        #endregion

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
                Deactivate(entity);

        }
        
        public void GetDamage(int damagePoints)
        {
            Vector2 damagePosition = new Vector2(entity.Transform.Position.X, entity.Transform.Position.Y);
            damaged = true;
            CurrentLife -= damagePoints;
            RenderDamageCircle();
            Console.WriteLine($"Circle rendered in {entity.Transform.Position.X} {entity.Transform.Position.Y}");
            Console.WriteLine(entity + "Life Points" + CurrentLife);
            if (CurrentLife <= 0)
            {

                Deactivate(entity);

            }
        }

        void RenderDamageCircle()
        {
            damageArea.Render();
        }

        public void Deactivate(Entity e)
        {

            Console.WriteLine("Deactivating entity");

            //RenderAnimation();

            //OnDeactivate?.Invoke(this);

            Program.Characters.Remove(e);

            Program.Environment.Remove(e);

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

                Engine.Draw(deathAnimation.AnimList[deathAnimation.ActualAnimationFrame], 300, 100, 3, 3, 0, 0, 0);
                //Engine.Draw(levelCountdown.AnimList[levelCountdown.ActualAnimationFrame], 750, 10, .5f, .5f, 0, 0, 0);

            }

        }
    }
}
