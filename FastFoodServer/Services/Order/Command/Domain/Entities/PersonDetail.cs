using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonDetail
    {
        public PersonDetail(string name, string phone, string address) 
        {
            Name = name; 
            Phone = phone; 
            Address = address;
        }
        public string Name { get; }
        public string Phone { get; }
        public string Address { get; }

    }
}
