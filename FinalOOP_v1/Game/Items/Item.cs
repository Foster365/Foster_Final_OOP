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
        CircleCollider circleCollider;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Size { get => size; set => size = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public string Texture { get => texture; set => texture = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Item(Vector2 position, Vector2 size, Vector2 scale, float rotation, string texture)
        {

            transform = new Transform(new Vector2(position.X, position.Y), Scale, Rotation);
            renderer = new Renderer(size, texture, transform);

            Size = size;
            Scale = scale;
            Rotation = rotation;
            Texture = texture;

        }

        public abstract void Update();
        public abstract  void Render();
    }
}
