using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static public class Time
    {
        static public DateTime StartDate { get; set; } = DateTime.Now;

        static LevelTimer actualLevelTimer;

        static public float LastFrameTime { get; set; }
        static public float DeltaTime { get; set; }
        static public float actualTime { get; set; }


        public enum LevelTimer { timerLevel1, timerLevel2, timerLevel3, timerLevel4, timerLevel5 }

        public static LevelTimer ActualLevelTimer { get => actualLevelTimer; set => actualLevelTimer = value; }

        static public float GetTime()
        {
            TimeSpan startDifference = DateTime.Now.Subtract(StartDate);
            return (float)(startDifference.TotalMilliseconds / 1000);
        }

        static public void DeltaTimeUpdate()
        {
            float actualTime = GetTime();
            DeltaTime = actualTime - LastFrameTime;
            LastFrameTime = actualTime;
        }
        
    }
}
