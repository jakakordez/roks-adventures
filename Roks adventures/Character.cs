using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Character
    {
        public int x, y = 19, width;
        public string[] body;
        public Program.Direction CharacterDirection;
        public string Projectile;
        public List<Bullet> Bullets;

        public Character(string[] Body)
        {
            body = Body;
            width = body[0].Length;
            Bullets = new List<Bullet>();
        }

        public void Draw()
        {
            Program.Write(x, y, body[2]);
            Program.Write(x, y - 1, body[1]);
            Program.Write(x, y - 2, body[0]);

            foreach (Bullet b in Bullets)
            {
                b.Move();
                b.Draw(Projectile);
            }
        }

        public void Move(Program.Direction DirectionOfMove)
        {
            CharacterDirection = DirectionOfMove;
            if (CharacterDirection == Program.Direction.Right)
            {
                Program.Write(x, y, " ");
                Program.Write(x, y - 1, " ");
                Program.Write(x, y - 2, " ");
                x++;
                Draw();
            }
            else
            {
                x--;
                Program.Write(x + width, y, " ");
                Program.Write(x + width, y - 1, " ");
                Program.Write(x + width, y - 2, " ");
                Draw();
            }
        }
    }
}
