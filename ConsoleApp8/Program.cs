using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;


namespace LoadSite
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("https://www.simbirsoft.com/");
            string webData = System.Text.Encoding.UTF8.GetString(raw);

            var pageDoc = new HtmlDocument();
            pageDoc.LoadHtml(webData);
            var pageText = pageDoc.DocumentNode.InnerText;

            if (!String.IsNullOrEmpty(pageText))
            {
                File.WriteAllText(@"C:\Fraps\page.txt", pageText);
            }
            str = pageText.ToString();


            str = Regex.Replace(str, @"[ \r\n\t]", " ");
            while (str.Contains("  ")) { str = str.Replace("  ", " "); }
                        string[] pars = str.Split(' ','.','\"',',','-','\'','&','?','!','#',':',';','/','(',')','<','>','[',']', '-','?','<','>');
            for (int i = 0; i < pars.Length; i++)
            {
                pars[i] = pars[i].ToLowerInvariant();
            }
          
            /*
         for (int i = 0; i < pars.Length; i++)
             {
                 Console.WriteLine(pars[i]);
             }
            */
            int count = 0;

    
            Console.WriteLine("\n Уникальные слова, встречающиеся в тексте только 1 раз: \n");

            for (int i = 0; i < pars.Length; i++)
                         {

                for (int j = 0; j < pars.Length; j++)
                {
                    if (pars[i] == pars[j]) count++;
                    if (count > 1) break;
                }
                if (count == 1) Console.WriteLine(pars[i]);
                count = 0;
            }

      
            Console.ReadKey(true);

        }
    }
}