using System.Text.Json.Serialization;

namespace PersonnelAccountingServer.Classes.Personal
{
    public class Person : GeneralInformation
    {
        [JsonPropertyName("Function")]
        public string Function { 
            get
            {
                return function;
            }
            set
            {
                function = value;
                DeleteExcessInformation(value);
            } 
        }


        private void DeleteExcessInformation(string NameFunction)
        {
            if(NameFunction != "Директор")
            {
                UniqueDirector = null;
            }
            if (NameFunction != "Руководитель подразделения")
            {
                UniqueLeader = null;
            }
            if (NameFunction != "Контролер")
            {
                UniqueControler = null;
            }
            if (NameFunction != "Рабочий")
            {
                UniqueWorker = null;
            }
        }
    }
}
