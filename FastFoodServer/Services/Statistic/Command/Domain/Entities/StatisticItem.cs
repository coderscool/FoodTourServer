using Contracts.Abstractions.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatisticItem
    {
        public StatisticItem(string id, int numberOrder, int numberMeal, int numberDish, long revanue, int numberRate, Dto.EvaluateAvg evaluateAvg) 
        { 
            Id = id;
            NumberOrder = numberOrder;
            NumberMeal = numberMeal;
            NumberDish = numberDish;
            Revanue = revanue;
            NumberRate = numberRate;
            EvaluateAvg = evaluateAvg;
        }
        public string Id { get; set; }
        public int NumberOrder { get; private set; }
        public int NumberMeal { get; private set; }
        public int NumberDish { get; private set; }
        public long Revanue { get; private set; }
        public int NumberRate { get; set; }
        public Dto.EvaluateAvg EvaluateAvg { get; set; }
        
        public void UpdateNumberDish(int quantity)
        {
            NumberDish += quantity;
        }

        public void UpdateRevanue(int quantity, long price)
        {
            Revanue += quantity * price;
            NumberMeal += quantity;
            NumberOrder += 1;
        }
    }
}
