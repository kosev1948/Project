using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texnologiq.Controller;
using Texnologiq.Model;

namespace Texnologiq.View
{
    public class Display
    {
        private FruitController fruitController = new FruitController();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");


            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");


        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperation);
        }

        private void PrintFruit(Fruit fruit)
        {
            Console.WriteLine($"{fruit.Id}. {fruit.Name} -- Description: {fruit.Description} Price: {fruit.Price}  TypeId: {fruit.FruitTypeId}");
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            FruitController fruitController = new FruitController();
            Fruit fruit = fruitController.Get(id);
            if (fruit != null)
            {
                fruitController.Delete(id);
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            FruitController fruitController = new FruitController();
            Fruit fruit = fruitController.Get(id);
            if (fruit != null)
            {
                PrintFruit(fruit);
            }
        }
        private void Update()
        {
            Console.Write("Enter the DOG's id: ");
            int fruitId = int.Parse(Console.ReadLine());
            Fruit newFruit = fruitController.Get(fruitId);
            if (newFruit == null)
            {
                Console.WriteLine("No searching fruits");
                return;
            }
            PrintFruit(newFruit);

            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newFruit.Name = Console.ReadLine();

            Console.Write("Age: ");
            newFruit.Description =(Console.ReadLine());

            FruitTypeController fruitTypeController = new FruitTypeController();
            List<FruitType> allFruitType = fruitTypeController.GetAllFruitTypes();
            Console.WriteLine("Types:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allFruitType)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi type:");
            newFruit.FruitTypeId = int.Parse(Console.ReadLine());

            FruitController fruitContorller = new FruitController();
            fruitContorller.Update(fruitId, newFruit);
        }
        private void Add()
        {
            Fruit newFruit = new Fruit();
            Console.Write("Name: ");
            newFruit.Name = Console.ReadLine();

            Console.Write("Description: ");
            newFruit.Description =(Console.ReadLine());

            FruitTypeController fruitTypeController = new FruitTypeController();
            List<FruitType> allFruitType = fruitTypeController.GetAllFruitTypes();
            Console.WriteLine("Type:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allFruitType)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi type:");
            newFruit.FruitTypeId = int.Parse(Console.ReadLine());

            FruitController fruitContorller = new FruitController();
            fruitContorller.Create(newFruit);

            Console.WriteLine($"{newFruit.Id}. {newFruit.Name} >>> {newFruit.Description} >> typeId:{newFruit.FruitTypeId}");
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "FRUITS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            FruitController fruitController = new FruitController();
            var products = fruitController.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Description} {item.FruitTypeId}");
            }
        }
    }
}
