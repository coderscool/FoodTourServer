using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObject
{
    public static class Dto
    {
        public record DtoPrice(ulong Cost, float Discount)
        {
            public static implicit operator Abstractions.Protobuf.Price(DtoPrice price)
                => new()
                {
                    Cost = price.Cost,
                    Discount = price.Discount
                };
        }

        public record DtoAddress(string Address, double Latitude, double Longitude);

        public record DtoAddressMongo(string Address, GeoJsonPoint<GeoJson2DGeographicCoordinates> Location);
        
       
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
        public record DtoPerson(string Name, string Image, DtoAddress Address, string Phone)
        {
            public static implicit operator Abstractions.Protobuf.Person(DtoPerson person)
                => new()
                {
                    Name = person.Name,
                    Image = person.Image,
                    Address = person.Address.Address,
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

        public record DtoRate(ulong Quality, ulong Cost, ulong Position, ulong Space, ulong Service)
        {
            public static implicit operator Abstractions.Protobuf.Rate(DtoRate rate)
                => new()
                {
                    Quality = rate.Quality,
                    Cost = rate.Cost,
                    Position = rate.Position,
                    Space = rate.Space,
                    Service = rate.Service
                };
        }
        public record EvaluateAvg(float Quality, float Price, float Position, float Space, float Serve);
        public record CartItem(string ItemId, string RestaurantId, string DishId, DtoPerson Restaurant, DtoDish Dish, DtoPrice Price, ushort Quantity, string Note);
        public record OrderItem(string ItemId, string RestaurantId, string DishId, DtoPerson Restaurant, DtoDish Dish, ushort Quantity, string Note,
            DtoPrice Price, string Status)
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
                       "Pendding");
        }
        public record DtoShoppingCart(string CartId, string CustomerId, DtoPerson Customer, ulong Total, string Description, IEnumerable<CartItem> Items);
        public record DtoOrder(string OrderId, string CustomerId, DtoPerson Customer, ulong Total, string Description, string Status, IEnumerable<OrderItem> Items);

    }
}
