﻿using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class DomainEvent
    {
        public record PaymentRequest(string AggregateId, string OrderId, long Price, int Quantity, long Version) : Message, IDomainEvent;

        public record AccountCreate(string UserId, Dto.DtoPerson Person, long Version) : Message, IDomainEvent;

        public record PaymentRefund(string AggregateId, string OrderId, long Price, int Quantity, long Version) : Message, IDomainEvent;
    }
}
