using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Models
{
    public enum ScreenIndex
    {
        MainScreen,
        AppartmentScreen,
        RenersScreen,
        RentListScreen,
        Exit,
        Test
    }

    public class AppConstants
    {
        public static string DATABASE_FOLDER = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\\Desktop\RentDatabase\";

        public static string RENTERS_REPOSITORY_FOLDERNAME = DATABASE_FOLDER + "Renters";
        //public static string RENTERS_REPOSITORY_FILENAME = DATABASE_FOLDER + "Renters.txt";

        public static string FLATS_REPOSITORY_FOLDERNAME = DATABASE_FOLDER + "Flats";
        //public static string FLATS_REPOSITORY_FILENAME = DATABASE_FOLDER + "Flats.txt";

        public static string RENTERSFLATS_REPOSITORY_FOLDERNAME = DATABASE_FOLDER + "RentersFlats";
        //public static string RENTERSFLATS_REPOSITORY_FILENAME = DATABASE_FOLDER + "RentersFlats.txt";

        public static string APPCONFIG_REPOSITORY_FILENAME = DATABASE_FOLDER + "AppConfig.txt";
    }
}
