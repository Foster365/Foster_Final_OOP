using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        bool isLoop;
        float speed; float time; float lastAnimationFrame;
        int actualAnimationFrame = 0;
        List<Texture> animList = new List<Texture>();

        public int ActualAnimationFrame { get => actualAnimationFrame; set => actualAnimationFrame = value; }
        public List<Texture> AnimList { get => animList; set => animList = value; }

        public Animation(List<Texture> _animationList, float _speed, bool isloop)
        {

            speed = _speed;
            isLoop = isloop;
            if (_animationList != null)
            {
                AnimList = _animationList;
            }

        }

        public void Play()
        {

            time += Time.DeltaTime;

            if(time >= speed)
            {
                ActualAnimationFrame++;
                time = 0f;

                if (ActualAnimationFrame >= AnimList.Count)
                    ActualAnimationFrame = 0;
            }
        }
    }
}
