using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Dojo_ConsoleApp.RESTFulCrap
{
    public static class RESTFulHTTPHelper
    {
        public static string GetHTML(string theURL)
        {
            string someHtml = null;

            // *** Establish the request &INTERNAL=Y added to querystring so WebComm knows it's an application request and not a client navigation
            System.Net.HttpWebRequest objHttp = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(theURL);
            objHttp.Timeout = 100000; // timeout 100 sec

            // *** Retrieve request info headers
            System.Net.HttpWebResponse oWebResponse = (System.Net.HttpWebResponse)objHttp.GetResponse();
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(1252);

            System.IO.StreamReader oResponseStream = new System.IO.StreamReader(oWebResponse.GetResponseStream(), enc);
            someHtml = oResponseStream.ReadToEnd();   //get html as string

            oWebResponse.Close();
            oResponseStream.Close();

            return someHtml;
        }
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
        public static void GetDriverCareDocumentList()
        {

            string IP = "192.168.56.33"; //this is ntsrv41v4
            string port = "6405";
            string dformat = "json";

            string server = "http://" + IP + ":" + port + "/biprws/raylight/v1/documents";
            string ltoken = "\"" + "NTSVR41V4.ceinetwork.net:6400@{3&2=3942723,U3&2v=NTSVR41V4.ceinetwork.net:6400,UP&66=60,U3&68=secEnterprise:SafetyUser,UP&S9=865089,U3&qe=100,U3&vz=IZDKHxN04.MbEJYhFEj9X4Ho2OsF.0aH3Q4zClhvhkQ,UP}" + "\"";
            //string ltoken = @"NTSVR41V4.ceinetwork.net:6400@{3&2=3942723,U3&2v=NTSVR41V4.ceinetwork.net:6400,UP&66=60,U3&68=secEnterprise:SafetyUser,UP&S9=865089,U3&qe=100,U3&vz=IZDKHxN04.MbEJYhFEj9X4Ho2OsF.0aH3Q4zClhvhkQ,UP}";

            //SAP_BO_Login_Token token = JsonConvert.DeserializeObject<SAP_BO_Login_Token>((string)Session["LogonToken"]);
            //string ltoken = "\"" + token.logonToken + "\"";

            //string server = "http://" + IP + ":" + port + "/biprws/raylight/v1/documents";
            //Console.WriteLine("Operation: GET - URI: " + server);
            HttpWebRequest GetRequest = (HttpWebRequest)WebRequest.Create(server);
            GetRequest.Method = "GET";
            GetRequest.Accept = "application/" + dformat;
            GetRequest.Headers.Set("X-SAP-LogonToken", ltoken);
            HttpWebResponse GETResponse = (HttpWebResponse)GetRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);

            string json = sr.ReadToEnd();


            //not feasible - this seems to be hugely resource intensive and blows up memory and disk with a runaway IIS Worker Process:
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            Console.WriteLine(dataTable.Rows.Count);
            // 2

            foreach (DataRow row in dataTable.Rows)
            {
                //Response.Write(row["id"] + " - " + row["item"]);
                Console.WriteLine(row["id"] + " - " + row["cuid"]);
            }
            // 0 - item 0
            // 1 - item 1

            //return json;

        }
        public static void DeserializeADataSet()
        {
            string json = @"{
   'Table1': [
     {
       'id': 0,
       'item': 'item 0'
     },
     {
       'id': 1,
       'item': 'item 1'
    }
  ]
}";

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            Console.WriteLine(dataTable.Rows.Count);
            // 2

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }


        }
        public static void QueueTFSBuild()
        {
            //Simple example of how it is possible to use the restful API in TFS2015 to queue a build by id number, at CEI inc.
            //https://www.visualstudio.com/en-us/docs/integrate/api/build/builds
            //uses nothing but standard http calls.
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"http://ntsvrtfs:8080/tfs/DefaultCollection/Claimslink/_apis/build/builds?api-version=2.0");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("SteveCro:CEINetwork2017~"));

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"definition\":{\"id\":56}}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
}
