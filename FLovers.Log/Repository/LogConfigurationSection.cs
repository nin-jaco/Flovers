using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLovers.Log.Repository
{
    // Use the following web.config file.
    // <?xml version="1.0" encoding="utf-8" ?>
    // <configuration>
    //    <configSections>
    //        <section name="logConfiguration" type="FLovers.Log.Repository.LogConfigurationSection" />
    //    </configSections>
    //    <logConfiguration>
    //        <logProviders>
    //            <clear />
    //            <add name="Elmah" type="FLovers.Log.Repository.ElmahRepository" />
    //            <add name="NLog" type="FLovers.Log.Repository.NLogRepository" />
    //        </logProviders>
    //    </logConfiguration>
    // </configuration>

    /// <summary>
    /// Define a custom section named LogConfigurationSection containing a
    /// LogProviderCollection collection of LogProviderConfigElement elements.
    /// The collection is wrapped in an element named "logProviders" in the
    /// web.config file.
    /// LogProviderCollection and LogProviderConfigElement classes are defined below.
    /// This is the key class that shows how to use the ConfigurationCollectionAttribute.
    /// </summary>
    public class LogConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Declare the urls collection property.
        /// Note: the "IsDefaultCollection = false" instructs 
        /// .NET Framework to build a nested section of 
        /// the kind <logProviders>...</logProviders>.
        /// </summary>
        [ConfigurationProperty("logProviders", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(LogProviderCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public LogProviderCollection LogProviders
        {
            get
            {
                LogProviderCollection logProvidersCollection = (LogProviderCollection)base["logProviders"];
                return logProvidersCollection;
            }
        }

    }
}
