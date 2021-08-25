#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace GamesArchitectureProject
{
    public class Animated2d : Basic2d
    {
        public Vector2 frames;
        public List<FrameAnimation> frameAnimationList = new List<FrameAnimation>();
        public Color color;
        public bool frameAnimations;
        public int currentAnimation = 0;

        public Animated2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Color COLOR) : base(PATH, POS, DIMS)
        {
            Frames = new Vector2(FRAMES.X, FRAMES.Y);

            color = COLOR;
        }

        #region Properties
        public Vector2 Frames
        {
            set
            {
                frames = value;
                if (myModel != null)
                {
                    frameSize = new Vector2(myModel.Bounds.Width / frames.X, myModel.Bounds.Height / frames.Y);
                }
            }
            get
            {
                return frames;
            }
        }

        #endregion
        public override void Update(Vector2 OFFSET)
        {
            if (frameAnimations && frameAnimationList != null && frameAnimationList.Count > currentAnimation) // If there are any animations to play, play them
            {
                frameAnimationList[currentAnimation].Update();
            }

            base.Update(OFFSET);
        }

        public virtual int GetAnimationFromName(string ANIMATIONNAME)
        {
            for (int i = 0; i < frameAnimationList.Count; i++)
            {
                if (frameAnimationList[i].name == ANIMATIONNAME)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void SetAnimationByName(string NAME)
        {
            int tempAnimation = GetAnimationFromName(NAME);

            if (tempAnimation != -1)
            {
                if (tempAnimation != currentAnimation)
                {
                    frameAnimationList[tempAnimation].Reset();
                }

                currentAnimation = tempAnimation;

            }
        }
        public override void Draw(Vector2 screenShift)
        {

            if (frameAnimations && frameAnimationList[currentAnimation].Frames > 0) // If there are animations play them, if not it is a basic2d object
            {
                frameAnimationList[currentAnimation].Draw(myModel, dims, frameSize, screenShift, pos, rot, color, new SpriteEffects());

            }
            else
            {
                base.Draw(screenShift);
            }
        }


    }
}
