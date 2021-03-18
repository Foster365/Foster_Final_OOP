using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class AnimationComponent
    {

        enum Animations { animationA};
        Animations actualAnimationState;

        Animation animation;

        string texturePath;
        string textExtension;
        int textures;

        public AnimationComponent(string _texturePath, string _textExtension, int _textures)
        {

            texturePath = _texturePath;
            textures = _textures;
            textExtension = _textExtension;

        }


        public void AnimationParameters()
        {

            List<Texture> countdownFrames = new List<Texture>();

            for (int i = textures; i >= 0; i--)
            {

                countdownFrames.Add(Engine.GetTexture(texturePath + i.ToString() + textExtension));

            }

            animation = new Animation(countdownFrames, 1f, false);

        }

        public void UpdateAnimation()
        {

            if (actualAnimationState == Animations.animationA)
            {
                actualAnimationState = Animations.animationA;
                animation.Play();
            }

        }

    }
}
