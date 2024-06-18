using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texnologiq.Model;

namespace Texnologiq.Controller
{
    public class FruitTypeController
    {
        private FruitDbContext _FruitDbContext = new FruitDbContext();

        // Това е БД !!!!

        
        public List<FruitType> GetAllFruitTypes()
        {
            return _FruitDbContext.FruitTypes.ToList();
        }

        //метод за намиране на името на породата по зададено Id
        public string GetFruitById(int id)
        {
            return _FruitDbContext.Fruit.Find(id).Name;
        }
    }
}
