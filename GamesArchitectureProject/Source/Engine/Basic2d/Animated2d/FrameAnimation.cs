#region Includes
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace GamesArchitectureProject
{
    public class FrameAnimation
    {
        public bool hasFired;
        public int frames, currentFrame, maxPasses, currentPass, fireFrame;
        public string name;
        public Vector2 sheet, startFrame, sheetFrame, spriteDims;
        public GameTimer frameTimer;


        public FrameAnimation(Vector2 SpriteDims, Vector2 sheetDims, Vector2 start, int totalframes, int timePerFrame, int MAXPASSES, string NAME = "")
        {
            spriteDims = SpriteDims;
            sheet = sheetDims;
            startFrame = start;
            sheetFrame = new Vector2(start.X, start.Y);
            frames = totalframes;
            currentFrame = 0;
            frameTimer = new GameTimer(timePerFrame);
            maxPasses = MAXPASSES;
            currentPass = 0;
            name = NAME;
            hasFired = false;

            fireFrame = 0;
        }

        #region Properties
        public int Frames
        {
            get { return frames; }
        }
        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public int CurrentPass
        {
            get
            {
                return currentPass;
            }
        }
        public int MaxPasses
        {
            get
            {
                return maxPasses;
            }
        }

        #endregion

        public void Update()
        {

            if (frames > 1) // If there is a frama to be played, play it
            {
                frameTimer.UpdateTimer(); // Checj if the frame timer ended
                if (frameTimer.Test() && (maxPasses == 0 || maxPasses > currentPass)) // If there are any more frames to play, continue it
                {
                    currentFrame++;
                    if (currentFrame >= frames)
                    {
                        currentPass++;
                    }
                    if (maxPasses == 0 || maxPasses > currentPass)
                    {
                        sheetFrame.X += 1;

                        if (sheetFrame.X >= sheet.X) // We can also start going up the Y position to find new frames
                        {
                            sheetFrame.X = 0;
                            sheetFrame.Y += 1;
                        }
                        if (currentFrame >= frames) // If it is over, reset to 0
                        {
                            currentFrame = 0;
                            hasFired = false;
                            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
                        }
                    }
                    frameTimer.Reset();
                }
            }
        }

        public void Reset() // Reset the playing sheet
        {
            currentFrame = 0;
            currentPass = 0;
            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
            hasFired = false;
        }

        public bool IsAtEnd()
        {
            if (currentFrame + 1 >= frames)
            {
                return true;
            }
            return false;
        }


        public void Draw(Texture2D myModel, Vector2 dims, Vector2 imageDims, Vector2 screenShift, Vector2 pos, float ROT, Color color, SpriteEffects spriteEffect)
        { // Draw the frame
            Globals.spriteBatch.Draw(myModel, new Rectangle((int)((pos.X + screenShift.X)), (int)((pos.Y + screenShift.Y)), (int)Math.Ceiling(dims.X), (int)Math.Ceiling(dims.Y)), new Rectangle((int)(sheetFrame.X * imageDims.X), (int)(sheetFrame.Y * imageDims.Y), (int)imageDims.X, (int)imageDims.Y), color, ROT, imageDims / 2, spriteEffect, 0);
        }

    }
}
