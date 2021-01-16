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
                enemyKillstoWin = value;
            }
        }

        private void CheckVictory()
        {
            if (Program.ActualScreenState == Program.ScreenFlow.level5Screen && points >= enemyKillstoWin)
            {
                Program.ActualScreenState = Program.ScreenFlow.winScreen;
            }
        }

        private void CheckDefeat()
        {
            if (player.Life <= 0)
            {
                Program.ActualScreenState = Program.ScreenFlow.gameOverScreen;
            }
        }
    }
}
