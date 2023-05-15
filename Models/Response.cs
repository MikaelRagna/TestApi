using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_LastProjetct.Models;

public class Response
{
    public string Id => ObjectId.GenerateNewId().ToString();

    [BsonElement("ProductName")]
    public string ProductName { get; set; }

    [BsonElement("StoreId")]
    public int StoreId { get; set; }

    [BsonElement("ProductId")]
    public string ProductId { get; set; }

    [BsonElement("RegularPrice")]
    public double RegularPrice { get; set; }

    [BsonElement("PromoPrice")]
    public double PromoPrice { get; set; }

    [BsonElement("PayAndTakePrice")]
    public double PayAndTakePrice { get; set; }
}
