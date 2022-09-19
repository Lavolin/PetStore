namespace PetStore.Web.ViewModels.Product
{
    using PetStore.Data.Models;
    using PetStore.Services.Mapping;

    public class ListAllProductViewModel : IMapFrom<Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
