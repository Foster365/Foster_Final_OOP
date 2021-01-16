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
        Vector2 position;

        float offset;

        public Vector2 Position { get => position; set => position = value; }

        public float Offset { get => offset; set => offset = 30; }

        //transform = new Transform(position, scale, rotation);
        //renderer= new Renderer(size, texture, transform);
        public void Update(Vector2 position)
        {
            position.X = position.X - offset;
            position.Y = position.Y;
        }

        public void Draw()
        {
            Engine.Draw("Textures/ScreenFlow/Select.png", position.X+60, position.Y+80);
        }
    }
}
