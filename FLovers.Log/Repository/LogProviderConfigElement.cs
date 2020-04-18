using System.Configuration;

namespace FLovers.Log.Repository
{
    /// <summary>
    /// Define the element type contained by the UrlsCollection collection.
    /// </summary>
    public class LogProviderConfigElement : ConfigurationElement
    {
        public LogProviderConfigElement(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public LogProviderConfigElement()
        {
            // Attributes on the properties provide default values.
        }

        [ConfigurationProperty("name", DefaultValue = "NLog", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", DefaultValue = "FLovers.Log.Repository.NLogRepository", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

    }
}
