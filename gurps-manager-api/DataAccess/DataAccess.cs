using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace gurps_manager_library.DataAccess
{
    public abstract class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        string collectionName;
        string idCampName;

        public DataAccess(string collection,string idName)
        {
            _client = new MongoClient("mongodb://localhost:27017");
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            _server = _client.GetServer();
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            _db = _server.GetDatabase("GURPS");
            collectionName = collection;
            idCampName = idName;
        }

        public void InsertOne<T>(T obj)
        {
            _db.GetCollection(collectionName).Insert(obj.ToBsonDocument());
        }

        public void InsertMany<T>(List<T> objs)
        {
            foreach (var obj in objs)
            {
                InsertOne(obj);
            }
        }

        public string Find(int id)
        {
            return _db.GetCollection(collectionName).FindOne(Query.EQ(idCampName, id)).ToJson();
        }

        public void Delete(int id)
        {
            _db.GetCollection(collectionName).Remove(Query.EQ(idCampName, id));
        }

        public string ReturnAllData<T>()
        {
            return JsonConvert.SerializeObject(_db.GetCollection<T>(collectionName).FindAll());
        }

        public void DeleteAll<T>()
        {
            _db.GetCollection<T>(collectionName).RemoveAll();
        }
    }
}
