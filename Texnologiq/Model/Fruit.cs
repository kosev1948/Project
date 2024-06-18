using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texnologiq.Model
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int FruitTypeId {  get; set; }//Fk
        
        public FruitType FruitTypes { get; set; }//table which connect
    }
}
