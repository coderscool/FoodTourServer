﻿using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Command
    {
        public record CreateDish(string Id, string PersonId, Dto.Person Person, string Name, string Image, Dto.Price Price, Dto.Rate Rate, Dto.Search Search) : Message, ICommand;
    }
}
