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
        public bool Distinct { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }
    }

    public partial class Entity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attribute")]
        public List<Attribute> Attribute { get; set; }

        [JsonProperty("order")]
        public List<Order> Order { get; set; }

        [JsonProperty("filter")]
        public List<FilterElement> Filter { get; set; }

        [JsonProperty("link-entity")]
        public List<LinkEntityElement> LinkEntity { get; set; }
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
        public object[] FilterValue { get; set; }

        [JsonProperty("filtertype", NullValueHandling = NullValueHandling.Ignore)]
        public string FilterType { get; set; }
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
        public bool? Visible { get; set; }

        [JsonProperty("attribute", NullValueHandling = NullValueHandling.Ignore)]
        public List<Attribute> Attribute { get; set; }
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
        public bool Descending { get; set; }
    }
    //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to
}
