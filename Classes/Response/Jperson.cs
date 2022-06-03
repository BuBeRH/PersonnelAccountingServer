using System.Text.Json.Serialization;
using PersonnelAccountingServer.Classes.Personal;

namespace PersonnelAccountingServer.Classes.Response
{
    public class Jperson
    {
        [JsonPropertyName("Person")]
        public Person Person { get; set; } = new();
    }
}
