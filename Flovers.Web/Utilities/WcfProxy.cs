using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Configuration;

namespace Flovers.Web.Utilities
{
    public class WcfProxy
    {
        private static readonly ChannelFactoryManager FactoryManager = new ChannelFactoryManager();
        private static readonly ClientSection ClientSection = WebConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;

        public void PerformRemote<T>(Action<T> action)
        {
            var tType = typeof(T);
            var endpoint = GetEndpointNameAddressPair(tType);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            T arg = FactoryManager.CreateChannel<T>(endpoint.Key, endpoint.Value);
            ICommunicationObject obj2 = (ICommunicationObject)arg;

            bool succeeded = false;
            try
            {
                if (obj2.State == CommunicationState.Faulted) throw new Exception("Error connecting to wcf.");
                action(arg);
                obj2.Close();
                succeeded = true;
            }
            finally
            {
                if (!succeeded)
                {
                    obj2.Abort();
                }
            }
        }

        public T2 PerformRemote<T, T2>(Func<T, T2> action)
        {
            var tType = typeof(T);
            var endpoint = GetEndpointNameAddressPair(tType);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            T arg = FactoryManager.CreateChannel<T>(endpoint.Key, endpoint.Value);
            ICommunicationObject obj2 = (ICommunicationObject)arg;
            bool succeeded = false;
            try
            {
                if (obj2.State == CommunicationState.Faulted) throw new Exception("Error connecting to wcf.");
                T2 res = action(arg);
                obj2.Close();
                succeeded = true;
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (!succeeded)
                {
                    obj2.Abort();
                }
            }
        }


        private KeyValuePair<string, string> GetEndpointNameAddressPair(Type serviceContractType)
        {
            var configException = new ConfigurationErrorsException(string.Format("No client endpoint found for type {0}. Please add the section <client><endpoint name=\"myservice\" address=\"http://address/\" binding=\"basicHttpBinding\" contract=\"{0}\"/></client> in the config file.", serviceContractType));
            if (((ClientSection == null) || (ClientSection.Endpoints == null)) || (ClientSection.Endpoints.Count < 1))
            {
                throw configException;
            }
            foreach (ChannelEndpointElement element in ClientSection.Endpoints)
            {
                if (element.Contract == serviceContractType.ToString())
                {
                    return new KeyValuePair<string, string>(element.Name, element.Address.AbsoluteUri);
                }
            }
            throw configException;
        }
    }
}