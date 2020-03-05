using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://test:lol123@cluster0-uf94w.mongodb.net/test?retryWrites=true&w=majority");
            var dbList = dbClient.ListDatabases().ToList();

            IMongoDatabase db = dbClient.GetDatabase("test");
            var collList = db.ListCollections().ToList();
            Console.WriteLine("The list of collections are :");
            foreach (var item in collList)
            {
                Console.WriteLine(item);
            }
            var things = db.GetCollection<BsonDocument>("arbitrade");

            var resultDoc = things.Find(new BsonDocument()).ToList().ToJson();

            foreach (var item in resultDoc)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public void escreverJsonArquivo(string resultDoc) {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\shiga\Desktop\bsonjson\BSON.txt"))
            {
                file.WriteLine(resultDoc);
            }
        }

    }



    public class MongoModel {
        
    }
}
