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
        int CameraOffset = 1, CloudsStep;
        Dictionary<string, List<Drawable>> StaticObjects;
        Action<int, int, string, bool> Printer;
        
        public void Start()
        {
            Printer = new Action<int, int, string, bool>(Write);

            StaticObjects = new Dictionary<string, List<Drawable>>();
            
            StaticObjects.Add("Traps", new List<Drawable>());
            StaticObjects["Traps"].Add(new Drawable(new string[] { "▲" }, Printer));
            StaticObjects["Traps"][0].x = 20;
            StaticObjects["Traps"][0].y = 19;

            StaticObjects.Add("Clouds", new List<Drawable>());
            generateClouds();

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
                // ----- Move the player
                player.Move();

                // ----- Move the camera
                if (player.x - CameraOffset > 40)  CameraOffset++;
                if (player.x - CameraOffset < 15 && CameraOffset > 0) CameraOffset--;

                // ----- Clear the scene
                Enemies.ForEach((Enemy e) => { e.Clear(); });
                player.Clear();
                foreach (List<Drawable> dl in StaticObjects.Values)
                {
                    dl.ForEach((Drawable e) => { e.Clear(); });
                }
                
                // ----- Draw elements
                foreach (List<Drawable> dl in StaticObjects.Values)
                {
                    dl.ForEach((Drawable e) => { e.Draw(); });
                }
                Enemies.ForEach((Enemy e) => { e.Draw(); });
                player.Draw();

                // ----- Draw GUI
                Program.Write(2, 2, "(" + new String('♥', player.Health) + new String(' ', 20 - player.Health) + ")", 0, false);
                Program.Write(60, 2, "Score: " + player.DP + " DP", 0, false);

                if (!Initialized) DrawGround();

                // ----- Check for collisions
                for (int i = 0; i < player.Bullets.Count; i++) 
			    {
			        for (int j = 0; j < Enemies.Count; j++)
			        {
			            if (player.Bullets[i].X >= Enemies[j].x && player.Bullets[i].X <= Enemies[j].x + Enemies[j].width)
                        {
                            Enemies[j].Health--;
                            player.Bullets.RemoveAt(i);
                            i--;
                            if(Enemies[j].Health <=0){
                                Enemies[j].Delete();
                                Enemies.RemoveAt(j);
                                player.DP += 10;
                                break;
                            }
                        }
			        }
			    }

                Thread.Sleep(100);
            }
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

        void generateClouds()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                Drawable d = new Drawable(new string[] { "(______---___)", " _-(    )--__ ", "    ____      " }, Printer);
                d.x = (i * 50) + r.Next(1, 40);
                d.y = r.Next(6, 12);
                StaticObjects["Clouds"].Add(d);
            }
        }
    }
}
