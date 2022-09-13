namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public ICollection<Product> GetAllByName(string nameSearch = EmptyString)
        {
            if (nameSearch != EmptyString)
            {
                return this.productRepo
                    .All()
                    .Where(p => p.Name.ToLower().Contains(nameSearch.ToLower()))
                    .ToArray();
            }

            return this.productRepo.All().ToArray();
        }

        public ICollection<Product> GetAllByCategory(string categoryName = EmptyString)
        {
            if (categoryName != EmptyString)
            {
                return this.productRepo
                    .All()
                    .Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()))
                    .ToArray();
            }

            return this.productRepo.All().ToArray();
        }


        public Product GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
