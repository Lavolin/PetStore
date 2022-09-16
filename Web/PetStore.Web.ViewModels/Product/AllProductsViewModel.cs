namespace PetStore.Web.ViewModels.Product
{
    using System.Collections;
    using System.Collections.Generic;

    public class AllProductsViewModel
    {
        public ICollection<ListAllProductViewModel> AllProducts { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}
