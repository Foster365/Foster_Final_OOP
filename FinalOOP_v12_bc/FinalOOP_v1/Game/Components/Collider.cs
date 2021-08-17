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

        bool isCollision;

        Transform transform;

        //public event Action<Entity> OnCollision;

        public float Radius { get => radius; set => radius = value; }

        public Transform Transform { get => transform; set => transform = value; }

        public List<Entity> Colliders { get; set; }
        public bool IsCollision { get => isCollision; set => isCollision = value; }

        public Collider(Transform _transform, float radius)
        {

            transform = _transform;

            this.radius = radius;

            isCollision = false;
            Colliders = new List<Entity>();
            //OnCollision += OnCollisionHandler;

        }

        public abstract bool CheckforCollisions(Entity target);

        //public void OnCollisionHandler(Collider collider)
        //{
        //    Console.WriteLine($"The Object has collided with {collider}");
        //}
        
    }
}
