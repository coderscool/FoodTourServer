﻿using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IInteractor<in TMessage>
        where TMessage : IMessage
    {
        Task InteractAsync(TMessage message, CancellationToken cancellationToken);
    }
}
