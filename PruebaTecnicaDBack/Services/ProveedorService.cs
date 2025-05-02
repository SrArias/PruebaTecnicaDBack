using MongoDB.Driver;
using PruebaTecnicaDBack.Models;

namespace PruebaTecnicaDBack.Services
{
    public class ProveedorService
    {
        private IMongoCollection<ProveedorModel> _proveedor;

        public ProveedorService(IMongoDbSettings settings)
        {
            var decryptedConnectionString = EncryptionHelper.Decrypt(settings.ConnectionString);

            var client = new MongoClient(decryptedConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _proveedor = database.GetCollection<ProveedorModel>(settings.CollectionName);
        }

        public List<ProveedorModel> Get()
        {
            return _proveedor.Find(proveedor => true).ToList();
        }

        public ProveedorModel Create(ProveedorModel proveedor)
        {
            _proveedor.InsertOne(proveedor);
            return proveedor;
        }

        public void Update(string id, ProveedorModel proveedor)
        {
            _proveedor.ReplaceOne(proveedor => proveedor.Id == id, proveedor);
        }

        public void Delete(string id)
        {
            _proveedor.DeleteOne(d => d.Id == id);
        }
    }
}
