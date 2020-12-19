using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CLPostLibrary
{
    public class User : Base
    {
        public User()
        {
            _id = ObjectId.GenerateNewId();
            _t = "User";

            Created = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            Modified = Created;

            Enabled = true;

            UserId = _id;
            SiteUserId = 0;
            FirstName = "Update your first name";
            LastName = "Update your last name";
            Email = "Update your email address";

            Transactions = new List<Transaction>();
        }

        public ObjectId _id { get; set; }

        public string _t { get; set; }

        public ObjectId UserId { get; set; }
        public Int32 SiteUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Created { get; set; }
        public string Modified { get; set; }

        public bool Enabled { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}