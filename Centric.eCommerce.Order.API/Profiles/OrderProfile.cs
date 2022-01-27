using Centric.eCommerce.Order.API.Models;

namespace Centric.eCommerce.Order.API.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<DB.Order, OrderModel>();
            CreateMap<DB.OrderItem, OrderItemModel>();
        }
    }
}
