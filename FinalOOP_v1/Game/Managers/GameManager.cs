using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        private int enemyKillstoWin;
        private int points;
        private Player player { get; set; }
        PowerUpsFactory.PowerUps actualPowerUp;

        //BossEnemy bossEnemy{get;set;}

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
                Engine.Debug("Puntos: " + points);
                CheckVictory();
            }
        }

        public int WinPoints
        {
            get
            {
                return enemyKillstoWin;
            }

            set
            {
                enemyKillstoWin = 10;
            }
        }

        private void CheckVictory()
        {
            if (Program.ActualScreenState == Program.ScreenFlow.level5Screen/* && bossEnemy.destroyed && points >= enemyKillstoWin*/)
            {
                Program.ActualScreenState = Program.ScreenFlow.winScreen;
            }
        }

        //private void CheckDefeat()
        //{
        //    if (player.lifeController.CurrentHealth<= 0)
        //    {
        //        Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;
        //    }
        //}

        //void UpdateLifeStack()
        //{
        //    for (var i = 0; i < Level1Screen.RenderizableObjects.Count; i--)
        //    {

        //        if (player.CurrentHealth == (player.CurrentHealth - 0.2f))
        //            Level1Screen.RenderizableObjects.Remove(Level1Screen.RenderizableObjects[Level1Screen.RenderizableObjects.Count]);
        //    }
        //}

        void SpawnPowerUp()
        {

            foreach (PowerUpsFactory.PowerUps actualPowerUp in Enum.GetValues(typeof(PowerUpsFactory.PowerUps)))
            {

                //if (player.Damaged)
                //    Level1Screen.RenderizableObjects.Add(PowerUpsFactory.CreatePowerUp(actualPowerUp));


            }
                
        }

    }
}
