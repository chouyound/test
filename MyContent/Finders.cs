using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDm;

namespace MyContent
{
    public static class Finders
    {
        public static Func<bool> JingjiRedPoint = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("竞技红点", new Rectangle(196, 566, 258, 640));
        };
        public static Func<bool> YezhanPk = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("每日奖励", new Rectangle(53, 230, 150, 269));
        };
        public static Func<bool> YezhanPkRePoint = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("野战PK红点", new Rectangle(1, 664, 124, 731));
        };
        public static Func<bool> MainView = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("自动挑战", new Rectangle(399, 557, 496, 605));
        };
        public static Func<bool> WangzhezhenbaRedPoint = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("王者争霸红点", new Rectangle(113, 668, 238, 724));
        };
        public static Func<bool> Pipeiduishou = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("匹配对手", new Rectangle(172, 620, 339, 669));
        };
        public static Func<bool> Qianwantiaozhan = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("前往挑战", new Rectangle(100, 620, 253, 668));
        };
        public static Func<bool> Zidonzhandou = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("自动战斗", new Rectangle(418, 537, 498, 609));
        };
        public static Func<bool> Tingzhizhandou = () =>
        {
            return MyDmSoft.CurrentThreadDm.FindPic("停止战斗", new Rectangle(418, 537, 498, 609));
        };
        public static Func<bool> Tiaozhan = () =>
        {
            return BaiduOcr.OcrByCapture(new Rectangle(398,605,447,630)).RegexMatch("挑|战");
        };
        public static Func<bool> Zidonfuhuo = () =>
        {
            return BaiduOcr.OcrByCapture(new Rectangle(338, 614, 397, 636)).RegexMatch("自|动|复|活");
        };
    }
}
