﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOverScreen
    {
        Image backgroundGameOverScreen;

        Button backButton;
        Button actualButton;

        public GameOverScreen()
        {
            Engine.Clear();
            ResetLevel();
        }

        public void Update()
        {

            //for (int i = 0; i < Program.Renderizable.Count; i++)
            //{
            //    Program.Renderizable[i].Update();
            //}

            //if (Engine.GetKey(Keys.ESCAPE))
            //{
            //    Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            //}
        }

        public void Render()
        {

            //for (int i = 0; i < Program.Renderizable.Count; i++)
            //{
            //    Program.Renderizable[i].Render();
            //}

        }
        void EnterButon()
        {
            if (actualButton == backButton)
            {
                Program.ActualScreenState = Program.ScreenFlow.mainMenuScreen;
            }
        }

        void ResetLevel()
        {
            AddTextures();
        }

        void AddTextures()
        {

            //Program.Renderizable.Add(new Image(new Vector2(200, 455), new Vector2(1, 1), new Vector2(1920, 1080), 0, "Textures/ScreenFlow/SpaceBk.png"));
            //Program.Renderizable.Add(new Image(new Vector2(200, 100), new Vector2(.6f, .6f), new Vector2(448, 56), 0, "Textures/ScreenFlow/Game_Over.png"));

        }
    }
}
