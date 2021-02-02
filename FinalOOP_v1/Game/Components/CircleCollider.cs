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

        public CircleCollider(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, float radius):base(_position, _scale, _size, _rotation, radius)
        {
            Transform = new Transform(_position, _scale, _rotation);
            Renderer = new Renderer(_size, null, Transform);
            this.radius = radius;
        }

        /*2 métodos:
        1 singular.
        1 lista de colliders que retorne bool, si colisionó o no.
        */
        public override bool CheckforCollisions(Entity target)
        {

            bool colliding = false;

            float diffX = Math.Abs(Transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(Transform.Position.Y - target.Transform.Position.Y);

            float dist = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            Console.WriteLine("Dist" + dist);
            Console.WriteLine("Radius calc" + (radius + target.ColliderRadius));

            if (dist <= (radius + target.ColliderRadius))//No se cumple la condición.
            {

                colliding = true;
                Colliders.Add(this);
                Console.WriteLine("Collision w/" + target);

            }

            return colliding;

        }

    }

}
