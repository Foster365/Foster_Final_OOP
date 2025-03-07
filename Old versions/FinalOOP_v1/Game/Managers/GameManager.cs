﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager: IManager
    {
        #region Singleton
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
        #endregion
        int enemyKills = 0;
        private int points;
        Screen actualLevel;

        PowerUpsFactory.PowerUps actualPowerUp;
        //List<Program.ScreenFlow> levelScreens = new List<Program.ScreenFlow>();

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
                //NextLevel();

            }
        }

        public int EnemyKills
        {
            get
            {

                return enemyKills;

            }

            set
            {

                enemyKills = value;
                Console.WriteLine("Enemy Kill Points" + enemyKills);

                //if (enemyKills == 10)
                //    NextLevel();
            }
        }

        //void NextLevel()
        //{

        //    foreach (Program.ScreenFlow item in Enum.GetValues(typeof(Program.ScreenFlow)))
        //    {

        //        //if (enemyKills == 10 && Program.ActualScreenState != Program.ScreenFlow.level5Screen)
        //        //    actualLevel.Update();

        //        levelScreens.Add(item);
        //        for (int i = 0; i < levelScreens.Count; i++)
        //        {

        //            if (enemyKills == 10 && Program.ActualScreenState != Program.ScreenFlow.level5Screen)
        //                Program.ActualScreenState = levelScreens[i];
        //            Console.WriteLine("Switching level");

        //            enemyKills = 0;

        //        }
        //        //tiene que ser el siguiente estado.

        //        //CheckVictory();

        //    }

        //}

        public void CheckVictory()
        {
            if (Program.ActualScreenState == Program.ScreenFlow.level5Screen/* && bossEnemy.destroyed && points >= enemyKillstoWin*/)
            {
                Program.ActualScreenState = Program.ScreenFlow.winScreen;
            }
        }

        public void CheckDefeat()
        {

            for (int i = 0; i < Program.Characters.Count; i++)
            {
                if (Program.Characters[i].LifeController.IsPlayer)
                {

                    if (Program.Characters[i].LifeController.CurrentLife <= 0)
                    {
                        Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;
                    }

                }
            }
        }

        void CreateLifeStack()
        {

            Program.Environment.Add(new HealthIcon(new Vector2(10, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(40, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(70, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(100, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));
            Program.Environment.Add(new HealthIcon(new Vector2(130, 10), new Vector2(.03f, .03f), new Vector2(788, 663), 0, "Textures/Heart.png"));

        }

        //void UpdateLifeStack()
        //{
        //    for (var i = 0; i < Level1Screen.RenderizableObjects.Count; i--)
        //    {

        //        if (player.CurrentHealth == (player.CurrentHealth - 0.2f))
        //            Level1Screen.RenderizableObjects.Remove(Level1Screen.RenderizableObjects[Level1Screen.RenderizableObjects.Count]);
        //    }
        //}


        public void Start()//Init method
        {
            Console.WriteLine("Manager initialized");
            //Program.Managers.Add(this);
        }

        public void Execute()
        {
            //NextLevel();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
