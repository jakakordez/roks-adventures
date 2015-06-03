using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Rok's adventures";
            Game g = new Game();
            g.Start();
            
        }

        public static void Write(int x, int y, string content, int CameraOffset, bool allowGround)
        {
            x -= CameraOffset;
            if(y >= 0 && y < 25 && (allowGround || y < 20)){
                if (x < 80&& x >= 0)
                {
                    Console.SetCursorPosition(x, y);
                    if(x < 80-content.Length)Console.Write(content);
                    else Console.Write(content.Substring(0, 80-x));
                }
                else if(x < 0 && x> 0-content.Length){
                    Console.SetCursorPosition(0, y);
                    Console.Write(content.Substring(x*-1));
                }
            }
        }

        public enum Direction
        {
            Right = 1, Left = -1
        }
    }
}
