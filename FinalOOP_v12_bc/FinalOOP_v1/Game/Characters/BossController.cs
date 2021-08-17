using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossController
    {

        BossEnemy bossEnemy;

        public BossController()
        {
            Start();
        }

        void Start()
        {
            Vector2 enemyBossPosition = new Vector2(800, 150);
            Program.Characters.Add(EnemyFactory.CreateEnemy(EnemyFactory.EnemiesFactory.finalBossEnemy, enemyBossPosition));

        }

        void Render()
        {
            //boss
        }

    }
}
