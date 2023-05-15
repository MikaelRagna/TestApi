using API_LastProjetct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace PrototipoProjetoFinal.Data
{
    public class PesquisaService
    {
        private readonly IMongoCollection<Pesquisa> _collection;

        public PesquisaService(IOptions<PesquisaDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var db = mongoClient.GetDatabase(options.Value.Database);

            _collection = db.GetCollection<Pesquisa>
                (options.Value.PesquisaCollection);
        }

        public async Task<List<Pesquisa>> GetAllPesquisaAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<Pesquisa> GetPesquisaByIdAsync(string id)
        {
            var pesq = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

                if(pesq == null)
                {
                    return null;
                }
            return pesq;
        }

        public async Task<List<Response>> GetResponseByStoreIdAsync(int idStore)
        {
            var filter = Builders<Pesquisa>.Filter.ElemMatch(x => x.Responses, y => y.StoreId == idStore);
            var result = await _collection.Find(filter).ToListAsync();

            if (result == null) return null;

            var respostas = new List<Response>();

            foreach (var response in result)
            {
                respostas.AddRange(response.Responses.Where(x => x.StoreId == idStore));
            }

            return respostas;
        }

        public async Task<List<Pesquisa>> GetPesquisasByStoreIdAsync(int id)
        {
            var filter = Builders<Pesquisa>.Filter.Where(x => x.StoresId.Contains(id));
            var result = await _collection.Find(filter).ToListAsync();

            if (result == null) return null;

            return result;
        }

        public async Task<bool> AddPesquisaAsync(Pesquisa pesquisa)
        {
            await _collection.InsertOneAsync(pesquisa);

            return true;
        }

        public async Task<bool> AddResponseAsync(string id, List<Response> resposts)
        {
            var filter = Builders<Pesquisa>.Filter.Eq(x => x.Id, id);

            foreach (var res in resposts)
            {
                var pesquisa = Builders<Pesquisa>.Update.AddToSet(x => x.Responses, res);
                var result = await _collection.UpdateOneAsync(filter, pesquisa);
                if (result.MatchedCount == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
