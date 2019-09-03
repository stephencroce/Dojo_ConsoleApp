using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MonkeyAroundNamespace
{
    public class MongoDatastoresSection : ConfigurationSection
    {
        
        //code representation of the individual element:
        public class MongoDataStoreConfigElement : ConfigurationElement
        {   
            public MongoDataStoreConfigElement()
            {

            }

            public MongoDataStoreConfigElement(string dblocation, string dbname, string collectionname, int appsubsysid)
            {
                //this.dbLocation = dblocation;
                //this.dbName = dbname;
                //this.collectionName = collectionname;
                //this.appSubsysId = appsubsysid;
                
            }
            [ConfigurationProperty("dblocation", IsRequired = true, IsKey = true, DefaultValue = "")]
            public string dbLocation
            {
                get { return (string)this["dblocation"]; }
                //set { this["dblocation"] = value; }
            }
            [ConfigurationProperty("dbname", IsRequired = true, IsKey = true,  DefaultValue = "")]
            //[IntegerValidator(MinValue = 1, MaxValue = 65536)]
            public string dbName
            {
                get { return (string)this["dbname"]; }
                //set { this["dbname"] = value; }
            }
            [ConfigurationProperty("collectionname", IsRequired = true, DefaultValue = "")]
            //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
            public string collectionName
            {
                get { return (string)this["collectionname"]; }
                //set { this["collectionname"] = value; }
            }
            [ConfigurationProperty("appsubsysid", IsRequired = true, DefaultValue = 0)]
            //[IntegerValidator(MinValue = 1, MaxValue = 65536)]
            public int appSubsysId
            {
                get { return (int)this["appsubsysid"]; }
                //set { this["appsubsysid"] = value; }
            }
            [ConfigurationProperty("MongoDataStores", IsDefaultCollection = true)]
            public MongoDataStoreCollection MongoDataStores
            {
                get { return (MongoDataStoreCollection)base["MongoDataStores"]; }

            }
        }
        //code representation of the collection of individual elements defined above:
        public class MongoDataStoreCollection : ConfigurationElementCollection
        {
            public MongoDataStoreConfigElement this[int index]
            {
                get { return (MongoDataStoreConfigElement)BaseGet(index); }
            }
            public new MongoDataStoreConfigElement this[string name]
            {
                get
                {
                    if (IndexOf(name) < 0) return null;

                    return (MongoDataStoreConfigElement)BaseGet(name);
                }
            }
            public int IndexOf(string dbLocation)
            {
                dbLocation = dbLocation.ToLower();

                for (int idx = 0; idx < base.Count; idx++)
                {
                    if (this[idx].dbLocation.ToLower() == dbLocation)
                        return idx;
                }
                return -1;
            }
            //must implement, or will not compile:
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((MongoDataStoreConfigElement)element).dbLocation;
            }
            //must implement, or will not compile:
            protected override ConfigurationElement CreateNewElement()
            {
                return new MongoDataStoreConfigElement();
            }
            //protected override string ElementName
            //{
            //    get { return "MongoDataStore"; }
            //}
        }



    }
}
