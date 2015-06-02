using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;


namespace Roks_adventures
{
    class Game
    {
        bool Initialized;
        Rok player;
        Enemy php;
        public void Start()
        {
            player = new Rok();
            php = Enemy.phpEnemy();
            Loop();
        }

        void Loop()
        {
            while (true)
            {
                //Console.Clear();
                player.Move();
                Draw();
                Thread.Sleep(100);
            }
        }


        void Draw()
        {
            player.Draw();
            php.Draw();
            if (!Initialized) DrawGround();
        }

        void DrawGround()
        {
            for (int i = 0; i < 80; i++)
            {
                Program.Write(i, 20, "X", true);
            }
            Initialized = true;
        }
    }
}
