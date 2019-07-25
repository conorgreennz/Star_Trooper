using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Trooper
{
    class User
    {
        public int X;
        public int Y;
        public int Angle;

        public int UserMoveRate = 7;

        public void MoveLeft()
        {
            X -= UserMoveRate;
        }
        public void MoveRight()
        {
            X += UserMoveRate;
        }
        public void MoveUp()
        {
            Y -= UserMoveRate;
        }
        public void MoveDown()
        {
            Y += UserMoveRate;
        }
        public void RotateLeft()
        {
            Angle -= UserMoveRate;
        }
        public void RotateRight()
        {
            Angle += UserMoveRate;
        }
    }
}
