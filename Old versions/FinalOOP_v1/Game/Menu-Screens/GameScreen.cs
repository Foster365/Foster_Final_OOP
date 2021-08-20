using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameScreen
    {

        //List<Image> images;
        //List<Button> buttons;

        public List<Image> Images { get; set; } =new List<Image>();
        public List<Button> Buttons { get; set; } = new List<Button>(); 

        public GameScreen()
        {
            AddImages();
            AddbButtons();
        }

        public abstract void Update();
        public abstract void Render();

        protected abstract void AddbButtons();
        protected abstract void AddImages();

    }
}
