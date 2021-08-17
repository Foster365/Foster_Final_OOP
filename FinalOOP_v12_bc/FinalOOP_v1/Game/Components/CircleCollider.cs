using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleCollider : Collider
    {

        float radius;

        public CircleCollider(Transform _transform, float radius):base(_transform, radius)
        {

            //this.radius = radius;

        }

        /*2 métodos:
        1 singular.
        1 lista de colliders que retorne bool, si colisionó o no.
        */
        public override bool CheckforCollisions(Entity target)
        {

            //if(Colliders.Contains(target))
            //{

            float diffX = Math.Abs(Transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(Transform.Position.Y - target.Transform.Position.Y);

            //Console.WriteLine($"Entity position is {Transform.Position.X}, {Transform.Position.Y}");
            //Console.WriteLine($"Target position is {target.Transform.Position.X}, {target.Transform.Position.Y}");

            float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            if (dist <= (radius + target.ColliderRadius))//No se cumple la condición.
            {

                IsCollision = true;
                //Colliders.Add(this);
                Console.WriteLine(this + "Collision w/" + target);
                //OnCollision?.Invoke(this);

            }

            //}
            return IsCollision;

        }

    }

}
