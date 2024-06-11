using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.DataTransferObject
{
    public static class Dto
    {
        public record Price(string Cost, float Discount);
        public record Search(List<string> Nation, List<string> Category);
        public record Rate(float Point);
        public record Person(string Name, string Address, string Phone);
        public record Restaurant(string Name, string Address, string Phone);
    }
}
