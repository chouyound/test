using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Baymax;
using MyDm;

namespace MyContent
{
    public partial class Program 
    {
        public string SourceFile { get; set; }
        public ISimulator Simulator { get; set; }
        public ThreadSignalHandler ThreadSignalHandler { get; set; }
        public string Name { get; set; }

        private DmSoft dm;
        private Waiting waiting;

        void init()
        {
            this.SourceFile = System.IO.Directory.GetCurrentDirectory() + "\\Source\\";
            dm = new MyDmSoft();
            dm.SetPath(this.SourceFile);

            this.waiting = new Waiting();
            this.waiting.Endless = false;

            this.dm.BindWindowEx(this.Simulator.Hwnd, "dx.graphic.opengl", "windows", "windows", "", 0);
            Thread.Sleep(200);

            this.dm.Capture(this.Simulator.Name + ".bmp");

            Controller.ViewPrintLine("已截图！");
            Controller.ViewPrintLine("句柄：{0}", this.Simulator.Hwnd);
        }

        public void ThreadExiting()
        {
            if (dm != null)
            {
                this.dm.UnBindWindow();
            }
            Controller.ViewPrintLine("已调用ThreadExiting()");
        }
    }
}
