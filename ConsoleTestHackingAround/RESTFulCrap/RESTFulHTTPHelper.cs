using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ConsoleTestHackingAround.RESTFulCrap
{
    public static class RESTFulHTTPHelper
    {
        public static void MakeBasicHttpRequest(string strUrl)
        {
            //ever wonder - can you make an http request from a console app? HELL YES!!!! here's how you can do it:
            //https://support.microsoft.com/en-us/kb/307023
            //In .NET, the System.Net namespaces provide the WebRequest class to encapsulate a request for an Internet resource, 
            //and the WebResponse class to represent the data that is returned.

            Stream stream;
            StreamReader streamReader;

            WebRequest theWebRequest;
            theWebRequest = WebRequest.Create(strUrl);

            stream = theWebRequest.GetResponse().GetResponseStream();
            streamReader = new StreamReader(stream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = streamReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
            }
            Console.ReadLine();
        }
        public static void MakeDeliciousRESTFULRequest(string user, string password, Uri uri)
        {            
            //The del.icio.us web service gives you programmatic access to your bookmarks. You can write programs that bookmark URIs, convert your browser bookmarks to del.icio.us bookmarks, 
            //or fetch the URIs you’ve bookmarked in the past:
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(user, password);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            XPathDocument xml = new XPathDocument(response.GetResponseStream());
            XPathNavigator navigator = xml.CreateNavigator();

            foreach (XPathNavigator node in navigator.Select("/posts/post"))
            {
                string description = node.GetAttribute("description", "");
                string href = node.GetAttribute("href", "");
                Console.WriteLine(description + ": " + href);
            }
        }
    }
}
