using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QueryEngine
{
    public partial class Query
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("output-format")]
        public string OutputFormat { get; set; }

        [JsonProperty("mapping")]
        public string Mapping { get; set; }

        [JsonProperty("distinct")]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public bool Distinct { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }
    }

    public partial class Entity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attribute")]
        public Attribute[] Attribute { get; set; }

        [JsonProperty("order")]
        public Order[] Order { get; set; }

        [JsonProperty("filter")]
        public FilterElement[] Filter { get; set; }

        [JsonProperty("link-entity")]
        public LinkEntityElement[] LinkEntity { get; set; }
    }

    public partial class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public partial class FilterElement
    {
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] FilterValue { get; set; }
    }

    public partial class LinkEntityElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("link-type")]
        public string LinkType { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public LinkEntityFilter Filter { get; set; }

        [JsonProperty("link-entity", NullValueHandling = NullValueHandling.Ignore)]
        public LinkEntityElement LinkEntity { get; set; }

        [JsonProperty("visible", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public bool? Visible { get; set; }

        [JsonProperty("attribute", NullValueHandling = NullValueHandling.Ignore)]
        public Attribute[] Attribute { get; set; }
    }
    public partial class LinkEntityFilter
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("condition")]
        public FilterElement Condition { get; set; }
    }

    public partial class Order
    {
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("descending")]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public bool Descending { get; set; }
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = FluffyParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = FluffyParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class FluffyParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly FluffyParseStringConverter Singleton = new FluffyParseStringConverter();
    }

    public partial class Query
    {
        public static Query FromJson(string json) => JsonConvert.DeserializeObject<Query>(json, QueryEngine.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PurpleParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            TypeCode value = Type.GetTypeCode(untypedValue.GetType());
            switch (value)
            {
                case TypeCode.Boolean:
                    var boolString = (Boolean)untypedValue ? "true" : "false";
                    serializer.Serialize(writer, boolString);
                    return;
                case TypeCode.Int32:
                    return;
                case TypeCode.Int64:
                    return;
                case TypeCode.Int16:
                    return;
                case TypeCode.String:
                    return;
                case TypeCode.Char:
                    return;
                case TypeCode.Byte:
                    return;
                case TypeCode.Decimal:
                    return;
                case TypeCode.Double:
                    return;
                case TypeCode.DateTime:
                    return;
                case TypeCode.Empty:
                    return;
                case TypeCode.SByte:
                    return;
            }
        }

        public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
    }

    //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to
}
