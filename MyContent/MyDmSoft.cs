using MyDm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Baymax;

namespace MyContent
{
    public class MyDmSoft : DmSoft
    {
        public override void Click(int x, int y, int interval = 500)
        {
            Controller.CurrentThreadController.Content.ThreadSignalHandler.WaitSignal();
            base.Click(x, y, interval);
            Controller.ViewPrintLine("点击 {0},{1}", x, y);
        }

        public override bool FindPic(string name, Rectangle rec, string del = "101010", double sim = 0.9, int dir = 0)
        {
            Controller.CurrentThreadController.Content.ThreadSignalHandler.WaitSignal();
            bool flag = base.FindPic(name, rec, del, sim, dir);
            Controller.ViewPrintLine("查找图片:{0,-15} rec:{1,-20} del:{2,-10} sim:{3,-10} dir:{4}", name, rec, del, sim, dir);
            Controller.ViewPrintLine("找到坐标:{0}\r\n", this.FoundPoint);
            return flag;
        }
        public bool FindPicN(string name, string del = "101010", double sim = 0.9, int dir = 0,int allowNotFoundCount = 1,int interval = 500)
        {
            for (int i = 0; i < allowNotFoundCount; i++)
            {   
                bool flag = this.FindPic(name,del, sim, dir);
                Controller.ViewPrintLine("最近一次调用的是带allowNotFoundCount参数的FindPicN()，还有【{0}】次检查是否找到 {1}.bmp", allowNotFoundCount - i + 1, name);
                if (flag == true)
                    return true;
                Thread.Sleep(interval);
            }
            return false;
        }

        public bool FindMultiColorN(Rectangle rec, string firstColor, string offsetColor, double sim = 0.9, int dir = 0, int allowNotFoundCount = 1, int interval = 500)
        {
            for (int i = 0; i < allowNotFoundCount; i++)
            {
                bool flag = base.FindMultiColor(rec, firstColor, offsetColor, sim, dir);
                Controller.ViewPrintLine("最近一次调用的是带allowNotFoundCount参数的FindMultiColorN()，还有【{0}】次检查是否找到", allowNotFoundCount - i + 1);
                if (flag == true)
                    return true;
                Thread.Sleep(interval);
            }
            return false;
        }

        public bool FindPic(int findCount, int interval, string name, Rectangle rec, string del = "101010", double sim = 0.9, int dir = 0)
        {
            Controller.CurrentThreadController.Content.ThreadSignalHandler.WaitSignal();
            for (int i = 0; i < findCount; i++)
            {
                bool flag = this.FindPic(name, rec, del, sim, dir);
                if (flag)
                {
                    return true;
                }
                Thread.Sleep(interval);
            }
            return false;
        }

        public override bool FindMultiColor(Rectangle rec, string firstColor, string offsetColor, double sim = 0.9, int dir = 0)
        {
            bool flag = base.FindMultiColor(rec, firstColor, offsetColor, sim, dir);
            Controller.ViewPrintLine("多点找色!");
            Controller.ViewPrintLine("找到坐标:{0}\r\n", this.FoundPoint);
            return flag;
        }
    }
}
