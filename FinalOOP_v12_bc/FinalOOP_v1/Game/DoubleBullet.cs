using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class DoubleBullet : Bullet<DoubleBullet>
    {
        public override event Action<DoubleBullet> OnDeactivate;

        public DoubleBullet():base()
        {

        }

        public override void Move()
        {
            Transform.Position += new Vector2(-Speed.X * Time.DeltaTime, -Speed.Y * Time.DeltaTime);
            Transform.Position += new Vector2(Speed.X * Time.DeltaTime, Speed.Y * Time.DeltaTime);
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Move();

        }

        void CheckForCollisions()
        {

        }
    }
}
