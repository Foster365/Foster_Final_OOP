using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Vector2
    {

        #region Attributes
        public float X { get; set; }
        public float Y { get; set; }
        #endregion

        #region Construct
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Static
        public static Vector2 ZeroVector()
        {

            return new Vector2(0, 0);
        }

        public static Vector2 Up()
        {
            return new Vector2(0, 1);
        }

        public static Vector2 Down()
        {
            return new Vector2(0, -1);
        }

        public static Vector2 Left()
        {
            return new Vector2(-1, 0);
        }

        public static Vector2 Right()
        {
            return new Vector2(1, 0);
        }

        public static Vector2 NegativeInfinity()
        {
            return new Vector2(float.NegativeInfinity, float.NegativeInfinity);
        }

        public static Vector2 PositiveInfinity()
        {
            return new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        }
        #endregion

        #region Properties
        public static float Magnitude(float x, float y)
        {
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            return magnitude;
        }

        public static Vector2 NormalizedVector(float x, float y)
        {
            return new Vector2(1, 1);
        }

        public static float SqrMagnitude(float x, float y)
        {
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            return magnitude * magnitude;
        }

        //public static float Thisnumber(int number)
        //{
        //    Vector2 p = new Vector2();
        //    if (number==0||number==1)
        //    {
        //        if (number == 0)
        //        {
        //            return p.X;
        //        }

        //        else
        //        {
        //            return p.Y;
        //        }
        //    }
        //}

        public static float GetXComponent(float x, float y)
        {
            Vector2 vec = new Vector2(x, y);
            return vec.X;
        }
        #endregion
        
    }
}
