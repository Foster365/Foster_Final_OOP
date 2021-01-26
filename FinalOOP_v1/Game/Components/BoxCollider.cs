﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxCollider : Collider
    {

        Vector2 position;
        Vector2 scale;
        float rotation;

        Vector2 size;

        float radius;

        Transform transform;
        Renderer renderer;
        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public BoxCollider(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, float _radius) : base(_position, _scale, _size, _rotation, _radius)
        {
            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, null, transform);
        }

        // AABB
        public override bool CheckforCollisions(Entity target)
        {

            bool colliding = false;

            float diffX = Math.Abs(transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(transform.Position.Y - target.Transform.Position.Y);

            float halfWidthSum = renderer.Size.X / 2 + target.Renderer.Size.X / 2;
            float halfHeightSum = renderer.Size.Y / 2 + target.Renderer.Size.Y / 2;

            // Si se cumple hay colision
            if (diffX <= halfWidthSum && diffY <= halfHeightSum)
            {

                colliding = true;
                Colliders.Add(this);
                Console.WriteLine("Collision W/" + target);

            }

            Console.WriteLine("Colliding" + colliding);
            return colliding;

        }
    }
}
