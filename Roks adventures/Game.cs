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
        int i;
        bool Initialized;
        Rok player;
        BackgroundWorker keyListener;
        public void Start()
        {
            player = new Rok();

            keyListener = new BackgroundWorker();
            keyListener.WorkerReportsProgress = true;
            keyListener.DoWork += keyListener_DoWork;
            keyListener.ProgressChanged += keyListener_ProgressChanged;
            keyListener.RunWorkerAsync();

            Loop();

        }

        void keyListener_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (((ConsoleKeyInfo)(e.UserState)).Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.Spacebar:
                    player.Move(((ConsoleKeyInfo)(e.UserState)).Key);
                    break;
            }
        }

        void keyListener_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                keyListener.ReportProgress(0, (Console.ReadKey(false)));
                Thread.Sleep(20);
            }
        }

        void Loop()
        {
            while (true)
            {
                //Console.Clear();
                
                Draw();
                Thread.Sleep(100);
            }
        }


        void Draw()
        {
            player.Draw();
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
