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
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(144, 145), new Vector2(100, 100), "Textures/Enemy1.png", 100, 1, 3);
                case EnemiesFactory.enemyLevel2:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(225,225), new Vector2(200, 200), "Textures/Enemy2.png", 120, 2, 3);
                case EnemiesFactory.enemyLevel3:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(198, 255), new Vector2(400, 400), "Textures/Enemy3.png", 80, 3, 3);
                case EnemiesFactory.enemyLevel4:
                    return new Enemy(position, -90, new Vector2(2, 2), new Vector2(225, 225), new Vector2(200, 200), "Textures/Enemy4.png", 150, 4, 4);
                case EnemiesFactory.finalBossEnemy:
                    return new Enemy(position, -90, new Vector2(1, 1), new Vector2(222, 227), new Vector2(300, 300), "Textures/Enemy5.png", 500, 5, 2);
                default:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(301, 167), new Vector2(300, 300), "Textures/Enemy1.png", 100, 1, 5);
            }
        }
    }
}
