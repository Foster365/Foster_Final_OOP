using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : ICharacter
    {
        float radius;
        CircleCollider circleCollider;
        BoxCollider boxCollider;

        public float Radius { get => radius; set => radius = value; }

        public Renderer Renderer { get ; set; }
        public Transform Transform { get; set ; }

        public Entity(float _radius)
        {
            radius = _radius;

            circleCollider = new CircleCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, _radius);
            boxCollider = new BoxCollider(Transform.Position, Transform.Scale, Transform.Rotation, Renderer.Size, _radius);
        }

        public void Render()
        {
        }

        public void Update()
        {
        }
    }
}
