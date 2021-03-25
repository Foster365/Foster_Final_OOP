﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleCollider : Collider
    {

        float radius;

        bool colliding = false;

        public CircleCollider(Transform _transform/*, Renderer _renderer*/, float radius):base(_transform/*, _renderer*/, radius)
        {

            this.radius = radius;

        }

        /*2 métodos:
        1 singular.
        1 lista de colliders que retorne bool, si colisionó o no.
        */
        public override bool CheckforCollisions(Entity target)
        {

            float diffX = Math.Abs(Transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(Transform.Position.Y - target.Transform.Position.Y);

            float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            //Console.WriteLine("Dist" + dist);
            //Console.WriteLine("Radius calc" + (radius + target.ColliderRadius));

            if (dist <= (radius + target.ColliderRadius))//No se cumple la condición.
            {

                colliding = true;
                Colliders.Add(this);
                Console.WriteLine(this + "Collision w/" + target);

            }

            return colliding;

        }

    }

}
