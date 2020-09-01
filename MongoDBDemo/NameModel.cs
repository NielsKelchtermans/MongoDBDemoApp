using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo
{
    //andere class
    [BsonIgnoreExtraElements]
    public class NameModel
    {
        //geef aan Mongo zelf de id mee
        [BsonId]  //_id in storage maar we gaan er een eigen naam aan geven. Als Id niet gegeven wordt, maakt die zelf aan(verschil tussen insert en update!null)
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
