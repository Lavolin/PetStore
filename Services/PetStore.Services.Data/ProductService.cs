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

        public async Task<ICollection<Product>> GetAllByName(string nameSearch = EmptyString)
        {
            if (nameSearch != EmptyString)
            {
                return await this.productRepo
                    .All()
                    .Where(p => p.Name.ToLower().Contains(nameSearch.ToLower()))
                    .ToArrayAsync();
            }

            return await this.productRepo.All().ToArrayAsync();
        }

        public async Task<ICollection<Product>> GetAllByCategory(string categoryName = EmptyString)
        {
            if (categoryName != EmptyString)
            {
                return await this.productRepo
                    .All()
                    .Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()))
                    .ToArrayAsync();
            }

            return await this.productRepo.All().ToArrayAsync();
        }

        public async Task<Product> GetById(string id)
            => await this.productRepo.All().FirstOrDefaultAsync(p => p.Id == id);
    }
}
