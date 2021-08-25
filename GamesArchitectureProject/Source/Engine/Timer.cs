using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GamesArchitectureProject
{
    public class GameTimer
    {
        public bool goodToGo;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();


        public GameTimer(int m)
        {
            goodToGo = false;
            mSec = m;
        }
        public GameTimer(int m, bool STARTLOADED)
        {
            goodToGo = STARTLOADED;
            mSec = m;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }



        public void UpdateTimer() // Timer based on the game time
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public virtual void AddToTimer(int MSEC) // Adding more time to the timer
        {
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool Test() // Check if it ended
        {
            if (timer.TotalMilliseconds >= mSec || goodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset() // Reset it
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
            if (timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void ResetToZero()// Reset it to zero
        {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public void SetTimer(TimeSpan TIME)// Set the timer to a specific value
        {
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC)
        {
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}
