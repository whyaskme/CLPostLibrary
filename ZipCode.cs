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

namespace CLPostLibrary
{
    public class ZipCode
    {
        public ZipCode()
        {
            _id = ObjectId.GenerateNewId();
            _t = "ZipCode";

            Zip = "";

            StateId = ObjectId.Empty;
            StateName = "";

            County = "";

            CityId = ObjectId.Empty;
            CityName = "";

            Longitude = "";
            Latitude = "";

            AreaCodes = "";
            EstimatedPopulation = 0;
            TimeZone = "";
        }

        public ObjectId _id { get; set; }
        public string _t { get; set; }

        public string Zip { get; set; }

        public ObjectId StateId { get; set; }
        public string StateName { get; set; }

        public string County { get; set; }

        public ObjectId CityId { get; set; }
        public string CityName { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        
        public string AreaCodes { get; set; }
        public Int32 EstimatedPopulation { get; set; }
        public string TimeZone { get; set; }
    }
}
