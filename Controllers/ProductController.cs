public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var products = _service.GetAll();
        return View(products);
    }

    public IActionResult Detail(string id)
    {
        var product = _service.GetById(id);
        return View(product);
    }
}
