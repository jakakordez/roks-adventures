using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Drawable
    {
        public string[] Lines;
        public int x, y, width;
        public Action<int, int, string, bool> Print;

        public Drawable(string[] lines, Action<int, int, string, bool> printer)
        {
            Lines = lines;
            width = lines[0].Length;
            Print = printer;
        }

        public void Draw()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                Print(x, y - i, Lines[i], false);
            }
        }

        public void Delete()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                Print(x, y-i, new String(' ', width), false);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                Print(x - 2, y-i, "  ", false);
                Print(x + width, y - i, "  ", false);

            }
        }
    }
}
