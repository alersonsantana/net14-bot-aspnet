using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Logic;

namespace SimpleBot
{
    public class ArmazenaChat
    {

        public void armazenaMensagem(object msg)
        {
            var mensagem =(SimpleMessage)msg;
            
            string url = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(url);
            var db = client.GetDatabase("BOT");            var col = db.GetCollection<BsonDocument>("mensagens");
            var profile = db.GetCollection<BsonDocument>("profile");



            BsonDocument doc = new BsonDocument()
            {               
                { "userFromName", mensagem.User },
                { "id", mensagem.Id },
                { "mensagem", mensagem.Text },
            };
            col.InsertOne(doc);           
        }


    }
}