using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleCollider : Collider
    {

        //float radius;

        public CircleCollider(Transform _transform, float radius) : base(_transform, radius)
        {

            //this.radius = radius;

        }

        /*2 métodos:
        1 singular.
        1 lista de colliders que retorne bool, si colisionó o no.
        */
        public bool CheckforCollisions(Vector2 entity, Vector2 target, float entityRadius, float targetRadius)
        {

            //if(Colliders.Contains(target))
            //{

            float diffX = Math.Abs(entity.X - target.X);
            float diffY = Math.Abs(entity.Y - target.Y);

            Console.WriteLine($"Entity position is {entity.X}, {entity.Y}");
            Console.WriteLine($"Target position is {target.X}, {target.Y}");

            float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            if (dist <= (entityRadius + targetRadius))//No se cumple la condición.
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
