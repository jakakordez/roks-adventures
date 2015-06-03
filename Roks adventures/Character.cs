using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Character
    {
        public int x, y = 19, width, Health = 20;
        public string[] body;
        public Program.Direction CharacterDirection;
        public string Projectile;
        public List<Bullet> Bullets;
        public Action<int, int, string, bool> Print;

        public Character(string[] Body, Action<int, int, string, bool> printer)
        {
            body = Body;
            width = body[0].Length;
            Bullets = new List<Bullet>();
            Print = printer;
        }

        public void Draw()
        {
            Print(x, y, body[2], false);
            Print(x, y - 1, body[1], false);
            Print(x, y - 2, body[0], false);

            foreach (Bullet b in Bullets)
            {
                b.Move();
                Print(b.X, b.Y, Projectile, false);
                if (b.Duration == 0) Print(b.X, b.Y, " ", false);
            }
            Bullets.RemoveAll(b => b.Duration == 0);
        }

        public void Move(Program.Direction DirectionOfMove)
        {
            CharacterDirection = DirectionOfMove;
            x += (int)CharacterDirection;
        }

        public void Clear()
        {
            Print(x-1, y, "  ", false);
            Print(x-1, y - 1, "  ", false);
            Print(x-1, y - 2, "  ", false);
            Print(x-1 + width, y, "  ", false);
            Print(x-1 + width, y - 1, "  ", false);
            Print(x-1 + width, y - 2, "  ", false);
            foreach (Bullet b in Bullets)
            {
                Print(b.X - 1, b.Y, "   ", false);
            }
        }
    }
}
