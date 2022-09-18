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
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ICollection<ListCategoriesOnProductCreateViewModel> allCategories =
                this.categoryService.All().To<ListCategoriesOnProductCreateViewModel>().ToArray();

            return this.View(allCategories);
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable<Product> allProducts = this.productService.GetAllByName(search);

            ICollection<string> categories = this.productService.GetAllProductsCategories();

            AllProductsViewModel viewModel = new AllProductsViewModel()
            {
                AllProducts = allProducts.To<ListAllProductViewModel>().ToArray(),
                Categories = categories,
                SearchQuery = search,
            };

            return this.View(viewModel);
        }
    }
}
