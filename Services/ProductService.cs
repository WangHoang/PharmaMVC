public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(MongoDbContext context)
    {
        _products = context.Products;
    }

    public List<Product> GetAll() =>
        _products.Find(_ => true).ToList();

    public Product GetById(string id) =>
        _products.Find(p => p.Id == id).FirstOrDefault();

    public void Create(Product product) =>
        _products.InsertOne(product);
}
