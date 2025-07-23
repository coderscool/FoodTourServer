using Domain.Abstractions.Entities;
using Contracts.DataTransferObject;
using Domain.Entities.Validators;

namespace Domain.Entities
{
    public class OrderGroup : Entity<OrderGroupValidator>
    {
        public OrderGroup(string groupId, string restaurantId, Dto.DtoPerson restaurant, List<OrderItem> orderItem, string status)
        {
            Id = groupId;
            OrderItem = orderItem;
            RestaurantId = restaurantId;
            Restaurant = restaurant;
            Status = status;
        }

        public List<OrderItem> OrderItem { get; }
        public string RestaurantId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public string Status { get; private set; }
        
        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public static implicit operator OrderGroup(Dto.OrderGroup group)
            => new(group.GroupId, group.RestaurantId, group.Restaurant, group.OrderItem.Select(item => (OrderItem)item).ToList(), group.Status);

        public static implicit operator Dto.OrderGroup(OrderGroup group)
            => new(group.Id, group.RestaurantId, group.Restaurant, group.OrderItem.Select(item => (Dto.OrderItem)item).ToList(), group.Status);
    }
}
