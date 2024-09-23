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

        public void Decrease(long price) 
        { 
            if(Budget >= price)
            {
                Budget -= price;
            }
        }

        public void Increase(long price)
        {
            Budget += price;
        }

        public void UpdateBudget(long budget)
        {
            Budget = budget;
        }
    }
}
