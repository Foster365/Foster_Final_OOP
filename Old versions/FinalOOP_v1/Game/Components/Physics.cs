using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Physics
    {
        Vector2 speed;
        Vector2 position;
        Vector2 aceleration;
        Vector2 force;
        float angularSpeed;
        float angularAceleration;
        float mass;
        float angle;

        public Physics(Vector2 position, float mass, Vector2 force, float angle)
        {
            this.position = position;
            this.mass = mass;
            this.force = force;

            speed = new Vector2(0, 0);
            aceleration = new Vector2(0, 0);

            this.angle = angle;
            angularSpeed = 0;
            angularAceleration = 0;

        }

        #region Physic_Calculus

        public void ApplyForce(Vector2 _force)
        {

            force.X += _force.X;
            force.Y += _force.Y;

        }

        public void PhysicCalculus()
        {

            aceleration.X = force.X / mass;
            aceleration.Y = force.Y / mass;

            position.X += speed.X * Time.DeltaTime + 0.5f * aceleration.X * Time.DeltaTime * Time.DeltaTime;
            position.Y += speed.Y * Time.DeltaTime + 0.5f * aceleration.Y * Time.DeltaTime * Time.DeltaTime;

            speed.X += aceleration.X * Time.DeltaTime;
            speed.Y += aceleration.Y * Time.DeltaTime;

            force.X = 0;
            force.Y = 0;

            aceleration.X = 0;
            aceleration.Y = 0;

            angularSpeed += angularAceleration * Time.DeltaTime;
            angle += angularSpeed * Time.DeltaTime + 0.5f * angularAceleration * Time.DeltaTime * Time.DeltaTime;

        }
        #endregion
    }
}
