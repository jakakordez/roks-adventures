using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Rok:Character
    {
        int px, jump = 0, step;

        public Rok(Action<int, int, string, bool> printer)
            : base(new string[] { " ☺ ", @"/█\", " ║ " }, printer)
        {
            x = 5;
            Projectile = "o";
        }

        public void Draw()
        {
            Clear();
            CalculateJump();

            if (jump > 0) { Print(x - 1, y - 4, "   ", false);
                if (jump < 5) Print(x - 1, y, "   ", false);
            }

             base.Draw();
            switch (step)
            {
                case 0:
                    
                    //Program.Write(x - 1, y - 1, " ║ ");
                    break;
                case 1:
                    if (CharacterDirection == Program.Direction.Left) Print(x, y, " |\\", false);
                    else Print(x, y, "/| ", false);
                    break;
                case 2:
                    
                    break;
                case 3:
                    Print(x - 1, y - 1, "/ \\", false);
                    break;
            }

           
        }

        public void Move()
        {
            if(NativeKeyboard.IsKeyDown(KeyCode.Right)){
                if (x > 0)
                {
                    Move(Program.Direction.Right);
                    if (step++ == 1) step = 0;
                }
                CharacterDirection = Program.Direction.Right;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Left))
            {
                if (x > 1)
                {
                    Move(Program.Direction.Left);
                    if (step-- == 0) step = 1;
                    CharacterDirection = Program.Direction.Left;
                }
            }
            if(jump == 0 && NativeKeyboard.IsKeyDown(KeyCode.Up)){
                    jump = 1;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Space))
            {

                Bullets.Add(new Bullet(x + ((CharacterDirection == Program.Direction.Right) ? +3 : -3), y - 1, CharacterDirection));
            }
        }

        private void CalculateJump()
        {
            switch (jump)
            {
                case 1:
                    y = 18;
                    Print(x, 19, "   ", false);
                    jump++;
                    break;
                case 2:
                case 3:
                    y = 17;
                    jump++;
                    Print(x, 18, "   ", false);
                    break;
                case 4:
                    y = 18;
                    jump++;
                    Print(x, 15, "   ", false);
                    break;
                case 5:
                    Print(x, 16, "   ", false);
                    y = 19;
                    jump++;
                    break;
                case 6:
                    jump = 0;
                    break;
            }
        }
    }
}
