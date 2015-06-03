using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Bullet
    {
        public int X, Y;
        Program.Direction BulletDirection;
        public Bullet(int x, int y, Program.Direction bulletDirection)
        {
            X = x;
            Y = y;
            BulletDirection = bulletDirection;
        }

        public void Move(){
            if(BulletDirection == Program.Direction.Right){
                X++;
            }
            else X--;
        }
    }
}
