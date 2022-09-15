namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PetStore.Data.Models;

    public interface IProductService
    {
       Task<ICollection<Product>> GetAllByName(string nameSearch = "");

       Task<ICollection<Product>> GetAllByCategory(string categoryName = "");

       Task<Product> GetById(string id);
    }
}
