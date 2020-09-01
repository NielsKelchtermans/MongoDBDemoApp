using DnsClient.Protocol;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database ophalen en starten er mee te werken of niewe database opzetten
            MongoCRUD db = new MongoCRUD("Addressbook");

            //============Insert van een PersonModel in Users
            //PersonModel person = new PersonModel
            //{
            //    FirstName = "Jpe",
            //    LastName = "Smith",
            //    PrimaryAddress = new AddressModel
            //    {
            //        StreetAddress = "101 Oak Street",
            //        City = "Scranton",
            //        State = "PA",
            //        ZipCode = "18512"
            //    }
            //};
            //db.InsertRecord("Users", person);

            //================ "Select All" van Users; Opgelet<PersonModel>
            // var recs = db.LoadRecords<PersonModel>("Users");
            //foreach (var rec in recs)
            //{
            //    Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");
            //    if (rec.PrimaryAddress != null)
            //    {
            //        Console.WriteLine(rec.PrimaryAddress.City);
            //    }
            //}
            //var oneRec = db.LoadRecordById<PersonModel>("Users", new Guid("d435c856-341b-438d-9c1b-b8f29f42e4d2"));
            //datum toevoegen aan oneRec
            //oneRec.DateOfBirth = new DateTime(1982, 10, 20, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRec.Id, oneRec);
            //db.DeleteRecords<PersonModel>("Users", oneRec.Id);

            //
            //================ "Select All" van Users maar nu via de andere class; Opgelet<NameModel>
            var recs = db.LoadRecords<NameModel>("Users");
            foreach (var rec in recs)
            {
                Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");
                
            }


            Console.ReadLine();
        }
    }

}
