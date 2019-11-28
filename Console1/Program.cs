using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>(1000000);
            for (int i = 0; i < 1000000; i++)
            {
                var item = new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"UserName_{i}" + new string('a', 100),
                    Adress = $"UserAdress_{i}" + new string('a', 100),
                    Info = $"Info_{i}" + new string('a', 100),
                    Images = "Images_" + new string('a', 100)
                };
                items.Add(item);
            }

            string text = JsonConvert.SerializeObject(items);

            File.WriteAllText("RentFlatDB.txt", text);

        }
    }


    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Info { get; set; }
        public string Images { get; set; }

    }
}
