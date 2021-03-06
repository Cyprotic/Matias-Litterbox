using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class QuantityDisplayBar
    {
        public int border;

        public Basic2d bar, barBKG;

        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BORDER, Color COLOR)
        {
            border = BORDER;
            color = COLOR;

            bar = new Basic2d("2d\\Misc\\solid", new Vector2(0, 0), new Vector2(DIMS.X - border * 2, DIMS.Y - border * 2));
            barBKG = new Basic2d("2d\\Misc\\shade", new Vector2(0, 0), new Vector2(DIMS.X , DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX) 
        {// Simple math to reduce the health in the bar given the current and maximum of it
            bar.dims = new Vector2(CURRENT / MAX * (barBKG.dims.X - border * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            barBKG.Draw(OFFSET, new Vector2(0, 0), Color.Black);
            bar.Draw(OFFSET + new Vector2(border, border), new Vector2(0, 0), color);
        }
    }
}
