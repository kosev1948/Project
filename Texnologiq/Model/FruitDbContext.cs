using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texnologiq.Model
{
    public class FruitDbContext:DbContext
    {
        public FruitDbContext() : base("FruitDbContext")
        {

        }
        public DbSet<FruitType> FruitTypes { get; set; }
        public DbSet<Fruit> Fruit { get; set; }
    }
}
