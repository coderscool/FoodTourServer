using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountItem
    {
        public AccountItem(string id, long budget) 
        { 
            Id = id;
            Budget = budget;
        }
        public string Id { get; }
        public long Budget { get; private set; }

        public void Decrease(int quantity, long price) 
        {
            Budget -= quantity * price;
        }

        public void Increase(int quantity, long price)
        {
            Budget += quantity * price;
        }
    }
}
