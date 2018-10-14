using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;

namespace gurps_manager_library.DataAccess
{
    public abstract class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        string collectionName;
        string idCampName="_id";

        public DataAccess(string collection)
        {
            _client = new MongoClient("mongodb://localhost:27017");
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            _server = _client.GetServer();
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            _db = _server.GetDatabase("GURPS");
            collectionName = collection;
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

        public T FindOne<T>(int id)
        {
            return _db.GetCollection(collectionName).FindOneAs<T>(Query.EQ(idCampName, id));
        }

        public T FindByName<T>(string name)
        {
            return _db.GetCollection(collectionName).FindOneAs<T>(Query.EQ("Name", name));
        }

        public List<T> FindAll<T>()
        {
            return _db.GetCollection<T>(collectionName).FindAll().ToList();
        }

        public void Delete(int id)
        {
            _db.GetCollection(collectionName).Remove(Query.EQ(idCampName, id));
        }

        public void DeleteAll<T>()
        {
            _db.GetCollection<T>(collectionName).RemoveAll();
        }
    }
}
