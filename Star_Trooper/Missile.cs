using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Trooper
{
    class Missile
    {
        public int X;
        public int Y;
        public int Angle;
        public Bitmap Image;

        const int MOVE_RATE = 14;

        public void Move()
        {
            double angleradians = (Math.PI * (Angle) / 180.0);
            X = (int)((double)X + (Math.Cos(angleradians) * MOVE_RATE));
            Y = (int)((double)Y + (Math.Sin(angleradians) * MOVE_RATE));
        }
    }
}
