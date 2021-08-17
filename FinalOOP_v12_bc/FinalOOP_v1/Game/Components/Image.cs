using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Image: ICharacter
    {
        Vector2 position;
        float rotation;
        Vector2 scale;

        string texture;
        Vector2 size;

        Transform transform;
        Renderer renderer;

        public Vector2 Position { get => position; set => position = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public Vector2 Scale { get => scale; set => scale = value; }

        public string Texture { get => texture; set => texture = value; }
        public Vector2 Size { get => size; set => size = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public Image(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture)
        {
            transform = new Transform(position, scale, rotation);
            renderer = new Renderer(size, texture, transform);
        }

        public void Render()
        {
            Engine.Draw(renderer.Texture, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Rotation, renderer.GetRealHeight() / 2, renderer.GetRealHeight() / 2);
        }

        public void Update()
        {

        }
    }
}
