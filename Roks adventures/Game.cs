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
        int CameraOffset = 1;
        Action<int, int, string, bool> Printer;
        public void Start()
        {
            Printer = new Action<int, int, string, bool>(Write);
            player = new Rok(Printer);
            php = Enemy.phpEnemy(Printer);
            Loop();
        }

        void Loop()
        {
            while (true)
            {
                //Console.Clear();

                player.Move();
                if (player.x - CameraOffset > 40) {
                    CameraOffset++;
                    php.Clear();
                    
                }
                if (player.x - CameraOffset < 15 && CameraOffset > 0)
                {
                    php.Clear();
                    CameraOffset--;
                }
                
                Draw();
                Thread.Sleep(100);
            }
        }


        void Draw()
        {
            php.Draw();
            player.Draw();
            if (!Initialized) DrawGround();
        }

        public void Write(int x, int y, string content, bool allowGround)
        {
            Program.Write(x, y, content, CameraOffset, allowGround);
        }

        void DrawGround()
        {
            for (int i = 0; i < 80; i++)
            {
                Write(i, 20, "X", true);
            }
            Initialized = true;
        }
    }
}
