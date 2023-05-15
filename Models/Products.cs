using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_LastProjetct.Models;

public class Products
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("ProductName")]
    public string Name { get; set; }

    [BsonElement("NormalPrice")]
    public double NormalPrice { get; set; }

    [BsonElement("PromoPrice")]
    public double PromoPrice { get; set; }

    [BsonElement("PayAndTakePrice")]
    public double PayAndTakePrice { get; set; }
}
