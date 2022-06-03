using System.Text.Json.Serialization;
using PersonnelAccountingServer.Classes.Personal;

namespace PersonnelAccountingServer.Classes.Response
{
    public class Jpersons
    {
        [JsonPropertyName("Persons")]
        public List<Person>? Persons { get; set; }
    }
}
