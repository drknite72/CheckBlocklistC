using System;
using System.Net;
using System.IO;

namespace CheckBlocklistC
{
    class Program
    {
        static void Main(string[] args)
        {
            var webres = string.Empty;
            webres = CheckUrl("https://www.google.com");
            Console.Write(webres);
            Console.ReadKey();
        }

        private static string CheckUrl(string myurl)
        {
            var request = (HttpWebRequest)WebRequest.Create(myurl);
            request.Method = "HEAD";
            var checkresponce = String.Empty;

            HttpWebResponse response = null;
            HttpStatusCode statusCode;
            var sResponse = String.Empty;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException we)
            {
                response = (HttpWebResponse)we.Response;
            }

            if (response == null)
            {
                checkresponce = "Response Code: 408 - RequestTimeout";
            }
            else
            {
                statusCode = response.StatusCode;
                checkresponce = "Response Code: " + (int)statusCode + " - " + statusCode.ToString();
            }
            return checkresponce;
        }






    }
}
