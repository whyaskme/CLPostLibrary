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
    public class Name : Base
    {
        public Name()
        {
            //_t = "";
            Value = "";
            Gender = 0;
        }

        //public string _t { get; set; }
        public string Value { get; set; }
        public int Gender { get; set; }
    }
}
