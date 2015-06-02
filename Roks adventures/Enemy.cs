using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Enemy:Character
    {
        public Enemy(string[] Body):base(Body)
        {
            x = 50;
        }

        public void Draw()
        {
            Move(Program.Direction.Left);
            //base.Draw();
        }

        public static Enemy phpEnemy()
        {
            Enemy r = new Enemy(new string[] { " ^^^^^ ", "<?php?>", "<*****>" });
            r.Projectile = "$";
            return r;
        }

        public static Enemy csEnemy()
        {
            Enemy r = new Enemy(new string[] { " .... ", "[;C#;]", "{::::}" });
            r.Projectile = "#";
            return r;
        }
    }
}
