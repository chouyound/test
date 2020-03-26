using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baymax;
using MyDm;

namespace MyContent
{
    public static class WaitingExtension
    {
        public static void BackClick(this Waiting waiting, int x, int y,int interval = 500)
        {
            waiting.BackWorker = ()=> MyDmSoft.CurrentThreadDm.Click(x, y, interval);
            waiting.BackWorker();
        }
        public static void BackClick(this Waiting waiting, Point p, int interval = 500)
        {
            waiting.BackClick(p.X, p.Y);
        }
        public static void BackClickFoundPoint(this Waiting waiting,int interval = 500)
        {
            waiting.BackWorker = () => MyDmSoft.CurrentThreadDm.ClickFoundPoint(interval);
            waiting.BackWorker();
        }
        public static void BackClickFoundPoint(this Waiting waiting, int offsetX,int offsetY,int interval = 500)
        {
            waiting.BackWorker = () => MyDmSoft.CurrentThreadDm.ClickFoundPoint(offsetX,offsetY,interval);
            waiting.BackWorker();
        }
        public static Waiting SetPicFinder(this Waiting waiting, string name,Rectangle rec,string del = "101010",double sim = 0.9,int dir = 0)
        {
            waiting.Finder = () => MyDmSoft.CurrentThreadDm.FindPic(name, rec, del, sim, dir);
            return waiting;
        }
        public static Waiting SetPicFinder(this Waiting waiting, string name, string del = "101010", double sim = 0.9, int dir = 0)
        {
            waiting.Finder = () => MyDmSoft.CurrentThreadDm.FindPic(name, del, sim, dir);
            return waiting;
        }
        public static Waiting SetFinder(this Waiting waiting, Func<bool> finder)
        {
            waiting.Finder = finder;
            return waiting;
        }
    }
}
