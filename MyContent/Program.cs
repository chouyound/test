using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Baymax;
using MyDm;
using System.IO;
using System.Text.RegularExpressions;

namespace MyContent
{
    /*
     * 点击挑战BOSS以后，有黑屏显示未刷新的情况，要关掉重新打开
     */

    [Description("王城争霸超V版脚本1.0")]
    public partial class Program : IContent
    {
        public void Main(string[] args)
        {
            this.init();

            Finders.Tiaozhan();

            //mojie();
            return;
            do
            {
                jingji();


                Thread.Sleep(500);
            } while (true);
            
            Controller.ViewPrintLine("ok!");
        }

        void mojie()
        {
            Waiting waiting = new Waiting();

            //点击BOOS
            waiting.BackClick(454, 406);
            Thread.Sleep(500);

            //等待前往挑战
            waiting.SetFinder(Finders.Qianwantiaozhan).WaitShow(null,waiting.NewBackChecker(Finders.MainView));
            Thread.Sleep(500);

            //点击十倍爆率
            this.dm.Click(433, 188);
            Thread.Sleep(500);

            //点击前往挑战
            waiting.BackClickFoundPoint();
            Thread.Sleep(500);

            //等待进入
            waiting.SetFinder(Finders.Zidonzhandou).WaitShow(null, waiting.BackChecker);
            Thread.Sleep(500);

            //点击自动战斗
            this.dm.ClickFoundPoint();
            Thread.Sleep(5000);

            DateTime startDatetime = DateTime.Now;
            do
            {
                //等待恢复成 ‘自动战斗’
                waiting.SetFinder(Finders.Zidonzhandou).WaitShow();
                Thread.Sleep(500);

                TimeSpan timeSpan = DateTime.Now - startDatetime;
                if (timeSpan.Hours >= 1)
                    return;
                else
                    Controller.ViewPrintLine("检测到当前计时未满足1小时。与起始时间的分钟差：{0}",timeSpan.Minutes);

                //点击随机传送
                waiting.BackClick(432, 611);
                Thread.Sleep(500);

                //点击自动战斗
                this.dm.Click(458, 575);
                Thread.Sleep(5000);
            } while (true);
        }
        void jingji()
        {
            Waiting waiting = new Waiting();

            //如果竞技有红点则点它
            Finders.JingjiRedPoint();
            if (this.dm.FindSuccess)
                waiting.BackClick(227, 607);
            else
                return;
            Thread.Sleep(500);

            //等待野战PK页打开
            waiting.SetFinder(Finders.YezhanPk).WaitShow();
            Thread.Sleep(500);

            //如果‘野战PK’有红点的话
            if (Finders.YezhanPkRePoint())
            {
                //点击挑战
                waiting.BackClick(422, 355);
                Thread.Sleep(10000);

                //等待到主界面
                waiting.SetFinder(Finders.MainView).WaitShow(null, waiting.NewBackChecker(Finders.YezhanPkRePoint));
            }
            else if (Finders.WangzhezhenbaRedPoint())
            {
                //点击王者争霸红点
                waiting.BackClickFoundPoint();
                Thread.Sleep(500);

                //等待匹配对手界面
                waiting.SetFinder(Finders.Pipeiduishou).WaitShow(waiting.BackChecker);
                Thread.Sleep(500);

                //点击匹配对手
                waiting.BackClickFoundPoint();
                Thread.Sleep(500);

                //等待到主界面
                waiting.SetFinder(Finders.MainView).WaitShow(null, waiting.NewBackChecker(Finders.Pipeiduishou));
            }
        }
        void quanmin()
        {
            Waiting waiting = new Waiting();

            //点击BOOS
            waiting.BackClick(454, 406);
            Thread.Sleep(500);
            
            //
            //根据红点检测是否有挑战次数
            //
            

            //等待魔界界面（以前往挑战作为标识）
            waiting.SetFinder(Finders.Qianwantiaozhan).WaitShow(null, waiting.NewBackChecker(Finders.MainView));
            Thread.Sleep(500);

            //点击全民选项
            waiting.BackClick(192, 701);
            Thread.Sleep(500);

            //等待‘全民BOSS’界面
            waiting.SetFinder(Finders.Tiaozhan).WaitShow(null, waiting.BackChecker);
            Thread.Sleep(500);

            //点击最后一项挑战
            waiting.BackClick(425, 621);
            Thread.Sleep(500);

            //勾选自动复活
            waiting.SetFinder(Finders.Zidonfuhuo).WaitShow(null, waiting.BackChecker);
            waiting.BackClick(0,0);

            //等待回到主界面..
        }
        void shenyu()
        {
            //点击BOOS挑战

            //点击神域选项

            //如果有挑战次数：

            //点击最后一项挑战

            //勾选自动复活

            //等待回到主界面..
        }
    }
}

