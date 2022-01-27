using Centric.eCommerce.Customer.API.Models;

namespace Centric.eCommerce.Customer.API.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<DB.Customer, CustomerModel>().ReverseMap();
        }
    }
}
