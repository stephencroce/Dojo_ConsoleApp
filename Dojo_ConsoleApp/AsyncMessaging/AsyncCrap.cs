using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this demo came from Beginning C# Object-Oriented Programming, 2nd Edition, p141-ish.  This is not by any means a perfect implementation, but I think it gets the point across about what's happening.
//GOOGLE THIS:  https://www.google.com/webhp?sourceid=chrome-instant&rlz=1C1CHFX_enUS649US649&ion=1&espv=2&ie=UTF-8#q=c%23%20multithreading%20vs%20asynchronous
//OR THIS:  https://www.google.com/webhp?sourceid=chrome-instant&rlz=1C1CHFX_enUS649US649&ion=1&espv=2&ie=UTF-8#q=multithreading+vs+asynchronous
//Essentially, what's the difference between async programming and multi threading? - compare and contrast?  It's a whole big discussion

namespace Dojo_ConsoleApp.AsyncMessaging
{
    /// <summary>
    /// When a client object makes a synchronous message call to a server object, the client suspends processing and waits for a response back from the server before continuing. 
    /// Synchronous messaging is the easiest to implement and is the default type of messaging implemented in the .NET Framework.
    /// 
    /// 
    /// However, sometimes this is an inefficient way of passing messages. For example, the synchronous messaging model is not well suited for long-running file reading and writing, 
    /// making service calls across slow networks, or message queuing in disconnected client scenarios. To more effectively handle these types of situations, the .NET Framework provides the 
    /// plumbing needed to pass messages between objects asynchronously.
    /// 
    /// the Task class and other types like System.Threading library are used to implement asynchronous programming
    /// </summary>
    public class AsyncCrap
    {
        /// <summary>
        /// reads a file path specified by the calling function:
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>string</returns>
        public static string LogReadRegularOldSynchWay(string filePath)
        {
            string fileText = doSomethingThatTakesALongTme_sync(filePath, false);
            return fileText; 
        }
        public static string doSomethingThatTakesALongTme_sync(string filePath, bool async)
        {
            //simulate the slowness:
            System.Threading.Thread.Sleep(5000);

            StreamReader oStreamReader;
            string fileText;

            oStreamReader = File.OpenText(filePath);
            fileText = oStreamReader.ReadToEnd(); oStreamReader.Close();
            oStreamReader.Close();
            return fileText;

        }
        /// <summary>
        /// Now create an asynchronous method that reads the text file.
        /// Note the use of the task’s Delay method is to simulate a long running process:
        /// Note the use the Task/Await Pattern
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static async Task<string> LogReadAsync(string filePath)
        {
            //An async method should contain at least one await statement. 
            //When the await statement is encountered, processing is suspended and control is returned to the caller (UI in this case). 
            //So the user can continue to interact with the UI. Once the async task is complete, processing is returned back to the await statement and the caller can be alerted that the processing
            //is finished

            var fileText = await doSomethingThatTakesALongTme_async(filePath, true);
            
           // Console.ReadKey();
            Console.WriteLine(fileText);
            Console.WriteLine("\n  As you can see, the slow method finally returned!");
                      
            
            return fileText;
        }
        public static async Task<string> doSomethingThatTakesALongTme_async(string filePath, bool async)
        {
            //An async method should contain at least one await statement. 
            //When the await statement is encountered, processing is suspended and control is returned to the caller (UI in this case). 
            //So the user can continue to interact with the UI. Once the async task is complete, processing is returned back to the await statement and the caller can be alerted that the processing
            //is finished

            await Task.Delay(10000);  //simulate the slowness of the task taking to finish its execution:

            StreamReader oStreamReader;
            string fileText;


            oStreamReader = File.OpenText(filePath);
            fileText = await oStreamReader.ReadToEndAsync();            
            oStreamReader.Close();

            return fileText; 

        }
    }
}
