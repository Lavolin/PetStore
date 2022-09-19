namespace PetStore.Web.ViewModels.Product
{
    using AutoMapper;
    using PetStore.Data.Models;

    using PetStore.Services.Mapping;

    public class DetailsProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public int CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, DetailsProductViewModel>()
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Category.Name));
        }
    }
}
