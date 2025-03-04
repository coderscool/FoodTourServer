using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountItem
    {
        public AccountItem(string id, Dto.DtoPerson person) 
        { 
            Id = id;
            Person = person;
        }
        public string Id { get; }
        public Dto.DtoPerson Person { get; }
    }
}
