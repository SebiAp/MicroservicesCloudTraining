using Centric.eCommerce.Product.API.Models;

namespace Centric.eCommerce.Product.API.Profiles
{
    public class ProductProfile: AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<DB.Product, ProductModel>().ReverseMap();
        }
    }
}
