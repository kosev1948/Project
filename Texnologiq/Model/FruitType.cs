using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texnologiq.Controller;

namespace Texnologiq.Model
{
    public class FruitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //relation1 =>M
        public ICollection<Fruit> Fruits { get; set; }
    }
}
