using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo
{
    public class PersonModel
    {
        //geef aan Mongo zelf de id mee
        [BsonId]  //_id in storage maar we gaan er een eigen naam aan geven. Als Id niet gegeven wordt, maakt die zelf aan(verschil tussen insert en update!null)
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
        //in database wordt het dob, mapping
        [BsonElement("dob")]
        public DateTime DateOfBirth { get; set; }
    }

}
