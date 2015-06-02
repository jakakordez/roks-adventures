using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Rok:Character
    {
        int px, jump, step;

        public Rok():base(new string[] { " ☺ ", "/█\\", " ║ " })
        {
            px = x;
            x = 5;
            Projectile = "o";
        }

        public void Draw()
        {
            CalculateJump();

            if (jump > 0) { Program.Write(x - 1, y - 4, "   ");
                if (jump < 5) Program.Write(x - 1, y, "   ");
            }

             base.Draw();
            switch (step)
            {
                case 0:
                    
                    //Program.Write(x - 1, y - 1, " ║ ");
                    break;
                case 1:
                    if(CharacterDirection == Program.Direction.Left) Program.Write(x, y, " |\\");
                    else Program.Write(x, y, "/| ");
                    break;
                case 2:
                    
                    break;
                case 3:
                    Program.Write(x-1, y - 1, "/ \\");
                    break;
            }
            px = x;

           
        }

        public void Move()
        {
            if(NativeKeyboard.IsKeyDown(KeyCode.Right)){
                if (x > 1)
                {
                    Move(Program.Direction.Right);
                    if (step++ == 1) step = 0;
                }
                CharacterDirection = Program.Direction.Right;
            }
            if (NativeKeyboard.IsKeyDown(KeyCode.Left))
            {
                Move(Program.Direction.Left);
                if (step-- == 0) step = 1;
                CharacterDirection = Program.Direction.Left;
            }
            if(NativeKeyboard.IsKeyDown(KeyCode.Up)){
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
                    Program.Write(x, 19, "   ");
                    jump++;
                    break;
                case 2:
                case 3:
                    y = 17;
                    jump++;
                    Program.Write(x, 18, "   ");
                    break;
                case 4:
                    y = 18;
                    jump++;
                    Program.Write(x, 15, "   ");
                    break;
                case 5:
                    Program.Write(x, 16, "   ");
                    y = 19;
                    break;
                case 6:
                    jump = 0;
                    break;
            }
        }
    }
}
