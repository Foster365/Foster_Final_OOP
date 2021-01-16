using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthIcon : Item
    {
        Vector2 position;
        Vector2 scale;
        float rotation;

        Vector2 size;
        string texture;

        Transform transform;
        Renderer renderer;

        Player _player;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Size{get=>size; set => size = value; }
        public string Texture { get => texture; set => texture = value; }

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public HealthIcon(Vector2 position, Vector2 scale, float rotation, Vector2 size, string texture) : base(position, size, scale, rotation, texture)
        {

            transform = new Transform(position, scale, rotation);
            renderer = new Renderer(size, texture, transform);

        }

        public override void Update()
        {

        }



        public override void Render()
        {
            Engine.Draw(texture, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Rotation);
        }
    }
}
