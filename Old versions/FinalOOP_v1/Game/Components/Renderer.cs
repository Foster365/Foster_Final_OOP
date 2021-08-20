using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        public Vector2 Size { get; set; }
        public string Texture { get; set; }

        Transform transform;

        public Renderer(Vector2 size, string texture, Transform transform)
        {
            Size = size;
            Texture = texture;
            this.transform = transform;
        }

        public float GetRealHeight()
        {
            return Size.Y * transform.Scale.Y;
        }

        public float GetRealWidth()
        {
            return Size.X * transform.Scale.X;
        }
        
    }
}
