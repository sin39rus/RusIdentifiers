using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RusIdentifiersTests.Helpers
{
    internal class Serializer
    {
        internal static string SerializeObject<T>(T objectToSerialize)
        {
            try
            {
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    Encoding = Encoding.UTF8
                };

                using (var stream = new MemoryStream())
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
                    serializer.Serialize(writer, objectToSerialize);
                    return settings.Encoding.GetString(stream.ToArray());
                }
            }
            catch (Exception exp)
            {
                throw new Exception($"Ошибка сериализации.", exp);
            }
        }
        public static T DeserializeObject<T>(string str)
        {
            try
            {
                using (var stream = new MemoryStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(str);
                    writer.Flush();
                    stream.Position = 0;
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    return (T)formatter.Deserialize(stream);
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Ошибка десериализации.", exp);
            }
        }
    }
}
