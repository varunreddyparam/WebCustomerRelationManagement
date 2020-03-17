using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryEngine
{
    public static class SerializeJson
    {
        public static string ToJson(this Query self) => JsonConvert.SerializeObject(self, QueryEngine.Converter.Settings);
    }
}
