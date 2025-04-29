using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RusIdentifiersTests.Helpers
{
    internal class Serializer
    {
        internal static string SerializeObject<T>(T objectToSerialize)
        {
            objectToSerialize = objectToSerialize ?? throw new ArgumentNullException(nameof(objectToSerialize));
            try
            {
                var settings = new XmlWriterSettings
                {
                    Indent = false,
                    Encoding = Encoding.UTF8,
                };

                using var stream = new MemoryStream();
                using var writer = XmlWriter.Create(stream, settings);
                XmlSerializer serializer = new (objectToSerialize.GetType());
                serializer.Serialize(writer, objectToSerialize);
                return settings.Encoding.GetString(stream.ToArray());
            }
            catch (Exception exp)
            {
                throw new Exception($"Ошибка сериализации.", exp);
            }
        }
        public static T? DeserializeObject<T>(string value)
        {
            try
            {
                using var stream = new MemoryStream();
                using var writer = new StreamWriter(stream);
                writer.Write(value);
                writer.Flush();
                stream.Position = 0;
                XmlSerializer formatter = new (typeof(T));
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                return (T)formatter.Deserialize(stream);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            }
            catch (Exception exp)
            {
                throw new Exception("Ошибка десериализации.", exp);
            }
        }
    }
}
