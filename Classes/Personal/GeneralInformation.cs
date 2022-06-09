using System.Text.Json.Serialization;

namespace PersonnelAccountingServer.Classes.Personal
{
    public class GeneralInformation
    {
        // Обязательные
        [JsonPropertyName("Id")]
        public long Id { get; set; } = 1;

        protected string function = "Рабочий";

        [JsonPropertyName("LastName")]
        public string LastName { get; set; } = "Иванов";

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; } = "Иван";

        [JsonPropertyName("ThirdName")]
        public string ThirdName { get; set; } = "Иванович";

        [JsonPropertyName("DateOfBirth")]
        public string DateOfBirth { get; set; } = "01.01.1900";

        [JsonPropertyName("Gender")]
        public string Gender { get; set; } = "Мужской";

        // Необязательные

        // Директор
        [JsonPropertyName("UniqueDirector")]
        public string? UniqueDirector { get; set; }

        // Руководитель подразделения
        [JsonPropertyName("UniqueLeader")]
        public string? UniqueLeader { get; set; }

        // Контролер
        [JsonPropertyName("UniqueControler")]
        public string? UniqueControler { get; set; }

        // Рабочий
        [JsonPropertyName("UniqueWorker")]
        public string? UniqueWorker { get; set; }
    }
}
