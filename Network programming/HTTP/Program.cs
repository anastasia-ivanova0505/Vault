using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpWebRequest reqw = (HttpWebRequest)HttpWebRequest.Create("http://itstep.org");
            //HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse(); //создаем объект отклика

            //using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default))
            //{ //создаем поток для чтения отклика
            //    Console.WriteLine(sr.ReadToEnd());
            //    //вывести на экран все, что читается
            //}


            //foreach (string header in resp.Headers)
            //    Console.WriteLine("{0}:{1}", header, resp.Headers[header]);


            ////создание объекта web-клиент
            //WebClient client = new WebClient();
            ////получение содержимого странички
            //byte[] urlData = client.DownloadData("http://itstep.org");
            ////преобразование полученного содержимого в строку
            ////для отображения в консоли
            //string page = Encoding.ASCII.GetString(urlData);
            //Console.WriteLine(page);


            //создание объекта web-клиент
            WebClient client = new WebClient();
            string fileCopy = "E:\\ttt.jpg", urlString =
             "https://www.yandex.ru/images/search?pos=1&nl=1&img_url=https%3A%2F%2Fsun9-65.userapi.com%2Fc854124%2Fv854124167%2F170b44%2F1bpvKBWDz8o.jpg&text=%D0%BA%D1%80%D0%B0%D1%81%D0%B8%D0%B2%D1%8B%D0%B5%20%D0%B3%D0%BE%D1%80%D0%BE%D0%B4%D0%B0%20%D0%BC%D0%B8%D1%80%D0%B0&rpt=simage";
            //закачка web-ресурса в файл с именем fileCopy
            client.DownloadFile(urlString, fileCopy);






        }
    }
}
