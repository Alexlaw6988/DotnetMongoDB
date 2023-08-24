﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotnetMongoDB.Models
{
    [BsonNoId]
    [BsonIgnoreExtraElements]
    public class Book
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string BookId { get; set; }

        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("name")]
        public string BookName { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
    }
}
