using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class EnemyFactory
    {
        public enum EnemiesFactory {  enemyLevel1, enemyLevel2, enemyLevel3, enemyLevel4, finalBossEnemy }

        public static Enemy CreateEnemy(EnemiesFactory enemy, Vector2 position)
        {
            switch (enemy)
            {
                //Agrego opcion para agregar posicion random
                case EnemiesFactory.enemyLevel1:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(144, 145), new Vector2(50, 50), "Textures/Enemy1.png", 100, 1, 10, 30);
                case EnemiesFactory.enemyLevel2:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(225,225), new Vector2(100, 100), "Textures/Enemy2.jpg", 120, 2, 30, 30);
                case EnemiesFactory.enemyLevel3:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(182, 223), new Vector2(400, 400), "Textures/Enemy3.png", 80, 3, 10, 30);
                case EnemiesFactory.enemyLevel4:
                    return new Enemy(position, -90, new Vector2(2, 2), new Vector2(177, 189), new Vector2(200, 200), "Textures/Enemy4.png", 150, 4, 10, 30);
                case EnemiesFactory.finalBossEnemy:
                    return new Enemy(position, -90, new Vector2(1, 1), new Vector2(207, 226), new Vector2(50, 50), "Textures/Boss.png", 500, 5, 40, 50);
                default:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(144, 145), new Vector2(50, 50), "Textures/Enemy1.png", 100, 1, 10, 30);
            }
        }
    }
}
