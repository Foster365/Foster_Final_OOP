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

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Size { get => size; set => size = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public string Texture { get => texture; set => texture = value; }

        Transform IUpdatable.Transform { get => transform; set => transform = value; }
        Renderer IRenderizable.Renderer { get => renderer; set => renderer = value; }

        public Item(Vector2 position, Vector2 size, Vector2 scale, float rotation, string texture)
        {
            Position = position;
            Size = size;
            Scale = scale;
            Rotation = rotation;
            Texture = texture;

            transform = new Transform(Position, Scale, Rotation);
            renderer = new Renderer(Size, Texture, transform);


        }
        public abstract void Update();

        public abstract  void Render();
    }
}
