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
    public class Event : Base
    {
        public Event()
        {
            _t = "Event";
            TypeId = 0;
            TypeName = "";

            Date = "";
            
            Details = "Event details";
            Server = "";
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public string Date { get; set; }
        
        public string Details { get; set; }
        public string Server { get; set; }

        public void Save()
        {
            var myUtils = new Utils();

            myUtils.SaveEvent(this);
        }
    }
}