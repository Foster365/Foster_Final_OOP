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

        Transform transform;

        public float Radius { get => radius; set => radius = value; }

        public Transform Transform { get => transform; set => transform = value; }

        public List<Collider> Colliders = new List<Collider>();

        public Collider(Transform _transform/*, Renderer _renderer*/, float radius)
        {

            transform = _transform;

            this.radius = radius;

        }

        public abstract bool CheckforCollisions(Entity target);


        
    }
}
