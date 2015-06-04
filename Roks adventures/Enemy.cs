using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Enemy:Character
    {
        public Enemy(string[] Body, Action<int, int, string, bool> printer):base(Body, printer)
        {
            x = 50;
        }

        public void Draw()
        {
            //Move(Program.Direction.Left);
            base.Draw();
        }

        public static Enemy phpEnemy(Action<int, int, string, bool> printer)
        {
            Enemy r = new Enemy(new string[] { "<*****>", "<?php?>", " ^^^^^ " }, printer);
            r.Projectile = "$";
            return r;
        }

        public static Enemy csEnemy(Action<int, int, string, bool> printer)
        {
            Enemy r = new Enemy(new string[] { "{::::}", "[;C#;]", " .... " }, printer);
            r.Projectile = "#";
            return r;
        }
    }
}
