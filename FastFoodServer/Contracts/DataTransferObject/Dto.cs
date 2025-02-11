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
        public record DtoAddress(string Address, List<int> Location)
        {
            public static implicit operator Abstractions.Protobuf.Address(DtoAddress address)
                => new()
                {
                    Address_ = address.Address,
                    Location = { address.Location }
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
        public record CartItem(string Id, DtoDish Dish, ushort Quantity, DtoPrice Price);
        public record OrderItem(string Id, DtoDish Product, ushort Quantity, DtoPrice UnitPrice)
        {
            public static implicit operator OrderItem(CartItem item)
                => new(Guid.NewGuid().ToString(), item.Dish, item.Quantity, item.Price);
        }
        public record DtoShoppingCart(string CartId, string CustomerId, DtoPerson Customer, float Total, IEnumerable<CartItem> Items);
    }
}
