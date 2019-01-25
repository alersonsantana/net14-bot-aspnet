using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot
{
    public class ArmazenaChat
    {

        public void armazenaMensagem(string mensagem)
        {
            string url = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(url);

            var db = client.GetDatabase("BOT");            var col = db.GetCollection<BsonDocument>("mensagens");

            BsonDocument doc = new BsonDocument()
            {
                { "campo1", 1 },
                { "mensagem", mensagem },
            };
            col.InsertOne(doc);
            
        }

    }
}