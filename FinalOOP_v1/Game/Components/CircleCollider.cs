using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleCollider : Collider
    {

        Vector2 position;
        Vector2 scale;
        float rotation;


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
        public override void CheckforCollisions(Collider target)
        {

            float diffX = Math.Abs(transform.Position.X - target.Transform.Position.X);
            float diffY = Math.Abs(transform.Position.Y - target.Transform.Position.Y);

            float distance = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            //if (distance <= radius + target.Radius)
                //return target.Transform.Position;

            //float diffX = transform.Position.X - target.Transform.Position.X;
            //float diffY = transform.Position.Y - target.Transform.Position.Y;

            //float distance = (float)Math.Sqrt(diffX * diffX + diffY * diffY);

            //if (distance <= radius + target.Radius) return true;
            //else return false;

            //return coll;

            //Collider[] colliders = Physics.OverlapSphere(transform.position, lineOfSight.ViewDistance, safePointLayer);
            //if (colliders.Length > 1)
            //{
            //    sPoint = colliders[0].transform.position;
            //}
            //return sPoint;
        }

        //public List<Collider> CollidersList()
        //{
        //    Colliders = 
        //} 

    }

}
