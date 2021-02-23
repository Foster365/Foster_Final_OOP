using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Collider
    {

        float radius;

        Vector2 position;

        Transform transform;

        public float Radius { get => radius; set => radius = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Vector2 Position { get => position; set => position = value; }

        public List<Collider> Colliders = new List<Collider>();

        public Collider(Transform _transform/*, Renderer _renderer*/, float radius)
        {
            transform = new Transform(_transform.Position, new Vector2(_transform.Scale.X, _transform.Scale.Y), _transform.Rotation);

            position = transform.Position;

            this.radius = radius;

        }

        public abstract bool CheckforCollisions(Entity target);


        
    }
}
