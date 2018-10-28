using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;


public static class Helper {
	// serialize

	public static string Serialize<T>(this T toSerialize)
	{
		XmlSerializer xml= new XmlSerializer (typeof(T));
		StringWriter writer = new StringWriter ();
		xml.Serialize (writer,toSerialize);
		return writer.ToString ();
	}

	public static T Deserialize (this string toDeserialize){
		XmlSerializer xml= new XmlSerializer (typeof(T));
		StringReader writer = new StringReader (toDeserialize);
		return (T)xml.Deserialize (reader);
	}
}
