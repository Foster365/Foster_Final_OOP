using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxCollider : Collider
    {

        public BoxCollider(Transform _transform, Renderer _renderer, float _radius) : base(_transform, _renderer, _radius)
        {
            Transform = new Transform(_transform.Position, _transform.Scale, _transform.Rotation);
            Renderer = new Renderer(_renderer.Size, null, _transform);
        }

        // AABB
        public override bool CheckforCollisions(Entity target)
        {

            bool colliding = false;

            float diffX = Math.Abs(Transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(Transform.Position.Y - target.Transform.Position.Y);

            float halfWidthSum = Renderer.GetRealWidth() / 2 + target.Renderer.GetRealWidth() / 2;
            float halfHeightSum = Renderer.GetRealHeight() / 2 + target.Renderer.GetRealHeight() / 2;

            Console.WriteLine("Diff x: " + diffX);
            Console.WriteLine("Diff y: " + diffY);
            Console.WriteLine("Half Width Sum: " + halfWidthSum);
            Console.WriteLine("Half Height Sum: " + halfHeightSum);

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
