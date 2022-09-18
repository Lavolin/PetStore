namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PetStore.Data.Common.Repositories;
    using PetStore.Data.Models;

    public class ProductService : IProductService
    {
        private const string EmptyString = "";

        private readonly IDeletableEntityRepository<Product> productRepo;

        public ProductService(IDeletableEntityRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public IQueryable<Product> GetAllByName(string nameSearch = EmptyString)
        {
            if (nameSearch != null)
            {
                return this.productRepo
                    .All()
                    .Where(p => p.Name.ToLower().Contains(nameSearch.ToLower()));
            }

            return this.productRepo.All();
        }

        public IQueryable<Product> GetAllByCategory(string categoryName = EmptyString)
        {
            if (categoryName != EmptyString)
            {
                return this.productRepo
                    .All()
                    .Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()));
            }

            return this.productRepo.All();
        }

        public async Task<Product> GetById(string id)
            => await this.productRepo.All().FirstOrDefaultAsync(p => p.Id == id);

        public ICollection<string> GetAllProductsCategories()
        {
            return this.productRepo
                .AllAsNoTracking()
                .Select(p => p.Category.Name)
                .ToArray();
        }

        public async Task AddProduct(Product product)
        {
            await this.productRepo.AddAsync(product);
            await this.productRepo.SaveChangesAsync();
        }
    }
}
