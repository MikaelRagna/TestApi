using API_LastProject.Models.DTOS;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_LastProjetct.Models;

public class Pesquisa
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("ProdutcsList")]
    public List<ProductDTO> ProdutcsList { get; set; }

    [BsonElement("StoresID")]
    public int[] StoresId { get; set; }

    [BsonElement("Category")]
    public string Category { get; set; }

    [BsonElement("StartDate")]
    public DateTime StartDate { get; set; }

    [BsonElement("DueDate")]
    public DateTime DueDate { get; set; }

    [BsonElement("ResponseList")]
    public List<Response> Responses { get; set; }
}
