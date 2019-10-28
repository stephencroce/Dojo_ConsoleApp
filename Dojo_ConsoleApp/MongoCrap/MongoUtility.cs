using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using CEI.Application.Shared.Core.Diagnostics;
//using CEI.Application.Shared.Core.Diagnostics.Model;
using Dojo_ConsoleApp.MongoCrap;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using MongoDB.Bson;

using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;


namespace Dojo_ConsoleApp.MongoCrap
{
    public class MongoUtility
    {
        public static void SeedOrUnseed()
        {

            //create test mongo trace records 
            Console.WriteLine("Seed (S) or Unseed (U)?");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == 's')
            {
                Console.WriteLine(string.Format("\nHow many records?"));
                var numSeedRecords = Console.ReadLine();
                int value;
                if (int.TryParse(numSeedRecords.ToString(), out value))
                {
                    Console.WriteLine(string.Format("\nSeeding {0} records....", value));
                    //Logger.MongoSeed(10000); 
                    MongoSeed(value);
                    Console.WriteLine("\nDone Seed");
                }
            }
            else
            {
                Console.WriteLine("\nUnseeding....");
                MongoUnSeed();
                Console.WriteLine("\nDone Unseed");
            }


        }

        public static async void MongoSeed(int numSeedRecords)
        {
            try
            {

                //Let's mess with some JSON, shall we?
                //http://stackoverflow.com/questions/16898731/creating-an-json-array-in-c-sharp
                var mongoDataStores = new
                {
                    dbCollection = new[] {    
                        //new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace"  , CollectionName = "entries", AppSubSysID = "101"}, 
                        new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace2" , CollectionName = "entries", AppSubSysID = "100"},
                        new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace3" , CollectionName = "entries", AppSubSysID = "99"}
                    }
                };

                foreach (var mongoDataStore in mongoDataStores.dbCollection)
                {

                    //var client = new MongoClient("mongodb://localhost:27017");
                    MongoClient client = new MongoClient(mongoDataStore.DbLocation);

                    //var database = server.GetDatabase("apptrace");
                    IMongoDatabase database = client.GetDatabase(mongoDataStore.DbName);

                    //var collection = database.GetCollection<TraceEntry>("entries");
                    IMongoCollection<TraceEntry> collection = database.GetCollection<TraceEntry>(mongoDataStore.CollectionName);

                    //for (int i = 0; i < 10000; i++)
                    //for (int i = 0; i < 3; i++)
                    for (int i = 0; i < numSeedRecords; i++)
                    {
                        var myDic = new Dictionary<string, string>();
                        myDic.Add("userId", Ipsum.GetRandomNumberBetween(5921700, 5921800).ToString());
                        myDic.Add("name", Ipsum.GetPhrase(5).Replace(".", string.Empty) + ", " + Ipsum.GetPhrase(5).Replace(".", string.Empty));
                        myDic.Add("jwt", Guid.NewGuid().ToString());

                        TraceEntry traceEntry = new TraceEntry()
                        {
                            //populate rest of object here….
                            Id = Guid.NewGuid(),
                            LogTypeID = Ipsum.GetRandomNumberBetweenOneAnd(11),  // creates a number between 1 and 10
                            Severity = Ipsum.GetRandomNumberBetweenOneAnd(11),
                            //Occurred = DateTime.Now,
                            Occurred = Ipsum.GetRandomDay(),
                            Entry = Ipsum.GetPhrase(10),
                            SessionID = Guid.NewGuid(),
                            //AppSubSysID = 99,
                            AppSubSysID = int.Parse(mongoDataStore.AppSubSysID),
                            ProcessID = Ipsum.GetRandomNumberBetween(1001, 99000),
                            ThreadID = Ipsum.GetRandomNumberBetweenOneAnd(101).ToString(),
                            //Source = Ipsum.GetPhrase(1),
                            Source = "Ipsum Generator" + Ipsum.GetRandomNumberBetweenOneAnd(100).ToString(),
                            //Keys = new Dictionary<string, string>().Add("","")
                            Keys = myDic,
                            Expires = DateTime.Today.AddDays(Ipsum.GetRandomNumberBetweenOneAnd(90))
                        };
                        await collection.InsertOneAsync(traceEntry);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async void MongoUnSeed()
        {
            try
            {
                //Let's mess with some JSON, shall we?
                //http://stackoverflow.com/questions/16898731/creating-an-json-array-in-c-sharp
                var mongoDataStores = new
                {
                    dbCollection = new[] {    
                        //new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace"  , CollectionName = "entries", AppSubSysID = "101"}, 
                        new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace2" , CollectionName = "entries", AppSubSysID = "100"},
                        new {DbLocation = "mongodb://localhost:27017", DbName = "apptrace3" , CollectionName = "entries", AppSubSysID = "99"}
                    }
                };

                foreach (var mongoDataStore in mongoDataStores.dbCollection)
                {

                    //var client = new MongoClient("mongodb://localhost:27017");
                    var client = new MongoClient(mongoDataStore.DbLocation);

                    //var database = server.GetDatabase("apptrace");
                    var database = client.GetDatabase(mongoDataStore.DbName);

                    //var collection = database.GetCollection<TraceEntry>("entries");
                    var collection = database.GetCollection<TraceEntry>(mongoDataStore.CollectionName);

                    var builder = Builders<TraceEntry>.Filter;

                    //var query = Query<TraceEntry>.EQ(e => e.AppSubSysID, int.Parse(mongoDataStore.AppSubSysID));
                    var query = builder.Eq(e => e.AppSubSysID, int.Parse(mongoDataStore.AppSubSysID)) & builder.Not(builder.Eq(e => e.Source, "Unicorn"));
                    //query = Query.Not(Query<TraceEntry>.EQ(e => e.Source, "Unicorn"));
                    await collection.DeleteManyAsync(query);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
        {
            // convert datetime to a TimeSpan
            TimeSpan now = datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }

    }
}
