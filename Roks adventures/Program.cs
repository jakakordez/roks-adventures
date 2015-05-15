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
            int i = 0;
            Console.CursorVisible = false;
            Console.Title = "Rok's adventures";
            Game g = new Game();
            g.Start();
            
        }

        public static void Write(int x, int y, string content)
        {
            if (x < 80 && x >= 0 && y >= 0 && y < 20)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(content);
            }
        }

        public static void Write(int x, int y, string content, bool allowGround)
        {
            if (x < 80 && x >= 0 && y >= 0 && y < 25 && (allowGround || y < 20))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(content);
            }
        }

        public enum Direction
        {
            Right, Left
        }
    }
}
