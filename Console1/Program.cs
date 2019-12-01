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
        private static int count = 1000;
        static void Main(string[] args)
        {
            string tempFolder = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\Documents\RentFlatData\";
            string dbFileName = "UserTable.txt";
            string fullDBFilePath = tempFolder + "\\" + dbFileName;

            var items = new List<User>(count);
            for (int i = 0; i < count; i++)
            {
                var user = new User()
                {
                    Guid = Guid.NewGuid(),
                    UserName = $"UserName_{i}",
                    Adress = $"UserAdress_{i}",
                };
                items.Add(user);
            }

            string text = JsonConvert.SerializeObject(items);

            File.WriteAllText(fullDBFilePath, text);

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

    public class User
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
    }
}
