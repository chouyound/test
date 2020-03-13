using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using Baymax;
using MyDm;

namespace MyContent
{
    public class BaiduOcr
    {
        public BaiduOcr()
        {
            this.ApiKey = "3yGAHRIKpZdHqaWXCKai2Obo";
            this.SecretKey = "BrMI5fZ13b1G0N8KdTu9O2i6SM4CGZbI";

            var client = new Baidu.Aip.Ocr.Ocr(this.ApiKey, this.SecretKey);
            client.Timeout = 60000;
            this.ocrClient = client;
        }

        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public int Timeout { get; set; }
        private Baidu.Aip.Ocr.Ocr ocrClient;
        private static BaiduOcr baiduOcr = new BaiduOcr();

        /// <summary>
        /// 本地图片识别
        /// </summary>
        /// <param name="filename">本地图片路径</param>
        /// <returns>返回所有识别到的文字。</returns>
        public string Ocr(string picFile)
        {
            var image = File.ReadAllBytes(picFile);

            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"language_type", "CHN_ENG"},
                {"detect_direction", "true"},
                {"detect_language", "true"},
                {"probability", "true"}
            };

            // 带参数调用通用文字识别, 图片参数为本地图片
            var result = this.ocrClient.GeneralBasic(image, options);
            Match match = Regex.Match(result.ToString(), @"\""words\"".+");
            match = Regex.Match(match.Value, @"(?<=\""\:[ ]?\"").+(?=\""\,?)");
            return match.Value;
        }

        /// <summary>
        /// 本地图片识别
        /// </summary>
        /// <param name="filename">本地图片路径</param>
        /// <returns>返回所有识别到的数字和英文句点字符。</returns>
        public string OcrNum(string picFile)
        {
            string ret = this.Ocr(picFile);
            return Regex.Match(ret, "[0-9.]+").Value;
        }

        /// <summary>
        /// 通过大漠截图进行OCR
        /// </summary>
        /// <param name="rec">截取范围</param>
        /// <param name="capturedDelay">截取图片后延时</param>
        /// <returns>返回所有识别到的文字。</returns>
        public static string OcrByCapture(Rectangle rec,int capturedDelay = 100)
        {
            IContent content = Controller.CurrentThreadController.Content;
            string picfile = content.SourceFile + content.Simulator.Name + "-ocr.bmp";
            MyDmSoft.CurrentThreadDm.Capture(rec, picfile);
            Thread.Sleep(capturedDelay);
            string res = baiduOcr.Ocr(picfile);
            Controller.ViewPrintLine("OCR结果：{0}", res);
            return res;
        }

        /// <summary>
        /// 通过大漠截图进行OCR
        /// </summary>
        /// <param name="rec">截取范围</param>
        /// <param name="capturedDelay">截取图片后延时</param>
        /// <returns>返回所有识别到的数字和英文句点字符。</returns>
        public static string OcrNumByCapture(Rectangle rec, int capturedDelay = 100)
        {
            IContent content = Controller.CurrentThreadController.Content;
            string picfile = content.SourceFile + content.Simulator.Name + "-ocr.bmp";
            MyDmSoft.CurrentThreadDm.Capture(rec, picfile);
            Thread.Sleep(capturedDelay);
            string res = baiduOcr.OcrNum(picfile);
            Controller.ViewPrintLine("OCR结果：{0}", res);
            return res;
        }
    }
}
