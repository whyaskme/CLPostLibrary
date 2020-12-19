using System;
using System.Configuration;
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
    public class Transaction
    {
        public Transaction(int count)
        {
            string popLabel;

            _id = ObjectId.GenerateNewId();

            Date = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

            if (count > 0)
                Type = "Credit";
            else
                Type = "Debit";

            if (count < -1)
                popLabel = "TimePops";
            else if (count > 1)
                popLabel = "TimePops";
            else
                popLabel = "TimePop";

            Count = count;

            Price = Convert.ToDecimal(ConfigurationManager.AppSettings["TimePopPrice"]);
            Total = (Count * Price);

            Notes = "Account (" + Type + "ed) " + count.ToString(CultureInfo.InvariantCulture).Replace("-", "") + " " + popLabel + ": $" + Total + ".";

            //myUser.PopsAvailable += Count;
            //myUser.CashBalance += Total;
        }

        public ObjectId _id { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
    }
}