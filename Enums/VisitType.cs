using System.Text.Json.Serialization;

namespace PatientManagementSystem.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VisitType
    {       
        InPerson,
        Online
    
    }
}
