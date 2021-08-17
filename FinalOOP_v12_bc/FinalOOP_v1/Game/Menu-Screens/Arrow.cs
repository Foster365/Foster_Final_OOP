using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    public class Arrow
    {

        float offset;

        public float Offset { get => offset; set => offset = 30; }

        Transform transform;
        Renderer renderer;

        public Arrow(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, string _texture, float _offset)
        {
            offset = _offset;
            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, _texture, transform);

        }

        public void Update()
        {
            transform.Position = new Vector2(transform.Position.X /*- offset*/, transform.Position.Y);

        }

        public void Render()
        {
            Engine.Draw(renderer.Texture, transform.Position.X + offset, transform.Position.Y);
        }
    }
}
