namespace PetStore.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PetStore.Data.Models;
    using PetStore.Services.Data;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string search)
        {
            ICollection<Product> allProducts = await this.productService.GetAllByName();

            return this.View(allProducts);
        }
    }
}
