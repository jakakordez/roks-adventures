using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Exit:Drawable
    {
        public Exit(Action<int, int, string, bool> printer) :base(new string[] { "║   ║", "║   ║", "║   ║", "╔═══╗" }, printer)
        {

        }
    }
}
