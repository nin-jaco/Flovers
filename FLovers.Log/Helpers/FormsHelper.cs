using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using FLovers.Log.Repository;

namespace FLovers.Log.Helpers
{
    public class FormsHelper
    {
        public static string[] Timeperiods = new string[] { "Today", "Yesterday", "This Week", "Last Week", "This Month", "Last Month", "Last 30 days", "Last 60 days", "Last 90 days" };            
        public static string[] log_levels = new string[] { "All", "Debug", "Info", "Warning", "Error", "Fatal" };
        public static string[] paging_page_sizes = new string[] { "10", "15", "20", "25", "30", "50", "100" };

        public static IEnumerable<ListItem> LogProviderNames
        {
            get
            {
                var repository = new LogReportingFacade();
                var dict = repository.GetLogProviders();
                dict.Add("All", "All");
                var list = dict.OrderBy(item => item.Key).Select(o => new ListItem { Text = o.Key, Value = o.Key }).ToList();
                return list;
            }
        }

        public static IEnumerable<ListItem> LogLevels
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in log_levels) { dict.Add(item, item); }
                List<ListItem> list = dict.Select(o => new ListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }   

        public static IEnumerable<ListItem> CommonTimePeriods
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in Timeperiods) { dict.Add(item, item); }
                List<ListItem> list = dict.Select(o => new ListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }

        public static IEnumerable<ListItem> PagingPageSizes
        {
            get
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string item in paging_page_sizes) { dict.Add(item, item); }
                List<ListItem> list = dict.Select(o => new ListItem { Text = o.Value, Value = o.Key }).ToList();
                return list;
            }
        }

        public static string OutputXmlTableForLogging(string xml)
        {
            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(xml))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                for (int index = 0; index < xmlDoc.DocumentElement?.ChildNodes.Count; index++)
                {

                    XmlNode node = xmlDoc.DocumentElement.ChildNodes[index];

                    // Group header
                    sb.Append("<div>");
                    sb.Append("  <p class='table-caption'>" + node.Name + "</p>");

                    sb.Append("  <div class='scroll-view'>");

                    // Table for attributes
                    sb.Append("<table class='exception' cellspacing='1' style='border-collapse: collapse;'>");

                    sb.Append("<tr>");
                    sb.Append("  <th class='name-col' style='white-space: nowrap;'>Name</th>");
                    sb.Append("  <th class='value-col'>Value</th>");
                    sb.Append("</tr>");

                    for (int childIndex = 0; childIndex < node.ChildNodes.Count; childIndex++)
                    {
                        XmlNode childNode = node.ChildNodes[childIndex];

                        string rowClass = childIndex % 2 == 1 ? "even-row" : "odd-row";

                        sb.Append($"<tr class='{rowClass}'>");
                        sb.Append("  <td class='key-col'>" + childNode.Attributes["name"].InnerText + "</td>");
                        sb.Append("  <td class='value-col'>" + childNode.FirstChild.Attributes["string"].InnerText + "</td>");
                        sb.Append("</tr>");
                    }

                    sb.Append("</table>");
                    // ------------------------

                    sb.Append("  </div>");
                    sb.Append("</div>");
                }
            }

            return sb.ToString();
        }

    }
}