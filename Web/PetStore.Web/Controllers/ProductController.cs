namespace PetStore.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using PetStore.Data.Models;
    using PetStore.Services.Data;
    using PetStore.Services.Mapping;
    using PetStore.Web.ViewModels.Product;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult  All(string search)
        {
            IQueryable<Product> allProducts = this.productService.GetAllByName();

            ICollection<string> categories = this.productService.GetAllProductsCategories();

            AllProductsViewModel viewModel = new AllProductsViewModel()
            {
                AllProducts = allProducts.To<ListAllProductViewModel>().ToArray(),
                Categories = categories,
            };

            return this.View(viewModel);
        }
    }
}
