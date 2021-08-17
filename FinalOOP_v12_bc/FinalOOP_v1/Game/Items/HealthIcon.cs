using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthIcon : Item
    {

        bool isDamage;

        public bool IsDamage { get => isDamage; set => isDamage = false; }

        public HealthIcon(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture) : base(position, size, scale, rotation, texture)
        {

            

        }

        public override void Update()
        {

        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation);
        }

    }
}
