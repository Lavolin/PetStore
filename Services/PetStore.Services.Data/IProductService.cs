namespace PetStore.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PetStore.Data.Models;

    public interface IProductService
    {
        ICollection<Product> GetAllByName(string nameSearch);

        ICollection<Product> GetAllByCategory(string categoryName);

        Product GetById(string id);
    }
}
