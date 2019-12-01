using Newtonsoft.Json;
using RentApartment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentApartment.Repositories
{
    public class ApplicationStartup
    {

        public async void Run()
        {

            await Task.Factory.StartNew(() => {

                //Thread.Sleep(10000);

                if (!Directory.Exists(AppConstants.DATABASE_FOLDER))
                    Directory.CreateDirectory(AppConstants.DATABASE_FOLDER);

                if (!Directory.Exists(AppConstants.FLATS_REPOSITORY_FOLDERNAME))
                    Directory.CreateDirectory(AppConstants.FLATS_REPOSITORY_FOLDERNAME);

                if (!Directory.Exists(AppConstants.RENTERSFLATS_REPOSITORY_FOLDERNAME))
                    Directory.CreateDirectory(AppConstants.RENTERSFLATS_REPOSITORY_FOLDERNAME);

                if (!File.Exists(AppConstants.APPCONFIG_REPOSITORY_FILENAME))
                {
                    //File.Create(AppConstants.APPCONFIG_REPOSITORY_FILENAME);
                    AppConfig appConfig = new AppConfig()
                    {
                        FlatOrder = new List<string>(),
                        RenersOrder = new List<string>(),
                        RentFlatOrder = new List<string>()
                    };

                    File.WriteAllText(AppConstants.APPCONFIG_REPOSITORY_FILENAME, 
                        JsonConvert.SerializeObject(appConfig)) ;
                }

            });
        }
    }
}
