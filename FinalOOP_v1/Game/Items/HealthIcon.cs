using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthIcon : Item
    {

        bool isDamage;

        public bool IsDamage { get => isDamage; set => isDamage = false; }

        public HealthIcon(Vector2 position, Vector2 scale, Vector2 size, float rotation, string texture) : base(position, size, scale, rotation, texture)
        {

            

        }

        public override void Update()
        {
            //CheckPlayerLife();
        }

        public override void Render()
        {
            Engine.Draw(Renderer.Texture, Transform.Position.X, Transform.Position.Y, Transform.Scale.X, Transform.Scale.Y, Transform.Rotation);
        }

        void CheckPlayerLife()
        {
            for (int i = 0; i < Program.Characters.Count; i++)
            {
                if (Program.Characters[i].LifeController.IsPlayer)
                {

                    if (isDamage/*Program.Characters[i].LifeController.CurrentLife == Program.Characters[i].LifeController.MaxLife - Program.Characters[i].LifeController.MaxLife * .2f*/)
                    {
                        Console.WriteLine("Life" + (Program.Characters[i].LifeController.MaxLife - Program.Characters[i].LifeController.MaxLife * .2f));
                        Program.Environment.Remove(this);
                        Console.WriteLine("Life Stack hearts" + Program.Environment.Count);
                        isDamage = false;
                    }

                }
            }
        }

    }
}
