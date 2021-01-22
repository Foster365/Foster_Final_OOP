using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Collider
    {

        //Vector2 position;
        //Vector2 scale;
        //float rotation;
        float radius;

        Transform transform;
        Renderer renderer;

        public float Radius { get => radius; set => radius = value; }

        public Transform Transform { get => transform; set => transform = value; }
        //public Renderer Renderer { get => renderer; set => renderer = value; }

        public List<Collider> Colliders = new List<Collider>();

        //public List<Collider> Colliders = new List<Collider>();

        public Collider(Vector2 position, Vector2 scale, Vector2 size, float rotation, float radius)
        {
            transform = new Transform(position, scale, rotation);
            //renderer = new Renderer(size, null, transform);
        }

        public abstract bool CheckforCollisions(Entity target);


        
    }
}
