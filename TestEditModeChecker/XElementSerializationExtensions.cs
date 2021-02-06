using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace TestEditModeChecker
{
	/// <summary>
	/// https://stackoverflow.com/questions/8373552/serialize-an-object-to-xelement-and-deserialize-it-in-memory
	/// </summary>
	public static class XElementSerializationExtensions
	{
		public static XElement ToXElement<T>(this object obj)
		{
			using MemoryStream memoryStream = new();
			
			using TextWriter streamWriter = new StreamWriter(memoryStream);

			XmlSerializer xmlSerializer = new(typeof(T));

			xmlSerializer.Serialize(streamWriter, obj);

			return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
		}

		public static T FromXElement<T>(this XElement xElement)
		{
			XmlSerializer xmlSerializer = new(typeof(T));

			return (T) xmlSerializer.Deserialize(xElement.CreateReader());
		}
	}
}