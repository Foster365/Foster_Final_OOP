using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Item : IItem
    {
        Vector2 position;
        Vector2 size;
        Vector2 scale;
        float rotation;
        string texture;

        Renderer renderer;
        Transform transform;

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Item(Vector2 _position, Vector2 _size, Vector2 _scale, float _rotation, string _texture)
        {

            transform = new Transform(new Vector2(_position.X, _position.Y), _scale, _rotation);
            renderer = new Renderer(_size, _texture, transform);

        }

        public abstract void Update();
        public abstract  void Render();
    }
}
