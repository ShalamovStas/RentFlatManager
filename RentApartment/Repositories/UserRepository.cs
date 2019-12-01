using Newtonsoft.Json;
using RentApartment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersAsyncFromFile();
    }
    public class UserRepository : IUserRepository
    {
        private ApplicationContext applicationContext;
        public UserRepository()
        {
            applicationContext = new ApplicationContext();
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            IEnumerable<User> users = null; ;
            await Task.Factory.StartNew(() =>
            {
                users = applicationContext.Users.ToList();
            });

            return users;
        }

        public async Task<IEnumerable<User>> GetUsersAsyncFromFile()
        {
            string dbFileName = "UserTable.txt";
            string fullDBFilePath = AppConstants.DATABASE_FOLDER + "\\" + dbFileName;
            IEnumerable<User> users = null; ;

            await Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(AppConstants.DATABASE_FOLDER))
                {
                    Directory.CreateDirectory(AppConstants.DATABASE_FOLDER);
                    return;
                }
                if (!File.Exists(fullDBFilePath))
                {
                    return;
                }

                using (StreamReader reader = new StreamReader(fullDBFilePath))
                {
                    string data = reader.ReadToEnd();

                    if (data != null)
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(data);
                    }
                }
            });

            return users;
        }
    }
}
