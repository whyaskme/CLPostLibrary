using System;
using System.Collections;
using System.Collections.Generic;
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
    public class State : Base
    {
        public State()
        {
            _t = "State";
            Name = "";
            Abbr = "";

            Markets = new List<Market>();
        }

        public string Name { get; set; }
        public string Abbr { get; set;}

        public List<Market> Markets { get; set; }
    }
}
