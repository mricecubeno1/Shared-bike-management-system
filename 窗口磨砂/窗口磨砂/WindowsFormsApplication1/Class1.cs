using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class WeatherGet
    {
        private static string GetCityId()
        {
            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create("http://61.4.185.48:81/g/");
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();
            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";
            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);
            String ReCode = Reads.ReadToEnd();
            Reads.Dispose();
            Streams.Dispose();
            wNetp.Close();
            String[] Temp = ReCode.Split(';');
            ReCode = Temp[1].Replace("var id=", "");
            return ReCode;
        }
        public static string GetWeather()
        {
            string wUrl = string.Format("http://m.weather.com.cn/data/{0}.html", GetCityId());
            HttpWebRequest wNetr = (HttpWebRequest)HttpWebRequest.Create(wUrl);
            HttpWebResponse wNetp = (HttpWebResponse)wNetr.GetResponse();
            wNetr.ContentType = "text/html";
            wNetr.Method = "Get";
            Stream Streams = wNetp.GetResponseStream();
            StreamReader Reads = new StreamReader(Streams, Encoding.UTF8);
            String ReCode = Reads.ReadToEnd();
            //关闭暂时不适用的资源
            Reads.Dispose();
            Streams.Dispose();
            wNetp.Close();
            //分析返回代码
            String[] Splits = new String[] { "\"", ",", "\"" };
            String[] Temp = ReCode.Split(Splits, StringSplitOptions.RemoveEmptyEntries);
            ReCode = String.Format("天气:{0} {1} {2}", Temp[5], Temp[62], Temp[26]);
            return ReCode;
        }
    }
}
