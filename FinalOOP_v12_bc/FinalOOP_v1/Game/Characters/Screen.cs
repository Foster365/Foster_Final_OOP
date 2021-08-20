using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Screen
    {
        List<Item> lifeStack;

        public List<Item> LifeStack { get => lifeStack; set => lifeStack = value; }
        public Screen()
        {
           lifeStack = new List<Item>();
            ResetLevel();
            //Console.Write("Level" + this);
        }

        //public Screen(float _maxLevelTimer)
        //{
        //    maxLevelTimer = _maxLevelTimer;
        //    Engine.Clear();
        //    ResetLevel();
        //    Console.Write("Level" + this);

        //}

        public abstract void ResetLevel();
        public abstract void Update();
        public abstract void Render();
        public virtual void CleanAllElements()
        {

            //for (int i = 0; i < Program.Characters.Count; i++)
            //{

            //    if (!Program.Characters[i].LifeController.IsPlayer)
            //        Program.Characters.Remove(Program.Characters[i]);

            //}

            //Program.Environment.Clear();
            //Program.Characters.Clear();/*RemoveRange(0, Program.Characters.Count);*/
        }

        public void CreateLifeStack(int amount, string texture)
        {
            Vector2 position = new Vector2(10, 10);
            for (int i = 0; i < amount; i++)
            {
                lifeStack.Add(new HealthIcon(position, new Vector2(.03f, .03f), new Vector2(788, 663), 0, texture));

                position = new Vector2(position.X + 50, position.Y);

            }
        }
        public void CheckPlayerLife()
        {
            float currPlayerLife;
            for (int i = LifeStack.Count; i > 0; i--)
            {

                for (int j = 0; j < Program.Characters.Count; j++)
                {

                    if (Program.Characters[j].LifeController.IsPlayer)
                    {


                        currPlayerLife = Program.Characters[j].LifeController.MaxLife - Program.Characters[j].LifeController.MaxLife * .2f;
                        //Console.WriteLine($"currPlayerLife {currPlayerLife}");
                        if (Program.Characters[j].LifeController.Damaged && currPlayerLife == currPlayerLife - .2f/*Program.Characters[i].LifeController.CurrentLife == Program.Characters[i].LifeController.MaxLife - Program.Characters[i].LifeController.MaxLife * .2f*/)
                        {
                            //Console.WriteLine("Life" + (currPlayerLife == currPlayerLife - .2f));
                            //Program.Environment.Remove(this);
                            LifeStack.Remove(LifeStack[i]);
                            //Console.WriteLine("Life Stack hearts" + Program.Environment.Count);
                            //isDamage = false;
                        }

                    }
                }

            }
        }

    }
}
