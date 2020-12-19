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
    public class City : Base
    {
        public City()
        {
            _t = "City";

            Name = "";
            StateId = ObjectId.Empty;
            StateName = "";
        }

        public string Name { get; set; }
        public ObjectId StateId { get; set; }
        public string StateName { get; set; }
    }
}
