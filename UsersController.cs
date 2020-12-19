using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

//using System.Web.Script.Serialization;

using Newtonsoft.Json.Linq;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CLPostLibrary
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public User Get()
        {
            var newUser = new User();

            #region New user registration credits



            #endregion

            CreateDbConnection();

            _mongoCollection.Insert(newUser);

            return newUser;
        }


        //public IEnumerable<User> Get()
        //{
        //    var emptyUser = new User();

        //    return emptyUser;

        //    //return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private MongoClient _mongoClient;
        private MongoServer _mongoServer;
        private MongoDatabase _mongoDatabase;
        private MongoCollection _mongoCollection;

        private void CreateDbConnection()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["MongoServer"].ConnectionString;

            var mongoClientSettings = new MongoClientSettings();

            var dbConnectionSettings = dbConnectionString.Split('@');

            // Server credentials
            var dbCredentials = dbConnectionSettings[0].Split(':');
            var dbUserName = dbCredentials[1].Replace("//", "");
            var dbPassword = dbCredentials[2];

            // Server settings
            var dbServerPort = dbConnectionSettings[1].Split(':');
            var dbServer = dbServerPort[0];
            var dbPort = dbServerPort[1];

            mongoClientSettings.Credentials = new[] { MongoCredential.CreateMongoCRCredential(ConfigurationManager.AppSettings["MongoDbName"], dbUserName, dbPassword) };
            mongoClientSettings.Server = new MongoServerAddress(dbServer, Convert.ToInt32(dbPort));

            _mongoClient = new MongoClient(mongoClientSettings);

            // ReSharper disable once CSharpWarnings::CS0618
            _mongoServer = _mongoClient.GetServer();

            _mongoDatabase = _mongoServer.GetDatabase(ConfigurationManager.AppSettings["MongoDbName"]);

            _mongoCollection = _mongoDatabase.GetCollection(ConfigurationManager.AppSettings["MongoDbCollection"]);
        }
    }
}