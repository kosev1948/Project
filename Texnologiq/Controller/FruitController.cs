using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texnologiq.Model;

namespace Texnologiq.Controller
{
    public class FruitController
    {
        private FruitDbContext _FruitDbContext = new FruitDbContext(); // Това е БД !!!!

        public Fruit Get(int id)
        {
            Fruit findedFruit = _FruitDbContext.Fruit.Find(id);
            if (findedFruit != null)
            {
                _FruitDbContext.Entry(findedFruit).Reference(x => x.FruitTypes).Load();
            }
            return findedFruit;
        }

        public List<Fruit> GetAll()
        {
            return _FruitDbContext.Fruit.Include("FruitTypes").ToList();
        }

        public void Create(Fruit fruits)
        {
            _FruitDbContext.Fruit.Add(fruits);
            _FruitDbContext.SaveChanges();
        }
        public void Update(int id,Fruit fruits)
        {
            Fruit findedFruit = _FruitDbContext.Fruit.Find("Types");
            if (findedFruit == null) //
            {
                return;
            }
            
            findedFruit.Name = fruits.Name;
            findedFruit.FruitTypeId = fruits.FruitTypeId;
            _FruitDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Fruit findedFruit = _FruitDbContext.Fruit.Find(id);
            _FruitDbContext.Fruit.Remove(findedFruit);
            _FruitDbContext.SaveChanges();
        }


    }
}
