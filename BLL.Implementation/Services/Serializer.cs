using System.IO;
using System.Text.Json;
using BLL.Models;

namespace BLL.Implementation.Services
{
    public class Serializer
    {
        public static void Serialize(DirectorModel director)
        {
            string jsonString;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            }; 
            
            jsonString = JsonSerializer.Serialize<DirectorModel>(director, options);
            File.WriteAllText("Company.json", jsonString); 
            

        }
 
        public static DirectorModel Deserialize(string path)
        {
            DirectorModel director;

            string jsonString = File.ReadAllText(path);
            director = JsonSerializer.Deserialize<DirectorModel>(jsonString);

            return director;
        } 
    }
}