using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roks_adventures
{
    class Character:Drawable
    {
        public int Health = 20;
        public Program.Direction CharacterDirection;
        public string Projectile;
        public List<Bullet> Bullets;
        

        public Character(string[] Body, Action<int, int, string, bool> printer):base(Body, printer)
        {
            Bullets = new List<Bullet>();
            y = 19;
        }

        public void Draw()
        {
            base.Draw();

            foreach (Bullet b in Bullets)
            {
                b.Move();
                Print(b.X, b.Y, Projectile, false);
                if (b.Duration == 0) Print(b.X, b.Y, " ", false);
            }
        }

        public void Move(Program.Direction DirectionOfMove)
        {
            CharacterDirection = DirectionOfMove;
            x += (int)CharacterDirection;
        }

        public void Clear()
        {
            base.Clear();
            foreach (Bullet b in Bullets)
            {
                Print(b.X - 1, b.Y, "   ", false);
            }
        }
    }
}
