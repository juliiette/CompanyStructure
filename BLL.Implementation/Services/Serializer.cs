using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;

namespace BLL.Implementation.Services
{
    public class Serializer
    {
        public static void Serialize(string path, ClientService client)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClientService));
            MemoryStream stream = new MemoryStream();

            serializer.WriteObject(stream, client);
            stream.Position = 0;
            
            StreamReader streamReader = new StreamReader(stream);
            string json = streamReader.ReadToEnd();
            
            streamReader.Close();
            stream.Close();
        }

        public static ClientService Deserialize(string path)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ClientService));
            MemoryStream memoryStream = new MemoryStream();
            
            memoryStream.Position = 0;

            ClientService client = (ClientService) serializer.ReadObject(memoryStream);
            
            return client;
        }
    }
}