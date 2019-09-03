using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestHackingAround
{
    class FileSystemWriter
    {

        public static void WriteSomething(string Message)
        {

            string timestamp = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            FileStream fs = new FileStream(@"c:\temp\ConsoleTestHackingAroundService.txt",
            FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(string.Format("ConsoleTestHackingAroundService: Service {1} at {0}, dingbat.\n", timestamp, Message));
            m_streamWriter.Flush();
            m_streamWriter.Close();
            //Console.WriteLine("Service is starting."); 


        }
        public static void FunWithFileStreams()
        {

            Console.WriteLine("***** Fun with FileStreams *****\n");
            // Obtain a FileStream object.   
            using (FileStream fStream = File.Open(@"C:\myMessage.dat", FileMode.Create))
            {     // Encode a string as an array of bytes. 
                string msg = "Hello!"; byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Write byte[] to file.    
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // Reset internal position of stream.   
                fStream.Position = 0;
                // Read the types from file and display to console.     
                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }
                // Display decoded messages.    
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
             
                
            }

            //NOPE - it needs to work with some sort of file:   I guess if you don't want to use a file, then you're into Memory Stream.
            //using (FileStream fStream2 = new FileStream()
            //{
            //    string msg2 = "ByeByeBye?"; byte[] msgAsByteArray = Encoding.Default.GetBytes(msg2);
            //    fStream2.Write(msgAsByteArray, 0, msgAsByteArray.Length);
            //    fStream2.Position = 0;

            //    Console.Write("Your message2 as an array of bytes: ");
            //    byte[] bytesFromFile = new byte[msgAsByteArray.Length];
            //    for (int i = 0; i < msgAsByteArray.Length; i++)
            //    {
            //        bytesFromFile[i] = (byte)fStream2.ReadByte();
            //        Console.Write(bytesFromFile[i]);
            //    }
            //    // Display decoded messages.    
            //    Console.Write("\nDecoded Message: ");
            //    Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            //    Console.ReadLine();
            //}




        }
    }
}
