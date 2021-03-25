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

        public static Entity CreateEnemy(EnemiesFactory enemy, Vector2 position)
        {
            //Nave1 = new Nave("Ship.png", 150, 400, (float)Math.Cos(0));
            //Nave2 = new Nave("ship.png", 250, 500, (float)Math.Sin(0)*200*250);
            //Nave3 = new Nave("ship.png", 50, 300, (float)Math.Cos(0)*50*250);
            switch (enemy)
            {
                //Agrego opcion para agregar posicion random
                case EnemiesFactory.enemyLevel1:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(144, 145), new Vector2(100, 100), "Textures/Entities/Characters/Enemy1.png", 100, 0, 30, 5, 30);
                case EnemiesFactory.enemyLevel2:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(31, 48), new Vector2(100, 100), "Textures/Entities/Characters/Enemy2.jpg", 100, 0, 20, 10, 30);
                case EnemiesFactory.enemyLevel3:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(182, 223), new Vector2(400, 400), "Textures/Entities/Characters/Enemy3.png", 80, 0, 8, 5, 30);
                case EnemiesFactory.enemyLevel4:
                    return new Enemy(position, -90, new Vector2(2, 2), new Vector2(177, 189), new Vector2(200, 200), "Textures/Entities/Characters/Enemy4.png", 130, 0, 15, 15, 30);
                case EnemiesFactory.finalBossEnemy:
                    return new BossEnemy(position, -90, new Vector2(1, 1), new Vector2(207, 226), new Vector2(50, 50), "Textures/Entities/Characters/Boss.png", 500, 0, 60, 40, 50);
                default:
                    return new Enemy(position, -90, new Vector2(0.5f, 0.5f), new Vector2(144, 145), new Vector2(100, 100), "Textures/Entities/Characters/Enemy1.png", 100, 0, 30, 5, 30);
            }
        }
    }
}
