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

            //try
            //{
            //    var response = (HttpWebResponse)request.GetResponse();
            //    checkresponce = response.ToString();
            //}
            //catch (Exception e)
            //{

            //    //checkresponce = "Exception: " + e.Message.ToString();
            //    checkresponce = ((HttpWebResponse)e.Response).StatusCode;
            //}

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
                //checkresponce = "no responce from site";
                checkresponce = "Response Code: 408 - RequestTimeout";
            }
            else
            {
                statusCode = response.StatusCode;
                //Stream dataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(dataStream);
                //sResponse = reader.ReadToEnd();
                //Console.WriteLine(sResponse);
                //Console.WriteLine("Response Code: " + (int)statusCode + " - " + statusCode.ToString());

                checkresponce = "Response Code: " + (int)statusCode + " - " + statusCode.ToString();
            }


            // status code...
            //return response.StatusCode;

            return checkresponce;

        }






    }
}
