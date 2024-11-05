using Contracts.Abstractions.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DishItem
    {
        public DishItem(string id, string personId, string name, long price, int quantity, Dto.Search search) 
        { 
            Id = id;
            PersonId = personId;
            Name = name;
            Price = price;
            Search = search;
            Quantity = quantity;
        }
        public string Id { get; }
        public string PersonId { get; }
        public string Name { get; }
        public long Price { get; }
        public Dto.Search Search { get; }
        public int Quantity { get; private set; }

        public void UpdateQuantity(int quantity)
            => Quantity = quantity;
    }
}
