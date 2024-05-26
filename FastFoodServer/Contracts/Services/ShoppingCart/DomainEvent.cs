﻿using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    internal class DomainEvent
    {
        public record CartItemAdd(Guid Id, Guid PersonId, Guid DishId, Dto.Person Person, Dto.Dish Dish, byte[] Image, Dto.Price Price, int Amount, string Status, int TimeExpire) : Message, ICommand;
    }
}