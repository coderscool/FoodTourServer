﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

        }
    }
}
