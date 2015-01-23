namespace Pear.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    using Newtonsoft.Json;

    public class Utilities
    {
        public static string ObjectToJson(object obj)
        {
            return ObjectToJson(obj, false);
        }

        public static string ObjectToJson(object obj, bool ignoreNullObjects)
        {
            return JsonConvert.SerializeObject(
                obj,
                new JsonSerializerSettings
                {
                    NullValueHandling = ignoreNullObjects ? NullValueHandling.Ignore : NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
        }

        public static string ObjectToJson(object obj, int maxDepth)
        {
            return JsonConvert.SerializeObject(
                obj,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MaxDepth = maxDepth
                });
        }

        public static object JsonToObject(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public static string SerializeToXml<T>(T obj)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringBuilder xml = new StringBuilder();
                TextWriter tw = new StringWriter(xml);

                serializer.Serialize(tw, obj);
                tw.Close();

                return xml.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T DeserializeXml<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                object obj;

                using (XmlReader reader = XmlTextReader.Create(new StringReader(xml)))
                {
                    obj = serializer.Deserialize(reader);
                }

                return (T)obj;
            }
            catch
            {
                return default(T);
            }
        }

        public static string TransformXml(string xml, string xslt)
        {
            TextReader trXml = new StringReader(xml);
            XmlReader xrXsl = new XmlTextReader(new StringReader(xslt));
            StringBuilder sbResult = new StringBuilder();
            TextWriter twResult = new StringWriter(sbResult);

            XPathDocument myXPathDoc = new XPathDocument(trXml);
            XslCompiledTransform myXslTrans = new XslCompiledTransform();

            myXslTrans.Load(xrXsl);
            myXslTrans.Transform(myXPathDoc, null, twResult);

            return sbResult.ToString();
        }

        /// <summary>
        /// Hash the data with SHA256.
        /// </summary>
        /// <param name="dataToBeHashed"></param>
        /// <returns></returns>
        public static string SHA256(string dataToBeHashed)
        {
            if (string.IsNullOrEmpty(dataToBeHashed))
            {
                return null;
            }

            byte[] data = Encoding.Default.GetBytes(dataToBeHashed);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(data);

            return Convert.ToBase64String(result);
        }

        public static void RegisterStyle(Page page, string id, string href)
        {
            if (page.Header.FindControl(id) != null)
            {
                return;
            }

            var cssLink = new HtmlLink();
            cssLink.Href = href;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            cssLink.ID = id;
            page.Header.Controls.Add(cssLink);
        }

        public static string DumpException(Exception ex)
        {
            StringBuilder stacktrace = new StringBuilder();

            while (ex != null)
            {
                stacktrace.Append("\r\n----------------------------------------------------------------------\r\n");
                stacktrace.Append(ex.Message);
                stacktrace.Append(ex.StackTrace);
                ex = ex.InnerException;
            }

            return stacktrace.ToString();
        }
    }
}
