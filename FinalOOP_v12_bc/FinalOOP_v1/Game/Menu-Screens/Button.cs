using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    public class Button
    {

        Button upButton;
        Button downButton;
        float timer = 0f;
        float timetToPress = 0.25f;
        Transform transform;
        Renderer renderer;

        public Button UpButton { get => upButton; set => upButton = value; }
        public Button DownButton { get => downButton; set => downButton = value; }
        public float Timer { get => timer; set => timer = 0; }
        public float Timetopress { get => timetToPress; set => timetToPress = 0.25f; }

        public Transform Transform { get => transform; set => transform = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }

        public Button(string texture, Vector2 position, Vector2 scale, Vector2 size, float rotation = 0)
        {
            transform = new Transform(position, scale, rotation);
            renderer = new Renderer(size, texture, transform);
        }

        public void SetButtons(Button up, Button down)
        {
            upButton = up;
            downButton = down;
        }

        public Button Update()
        {
            timer += Time.DeltaTime;

            if (Engine.GetKey(Keys.UP) && timer >= timetToPress)
            {
                timer = 0f;
                return GetUp();
            }
            else if (Engine.GetKey(Keys.DOWN) && timer >= Timetopress)
            {
                timer = 0f;
                return GetDown();
            }
            else return this;
        }

        public void Render()
        {
            Engine.Draw(renderer.Texture, transform.Position.X, transform.Position.Y);
        }

        public Button GetUp()
        {
            if (upButton != null)
            {
                return upButton;
            }
            else return this;
        }
        public Button GetDown()
        {
            if (downButton != null)
            {
                return downButton;
            }
            else return this;
        }
    }
}