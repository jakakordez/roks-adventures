using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Rok
    {
        public int x = 10, y = 20;
        int px, jump, step;

        Program.Direction CharacterDirection;

        List<Bullet> bullets;

        public Rok()
        {
            px = x;
            bullets = new List<Bullet>();
        }

        public void Draw()
        {
            CalculateJump();
            for (int i = px; i > x-1; i--)
            {
                Program.Write(i - 1, y - 3, "  ");
                Program.Write(i - 1, y - 2, " ");
                Program.Write(i - 1, y - 1, " ");
                Program.Write(i + 1, y - 3, "  ");
                Program.Write(i + 2, y - 2, " ");
                Program.Write(i + 2, y - 1, " ");
            }

            for (int i = px; i < x+1; i++)
            {
                Program.Write(i - 1, y - 3, "  ");
                Program.Write(i - 1, y - 2, " ");
                Program.Write(i - 1, y - 1, " ");
                Program.Write(i + 1, y - 3, "  ");
                Program.Write(i + 2, y - 2, " ");
                Program.Write(i + 2, y - 1, " ");
            }

            if (jump > 0) { Program.Write(x - 1, y - 4, "   ");
            if (jump < 5) Program.Write(x - 1, y, "   ");
            }

            Program.Write(x, y - 3, "☺");
            Program.Write(x-1, y - 2, "/█\\");
            switch (step)
            {
                case 0:
                    
                    Program.Write(x - 1, y - 1, " ║ ");
                    break;
                case 1:
                    if(CharacterDirection == Program.Direction.Left) Program.Write(x - 1, y - 1, " |\\");
                    else Program.Write(x - 1, y - 1, "/| ");
                    break;
                case 2:
                    
                    break;
                case 3:
                    Program.Write(x-1, y - 1, "/ \\");
                    break;
            }
            px = x;
            foreach (Bullet b in bullets)
            {
                b.Move();
                b.Draw();
            }
        }

        public void Move(ConsoleKey k)
        {
            
            switch (k)
            {
                case ConsoleKey.RightArrow:
                    if (x > 1)
                    {
                        x++;
                        if (step++ == 1) step = 0;
                    }
                    CharacterDirection = Program.Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    x--;
                    if (step-- == 0) step = 1;
                    CharacterDirection = Program.Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    jump = 1;
                    break;
                case ConsoleKey.Spacebar:
                    bullets.Add(new Bullet(x+((CharacterDirection == Program.Direction.Right)?+2:-2), y-2, CharacterDirection));
                    break;
            }
        }

        private void CalculateJump()
        {
            switch (jump)
            {
                case 1:
                    y = 19;
                    jump++;
                    break;
                case 2:
                case 3:
                    y = 18;
                    jump++;
                    break;
                case 4:
                    y = 19;
                    jump++;
                    break;
                case 5:
                    y = 20;
                    break;
                case 6:
                    jump = 0;
                    break;
            }
        }
    }
}
