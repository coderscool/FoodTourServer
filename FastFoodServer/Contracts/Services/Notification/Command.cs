﻿using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Notification
{
    public class Command
    {
        public record NotificationMessage(string PersonId, string Name, string Message) : Message, ICommand;
    }
}
