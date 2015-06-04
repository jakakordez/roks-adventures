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
        List<Drawable> Clouds;
        Action<int, int, string, bool> Printer;
        public void Start()
        {
            Printer = new Action<int, int, string, bool>(Write);


            Clouds = new List<Drawable>();
            Clouds.Add(new Drawable(new string[] { "(______---___)", " _-(    )--__ ", "    ____      " }, Printer));
            Clouds[0].y = 8;
            Clouds[0].x = 15;
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
                Clouds.ForEach((Drawable e) => { e.Draw();  e.Clear(); });
                player.Clear();
                Draw();
                Thread.Sleep(100);

                for (int i = 0; i < player.Bullets.Count; i++) // Check for collisions
			    {
			        for (int j = 0; j < Enemies.Count; j++)
			        {
			            if (player.Bullets[i].X >= Enemies[j].x && player.Bullets[i].X <= Enemies[j].x + Enemies[j].width)
                        {
                            Enemies[j].Health--;
                            player.Bullets[i].Duration = 0;
                            if(Enemies[j].Health <=0){
                                Enemies[j].Delete();
                                Enemies.RemoveAt(j);
                                break;
                            }
                        }
			        }
			    }
                player.Bullets.RemoveAll(b => b.Duration == 0);
                
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
