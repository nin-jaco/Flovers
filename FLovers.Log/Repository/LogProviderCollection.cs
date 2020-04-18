using System;
using System.Configuration;

namespace FLovers.Log.Repository
{
    /// <summary>
    /// Define the UrlsCollection that will contain the UrlsConfigElement elements.
    /// </summary>
    public class LogProviderCollection : ConfigurationElementCollection
    {
        public LogProviderCollection()
        {
            // When the collection is created, always add one element 
            // with the default values. (This is not necessary; it is
            // here only to illustrate what can be done; you could 
            // also create additional elements with other hard-coded 
            // values here.)
            LogProviderConfigElement element = (LogProviderConfigElement)CreateNewElement();
            Add(element);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new LogProviderConfigElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((LogProviderConfigElement)element).Name;
        }

        public LogProviderConfigElement this[int index]
        {
            get
            {
                return (LogProviderConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new LogProviderConfigElement this[string Name]
        {
            get
            {
                return (LogProviderConfigElement)BaseGet(Name);
            }
        }

        public int IndexOf(LogProviderConfigElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(LogProviderConfigElement url)
        {
            BaseAdd(url);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(LogProviderConfigElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
