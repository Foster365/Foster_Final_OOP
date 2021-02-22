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

        float x; float y;

        public float X { get => x ; set => x = value; }
        public float Y { get => y ; set => y = value; }

        #endregion

        #region Construct
        public Vector2(float x, float y)
        {
            //new Vector2(x, y);

            this.x = x;
            this.y = y;
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

        public static float GetYComponent(float x, float y)
        {
            Vector2 v = new Vector2(x, y);
            return v.y;
        }
        #endregion

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(a.X+b.X, a.Y+b.Y);;

            return c;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(a.X - b.X, a.Y - b.Y); ;

            return c;
        }

        public static Vector2 operator *(Vector2 a, float b)
        {

            Vector2 c = new Vector2(a.X * b, a.Y * b);

            return c;

        }

        public static Vector2 operator *(float a, Vector2 b)
        {

            Vector2 c = new Vector2(b.X * a, b.Y * a);

            return c;

        }

    }
}
