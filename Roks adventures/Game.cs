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
        List<Enemy> Enemies;
        int CameraOffset = 1;
        Action<int, int, string, bool> Printer;
        public void Start()
        {
            Printer = new Action<int, int, string, bool>(Write);
            player = new Rok(Printer);
            Enemies = new List<Enemy>();
            Enemies.Add(Enemy.phpEnemy(Printer));
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
                }
                if (player.x - CameraOffset < 15 && CameraOffset > 0)
                {
                    CameraOffset--;
                }

                Enemies.ForEach((Enemy e) => { e.Clear(); });
                player.Clear();
                Draw();
                Thread.Sleep(100);
            }
        }

        void Draw()
        {
            Enemies.ForEach((Enemy e) => { e.Draw(); });
            player.Draw();
            Program.Write(2, 2, "("+new String('♥', player.Health)+new String(' ', 20-player.Health)+")", 0, false);
            Program.Write(60, 2, "Score: " + player.DP+" DP", 0, false);
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
