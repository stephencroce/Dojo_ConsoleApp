using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace MonkeyAroundNamespace3
{
    /// <summary>
    /// ///////////////
    /// </summary>
    public class MongoDatastoreConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("MongoDatastores", IsDefaultCollection = false)]
        [
        ConfigurationCollection(typeof(MongoDatastoreCollection),
            AddItemName = "datastore"//,
            //ClearItemsName = "clear",
            //RemoveItemName = "remove"
            )
        ]
        public MongoDatastoreCollection MongoDatastores  /// corresponds to the  <MongoDatastores> element in the app.config:
        {
            get
            {
                return (MongoDatastoreCollection)base["MongoDatastores"];
            }
        }
    }
    /// <summary>
    /// corresponds to a single datastore element, i.e. <datastore Port="6996" ReportType="File" />
    /// </summary>
    public class mongoDatastore : ConfigurationElement
    {
        public mongoDatastore() { }

        public mongoDatastore(int appSubsysId, string dbLocation, string dbName, string collectionName, int port, string reportType)
        {
            this.AppSubsysId = appSubsysId;
            this.DBLocation = dbLocation;
            this.DBName = dbName;
            this.CollectionName = collectionName; 
            //this.Port = port;
            //this.ReportType = reportType;
        }
        //<datastore dblocation="mongodb://localhost:27017" dbname="apptrace" collectionname="entries" appsubsysid="101" />
        [ConfigurationProperty("AppSubsysId", DefaultValue = 0, IsRequired = true, IsKey = true)]
        public int AppSubsysId
        {
            get { return (int)this["AppSubsysId"]; }
            set { this["AppSubsysId"] = value; }
        }
        [ConfigurationProperty("DBLocation", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string DBLocation
        {
            get { return (string)this["DBLocation"]; }
            set { this["DBLocation"] = value; }
        }
        [ConfigurationProperty("DBName", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string DBName
        {
            get { return (string)this["DBName"]; }
            set { this["DBName"] = value; }
        }
        [ConfigurationProperty("CollectionName", DefaultValue = "", IsRequired = true, IsKey = false)]
        public string CollectionName
        {
            get { return (string)this["CollectionName"]; }
            set { this["CollectionName"] = value; }
        }
        //[ConfigurationProperty("Port", DefaultValue = 0, IsRequired = true, IsKey = true)]
        //public int Port
        //{
        //    get { return (int)this["Port"]; }
        //    set { this["Port"] = value; }
        //}

        //[ConfigurationProperty("ReportType", DefaultValue = "File", IsRequired = true, IsKey = false)]
        //public string ReportType
        //{
        //    get { return (string)this["ReportType"]; }
        //    set { this["ReportType"] = value; }
        //}
    }
    /// <summary>
    /// corresponds to the  <MongoDatastores> element in the app.config:
    /// </summary>
    public class MongoDatastoreCollection : ConfigurationElementCollection
    {
        public MongoDatastoreCollection()
        {
            Console.WriteLine("HELLO from MongoDatastoreCollection Constructor");
        }

        public mongoDatastore this[int index]
        {
            get { return (mongoDatastore)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        //public void Add(mongoDatastore serviceConfig)
        //{
        //    BaseAdd(serviceConfig);
        //}

        //public void Clear()
        //{
        //    BaseClear();
        //}

        //this must be implemented, or will not compile:
        protected override ConfigurationElement CreateNewElement()
        {
            return new mongoDatastore();
        }
        //this must be implemented, or will not compile:
        protected override object GetElementKey(ConfigurationElement element)
        {
            //return ((mongoDatastore)element).Port;
            return ((mongoDatastore)element).AppSubsysId;
        }

        //public void Remove(mongoDatastore serviceConfig)
        //{
        //    BaseRemove(serviceConfig.Port);
        //}

        //public void RemoveAt(int index)
        //{
        //    BaseRemoveAt(index);
        //}

        //public void Remove(string name)
        //{
        //    BaseRemove(name);
        //}
    }
}
