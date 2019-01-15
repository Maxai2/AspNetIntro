using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsExample.Services
{
    public class FruitService
    {
        private static List<Fruit> fruits;

        static FruitService()
        {
            fruits = new List<Fruit>()
            {
                new Fruit() { Id = 1, Title = "Apple", Price = 1.5 },
                new Fruit() { Id = 1, Title = "Orange", Price = 2.5 },
                new Fruit() { Id = 1, Title = "Avocado", Price = 3.5 }
            };
        }

        public List<Fruit> GetFruits()
        {
            return fruits;
        }

        public void Add(Fruit fruit)
        {
            fruit.Id = fruits.Max(f => f.Id) + 1;
            fruits.Add(fruit);
        }

        public void Remove(int id)
        {
            fruits.Remove(fruits.Find(f => f.Id == id));
        }
    }
}