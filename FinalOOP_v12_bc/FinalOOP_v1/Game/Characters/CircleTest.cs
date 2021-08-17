using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleTest
    {

        Transform transform;
        Renderer renderer;

        public CircleTest(Vector2 _position, Vector2 _scale, float _rotation, Vector2 _size, string _texture)
        {
            transform = new Transform(_position, _scale, _rotation);
            renderer = new Renderer(_size, _texture, transform);
        }

        public void Render()
        {
            Engine.Draw(renderer.Texture, transform.Position.X, transform.Position.X, transform.Scale.X, transform.Scale.Y, transform.Rotation, renderer.GetRealWidth() / 2, renderer.GetRealHeight() / 2);
        }

    }
}
