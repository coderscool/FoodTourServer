using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

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

        public record TimeActive(int Start, int End)
        {
            public static implicit operator Abstractions.Protobuf.TimeActiveDetail(TimeActive timeActive)
                => new()
                {
                    Start = timeActive.Start,
                    End = timeActive.End
                };
        }

        public record ExtraFood(string Name, ulong Price)
        {
            public static implicit operator Abstractions.Protobuf.ExtraFoodDetail(ExtraFood extraFood)
                => new()
                {
                    Name = extraFood.Name,
                    Price = extraFood.Price
                };
        }

        public record DtoSearch(string Nation, List<string> Category)
        {
            public static implicit operator Abstractions.Protobuf.Search(DtoSearch search)
                => new()
                {
                    Category = { search.Category },
                    Nation = search.Nation 
                };
        }
        public record Rate(float Point);
        public record DtoPerson(string Name, string Image, DtoAddress Address, string Phone)
        {
            public static implicit operator Abstractions.Protobuf.Person(DtoPerson person)
                => new()
                {
                    Name = person.Name,
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
        public record CartItem(string ItemId, string RestaurantId, string DishId, DtoDish Dish, List<string> Extra, DtoPrice Price, ushort Quantity, string Note, bool CheckOut);
        public record OrderItem(string ItemId, string RestaurantId, string DishId, DtoPerson Restaurant, DtoDish Dish, List<string> Extra,
            ushort Quantity, string Note, DtoPrice Price, string Status)
        {
            public static implicit operator OrderItem(CartItem item)
                => new(ObjectId.GenerateNewId().ToString(),
                       item.RestaurantId,
                       item.DishId,
                       null,
                       item.Dish,
                       item.Extra,
                       item.Quantity,
                       item.Note,
                       item.Price,
                       "Pendding");
        }
        public record DtoShoppingCart(string CustomerId, IEnumerable<CartItem> Items);
        public record DtoOrder(string OrderId, string CustomerId, DtoPerson Customer, ulong Total, OrderItem Item);

    }
}
