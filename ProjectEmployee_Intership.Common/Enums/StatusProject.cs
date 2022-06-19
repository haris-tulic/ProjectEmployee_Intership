using System.Text.Json.Serialization;

namespace ProjectEmployee_Intership.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusProject
    {
        Active,
        InActive
    }
}
