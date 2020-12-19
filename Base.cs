using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using Newtonsoft.Json;

namespace CLPostLibrary
{
    public class Base
    {
        public Base()
        {
            _id = ObjectId.GenerateNewId();
            _t = "";

            DateCreated = DateTime.UtcNow;

            ReferenceId = ObjectId.Empty;
        }

        #region Properties

            public ObjectId _id { get; set; }
            public string _t { get; set; }

            public DateTime DateCreated { get; set; }

            public ObjectId ReferenceId { get; set; }

        #endregion
    }
}

public class ObjectIdConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var objectId = (ObjectId)existingValue; // at this point existingValue is {000...}
        return objectId;
    }

    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(ObjectId));
    }
}