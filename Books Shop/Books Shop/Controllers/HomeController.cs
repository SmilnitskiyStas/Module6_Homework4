using Books_Shop.Entities;
using Books_Shop.Filters;
using Books_Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Books_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productProvider;

        public HomeController(IProductService productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult AllProduct()
        {
            var products = _productProvider.GetAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct() => View();

        [MyCustomExceptionFilter]
        [HttpPost]
        public IActionResult CreateProduct(Product product, string price)
        {
            // Для відтворення помилки.
            throw new Exception();

            Product fullProduct = CreateFullProduct(product, price);

            string? message = null;

            if (ModelState.IsValid)
            {
                _productProvider.Create(fullProduct);

                ViewBag.Message = message;

                return View();
            }

            foreach (var item in ModelState)
            {
                // Якщо для визначеного елементу є помилка.
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    message = $"{message}\nПомилка для властивості: {item.Key}:\n";

                    // Проходимося по всім помилкам.
                    foreach (var error in item.Value.Errors)
                    {
                        message = $"{message} {error.ErrorMessage}\n";
                    }
                }
            }

            ViewBag.Message = message;

            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {

            var product = _productProvider.GetById(id);

            ViewBag.ProductId = product.Id;
            ViewBag.ProductTitle = product.Title;
            ViewBag.ProductAuthor = product.Author;
            ViewBag.ProductDateOfCreate = product.DateOfCreate;
            ViewBag.ProductPrice = product.Price;

            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(Product product, string price)
        {
            throw new Exception();

            Product fullProduct = CreateFullProduct(product, price);

            _productProvider.Update(fullProduct);

            return View();
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            _productProvider.DeleteById(id);

            ViewBag.Message = "Product is delete!";

            return View();
        }

        private Product CreateFullProduct(Product product, string price)
        {
            if (price == null)
            {
                return product;
            }

            decimal convertPrice = Convert.ToDecimal(price.Replace(".", ","));

            product.Price = convertPrice;

            return product;
        }
    }
}
