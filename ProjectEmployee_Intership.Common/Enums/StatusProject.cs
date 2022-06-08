using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusProject
    {
        Active,
        InActive
    }
}
