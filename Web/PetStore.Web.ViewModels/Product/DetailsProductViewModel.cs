namespace PetStore.Web.ViewModels.Product
{
    using PetStore.Data.Models;

    using PetStore.Services.Mapping;

    public class DetailsProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public int CategoryName { get; set; }
    }
}
