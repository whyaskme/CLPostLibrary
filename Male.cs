﻿using System.Diagnostics;
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
    public class Male
    {
        public Male()
        {
            _id = ObjectId.GenerateNewId();
            _t = "Male";
            Name = "";
        }

        public ObjectId _id { get; set; }
        public string _t { get; set; }
        public string Name { get; set; }
    }
}
