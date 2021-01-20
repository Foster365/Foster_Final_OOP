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

        Transform transform;
        public Transform Transform { get => transform; set => transform = value; }

        List<CircleCollider> Colliders = new List<CircleCollider>();
        public CircleCollider(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, float radius):base(_position, _scale, _size, _rotation, radius)
        {
            transform = new Transform(_position, _scale, _rotation);
            this.radius = radius;
        }

        /*2 métodos:
        1 singular.
        1 lista de colliders que retorne bool, si colisionó o no.
        */
        public override bool CheckforCollisions(Entity target)
        {

            bool colliding = false;

            float diffX = Math.Abs(transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(transform.Position.Y - target.Transform.Position.Y);

            float distance = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            if (distance <= radius + target.Radius)
            {

                colliding = true;
                Colliders.Add(this);

            }
            return colliding = false;

        }

    }

}
