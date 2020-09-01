using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    public class MongoCRUD
    {
        //=============connection to database==============
        //
        private IMongoDatabase db;

        //ctor met database naam in
        public MongoCRUD(string database)
        {
            //nieuwe client die MongoDB gebruikt wordt toegevoegd
            //MongoClient()= connectionString is leeg dus standaard localhost
            var client = new MongoClient();
            //de db wordt via een object van MongoClient 'Client' 
            db = client.GetDatabase(database);
        }

        //methods
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
        //select* voor MongoDb
        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
        //1 record
        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }
        //upsert
        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            //create the filter
            var filter = Builders<T>.Filter.Eq("Id", id);
            //replace the record via an upset
            //upsert is an update if the filter finds something or and insert if it finds nothing
            collection.ReplaceOne(filter, record, new ReplaceOptions { IsUpsert = true });

        }

        //delete
        public void DeleteRecords<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
        

    }

}
