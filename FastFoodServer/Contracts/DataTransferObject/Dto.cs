using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObject
{
    public static class Dto
    {
        public record DtoPrice(string Cost, float Discount)
        {
            public static implicit operator Abstractions.Protobuf.Price(DtoPrice price)
                => new()
                {
                    Cost = price.Cost,
                    Discount = price.Discount
                };
        }
        public record DtoAddress(string Location, List<float> Center)
        {
            public static implicit operator Abstractions.Protobuf.Address(DtoAddress address)
                => new()
                {
                    Location = address.Location,
                    Center = { address.Center }
                };
        }
        public record DtoSearch(List<string> Nation, List<string> Category)
        {
            public static implicit operator Abstractions.Protobuf.Search(DtoSearch search)
                => new()
                {
                    Category = { search.Category },
                    Nation = { search.Nation },
                };
        }
        public record Rate(float Point);
        public record DtoPerson(string Name, string Image, string Address, string Phone)
        {
            public static implicit operator Abstractions.Protobuf.Person(DtoPerson person)
                => new()
                {
                    Name = person.Name,
                    Image = person.Image,
                    Address = person.Address,
                    Phone = person.Phone,
                };
        }

        public record DtoDish(string Name, string Image, string Description)
        {
            public static implicit operator Abstractions.Protobuf.Dish(DtoDish dish)
                => new()
                {
                    Name = dish.Name,
                    Image = dish.Image,
                    Description = dish.Description
                };
        }
        public record EvaluateAvg(float Quality, float Price, float Position, float Space, float Serve);
        public record CartItem(string ItemId, string RestaurantId, string DishId, DtoPerson Restaurant, DtoDish Dish, ushort Quantity, DtoPrice Price, ushort Time, string Note);
        public record OrderItem(string ItemId, string RestaurantId, string DishId, DtoPerson Restaurant, DtoDish Dish, ushort Quantity, string Note,
            DtoPrice Price, ushort Time, string Status)
        {
            public static implicit operator OrderItem(CartItem item)
                => new(ObjectId.GenerateNewId().ToString(),
                       item.RestaurantId,
                       item.DishId,
                       item.Restaurant,
                       item.Dish,
                       item.Quantity,
                       item.Note,
                       item.Price,
                       item.Time,
                       "Pendding");
        }
        public record DtoShoppingCart(string CartId, string CustomerId, DtoPerson Customer, float Total, IEnumerable<CartItem> Items);
    }
}
