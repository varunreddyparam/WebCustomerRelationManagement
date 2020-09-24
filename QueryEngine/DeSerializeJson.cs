using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QueryEngine
{
    public static class DeSerializeJson
    {
        public static QueryEngine.Query GetDeserializedJson(string jsonQuery)
        {
            return JsonConvert.DeserializeObject<QueryEngine.Query>(jsonQuery);
        }

        public static string GetParentLogicalName(Query query)
        {
            return query.Entity.Name;
        }

        public static List<string> CreateSelectQuery(Query query)
        {
            return query.Entity.Attribute.Select(i => i.Name).ToList();
        }

        public static List<FilterElement> FilterQuery(Query query)
        {
            return query.Entity.Filter;
        }

        public static List<LinkEntityElement> LinkEntity(Query query)
        {
            return query.Entity.LinkEntity;
        }

        public static void DecodeLink(LinkEntityElement linkEntityElements)
        {
            LinkEntityElement ContainerLinkElement = new LinkEntityElement();
            linkEntityElements.Attribute.ToList();
        }

        /// Should be used in concrete

        //public async Task<string> RetrieveMultipleRequest(Query query, AzureTableStorage azureTableStorage)
        //{
        //    TableQuery<AddressEntity> addressTableQuery = new TableQuery<AddressEntity>();
        //    addressTableQuery.SelectColumns = DeSerializeJson.CreateSelectQuery(query);
        //    string filterQuery = null;
        //    foreach (FilterElement filterElement in DeSerializeJson.FilterQuery(query))
        //    {
        //        if (filterElement.FilterValue.Length > 0)
        //        {
        //            foreach (var value in filterElement.FilterValue)
        //            {
        //                filterQuery = string.Concat("{0} {1} {2}", filterQuery, GenerateFilterCondition(value, filterElement), filterElement.FilterType);
        //            }
        //        }
        //    }
        //    addressTableQuery.Where(filterQuery);

        //    return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(query.Entity.Name, addressTableQuery));

        //}

        //public string GenerateFilterCondition(object value, FilterElement filterElement)
        //{

        //    switch (Type.GetTypeCode(value.GetType()))
        //    {
        //        case TypeCode.Int32:
        //            return TableQuery.GenerateFilterConditionForInt(filterElement.Attribute, filterElement.Operator, Convert.ToInt32(value));
        //        case TypeCode.Double:
        //            return TableQuery.GenerateFilterConditionForDouble(filterElement.Attribute, filterElement.Operator, Convert.ToDouble(value));
        //        case TypeCode.Boolean:
        //            return TableQuery.GenerateFilterConditionForBool(filterElement.Attribute, filterElement.Operator, Convert.ToBoolean(value));
        //        case TypeCode.DateTime:
        //            return TableQuery.GenerateFilterConditionForDate(filterElement.Attribute, filterElement.Operator, Convert.ToDateTime(value));
        //        case TypeCode.String:
        //            return TableQuery.GenerateFilterCondition(filterElement.Attribute, filterElement.Operator, Convert.ToString(value));
        //        default:
        //            return string.Empty;
        //    }

        //    return string.Empty;
        //}
    }
}
