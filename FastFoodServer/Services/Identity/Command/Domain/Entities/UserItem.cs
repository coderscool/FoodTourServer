﻿using Contracts.DataTransferObject;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserItem
    {
        public UserItem(string id, string userName, string passWord, Dto.DtoPerson person, string role) 
        { 
            Id = id;
            UserName = userName;
            PassWord = passWord;
            Person = person;
            Role = role;
        }
        public string Id { get; }
        public string UserName { get; }
        public string PassWord { get; } 
        public Dto.DtoPerson Person { get; }
        public string Role { get; } 
    }
}
