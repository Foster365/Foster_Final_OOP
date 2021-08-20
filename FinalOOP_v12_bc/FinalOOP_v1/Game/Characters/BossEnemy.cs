using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossEnemy : Entity
    {

        List<PowerUp> enemies = new List<PowerUp>();

        Roulette roulette;
        Dictionary<Node, int> dict = new Dictionary<Node, int>();
        Node initNode;

        //Variables
        Pursuit pursuitBehaviour;
        ObjectsPool<PlayerBullet> poolBullets = new ObjectsPool<PlayerBullet>();

        float timerShoot;
        float timetoShoot;

        float timeToCreate = 0;
        float maxTimeToCreate = 10;

        Enemy[] enemiesCollection;


        Vector2 targetPosition = new Vector2(0, 0);

        //

        public BossEnemy(Vector2 _position, float _rotation, Vector2 _scale, Vector2 _size, Vector2 _enemySpeed, string _texture, int _maxHealth, float _angle, float _lifetime, int _damage, float _colliderRadius) : base(_position, _scale, _size, _rotation, _texture, _damage, _colliderRadius, _enemySpeed)/*(position, rotation, scale, size, enemySpeed, texture, life)*/
        {

            Speed = _enemySpeed;
            timetoShoot = 0.8f;

            LifeController = new LifeController(this, true, false);

            InitRouletteWheel();

            //pursuitBehaviour = new Pursuit(Transform.Position, player.Transform.Position, Speed, 1);

        }

        public override void Update()
        {

            if (!LifeController.Destroyed)
            {

                Move();

                LifeController.LifeTimer();

                //CreateEnemies();

                timeToCreate += Time.DeltaTime;

                if (timeToCreate >= maxTimeToCreate)
                {

                    RouletteAction();
                    timeToCreate = 0;

                }

            }

        }

        public void Shoot()
        {
            var enemyBullet = poolBullets.Get();
            enemyBullet.Init(Transform.Position, new Vector2(1, 1), new Vector2(24, 27), 0, "Textures/BulletEnemy1.png", 10, new Vector2(50, 50), 10, 4);
            //Console.WriteLine("PlayerPos.X" + Transform.Position.X + "PlayerPos.Y" + Transform.Position.Y, "bulletScale.X" + enemyBullet.Transform.Scale.X + "bulletScale.Y" + enemyBullet.Transform.Scale.Y + "bulletSize.X"
            //    + enemyBullet.Renderer.Size.X + "bulletSize.Y" + enemyBullet.Renderer.Size.Y, "bulletRotation" + enemyBullet.Transform.Rotation + "bulletTexture" + enemyBullet.Renderer.Texture);

        }

        #region Power Up Roulette Wheel

        public void InitRouletteWheel()
        {
            roulette = new Roulette();

            ActionNode enemiesLevel1 = new ActionNode(SpawnEnemiesLevel1);
            ActionNode enemiesLevel2 = new ActionNode(SpawnEnemiesLevel2);
            ActionNode enemiesLevel3 = new ActionNode(SpawnEnemiesLevel3);
            ActionNode enemiesLevel4 = new ActionNode(SpawnEnemiesLevel4);
            ActionNode enemiesAllLevels = new ActionNode(SpawnAllEnemyTypes);

            dict.Add(enemiesLevel1, 60);
            dict.Add(enemiesLevel2, 20);
            dict.Add(enemiesLevel3, 10);
            dict.Add(enemiesLevel4, 30);
            dict.Add(enemiesAllLevels, 30);

            ActionNode rouletteAction = new ActionNode(RouletteAction);

        }

        public void RouletteAction()
        {
            Console.WriteLine("Power Up Roulette Wheel initialized");
            Node nodeRoulette = roulette.Run(dict);
            nodeRoulette.Execute();
        }

        public void SpawnEnemiesLevel1()
        {

            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 10, Transform.Position.Y + 10)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 35, Transform.Position.Y + 20)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 70, Transform.Position.Y + 30)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 100, Transform.Position.Y + 40)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 130, Transform.Position.Y + 50)));

            Console.WriteLine("Enemies level 1 Deployed");

        }
        public void SpawnEnemiesLevel2()
        {

            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 10, Transform.Position.Y + 10)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 35, Transform.Position.Y + 20)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 70, Transform.Position.Y + 30)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 100, Transform.Position.Y + 40)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 130, Transform.Position.Y + 50)));

            Console.WriteLine("Enemies level 2 Deployed");

        }
        public void SpawnEnemiesLevel3()
        {

            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 10, Transform.Position.Y + 10)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 35, Transform.Position.Y + 20)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 70, Transform.Position.Y + 30)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 100, Transform.Position.Y + 40)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 130, Transform.Position.Y + 50)));

            Console.WriteLine("Enemies level 3 Deployed");

        }

        public void SpawnEnemiesLevel4()
        {

            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 10, Transform.Position.Y + 10)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 35, Transform.Position.Y + 20)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 70, Transform.Position.Y + 30)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 100, Transform.Position.Y + 40)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 130, Transform.Position.Y + 50)));

            Console.WriteLine("Enemies level 4 Deployed");

        }

        public void SpawnAllEnemyTypes()
        {

            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(Transform.Position.X + 10, Transform.Position.Y + 10)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel2, new Vector2(Transform.Position.X + 35, Transform.Position.Y + 20)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 70, Transform.Position.Y + 30)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel4, new Vector2(Transform.Position.X + 100, Transform.Position.Y + 40)));
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel3, new Vector2(Transform.Position.X + 130, Transform.Position.Y + 50)));

            Console.WriteLine("Enemies all levels Deployed");

        }
        #endregion;

        void CreateEnemies()
        {

            //float createEnemiesTimer = 0;
            //float createEnemiesMaxTimer = 10f;

            //Random random = new Random();

            ////Vector2 enemyPos = new Vector2(random.Next(850, 800), random.Next(200, 250));

            //createEnemiesMaxTimer += Time.DeltaTime;

            ////foreach (Enemy e in Program.Characters)
            ////{

            //if (createEnemiesTimer >= createEnemiesMaxTimer)
            //{
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(500, 150)));
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(550, 200)));
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(600, 250)));
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(750, 300)));
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(800, 350)));
            //    Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.enemyLevel1, new Vector2(850, 400)));
            //}

            ////}

        }


        public override void Move()
        {

            Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Transform.Position.Y <= 0)
                Transform.Position += new Vector2(0, Speed.Y * Time.DeltaTime);

            if (Transform.Position.Y > 600)
                Transform.Position -= new Vector2(0, Speed.Y * Time.DeltaTime);

        }

        public override void Render()
        {
            if (!LifeController.Destroyed)
            {

                Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation, Renderer.GetRealWidth() / 2, Renderer.GetRealHeight() / 2);

            }
        }

    }
}
