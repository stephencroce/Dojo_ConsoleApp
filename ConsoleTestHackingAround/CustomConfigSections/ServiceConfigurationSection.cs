using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace MonkeyAroundNamespace2
{
    /// <summary>
    /// ///////////////
    /// </summary>
    public class ServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Services", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ServiceCollection Services
        {
            get
            {
                return (ServiceCollection)base["Services"];
            }
        }
    }
    /// <summary>
    /// /////////////////////////////////////////
    /// </summary>
    public class ServiceConfig : ConfigurationElement
    {
        public ServiceConfig() { }

        public ServiceConfig(int port, string reportType)
        {
            this.Port = port;
            this.ReportType = reportType;
        }

        [ConfigurationProperty("Port", DefaultValue = 0, IsRequired = true, IsKey = true)]
        public int Port
        {
            get { return (int)this["Port"]; }
            set { this["Port"] = value; }
        }

        [ConfigurationProperty("ReportType", DefaultValue = "File", IsRequired = true, IsKey = false)]
        public string ReportType
        {
            get { return (string)this["ReportType"]; }
            set { this["ReportType"] = value; }
        }
    }
    public class ServiceCollection : ConfigurationElementCollection
    {
        public ServiceCollection()
        {
            Console.WriteLine("ServiceCollection Constructor");
        }

        public ServiceConfig this[int index]
        {
            get { return (ServiceConfig)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ServiceConfig serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceConfig)element).Port;
        }

        public void Remove(ServiceConfig serviceConfig)
        {
            BaseRemove(serviceConfig.Port);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
