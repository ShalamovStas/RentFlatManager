using Newtonsoft.Json;
using RentApartment.DataBaseScreen;
using RentApartment.Models;
using RentApartment.Repositories;
using RentApartment.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RentApartment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Message { get; set; }

        public StartControl startControl { get; private set; }
        public LeftNavigationControl leftNavigationControl { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            HideLeftPanel();
            ApplicationStartup applicationStartup = new ApplicationStartup();
            applicationStartup.Run();


            startControl = new StartControl(MainNavigationHendler);
            leftNavigationControl = new LeftNavigationControl(MainNavigationHendler);
            Column0.Children.Add(leftNavigationControl);
            Column1.Children.Add(startControl);
        }

        private void HideLeftPanel()
        {
            MainColumn0.Width = new GridLength(0);
        }

        private void ShowLeftPanel()
        {
            MainColumn0.Width = new GridLength(400);
        }

        private void LoadDB(StartControl startControl)
        {
            string tempFolder = System.IO.Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\Documents\RentFlatData\";
            string dbFileName = "RentFlatDB.txt";
            string fullDBFilePath = tempFolder + "\\" + dbFileName;
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
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
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(data);
                    Message = items.Last<Item>().Name;
                }

            }
        }

        private void MainNavigationHendler(ScreenIndex index)
        {
            switch (index)
            {
                case ScreenIndex.MainScreen:
                    ShowMainScreen();

                    break;
                case ScreenIndex.AppartmentScreen:
                    ShowDatabaseScreen();

                    break;
                case ScreenIndex.RenersScreen:
                    break;
                case ScreenIndex.RentListScreen:
                    break;
                case ScreenIndex.Exit:
                    break;
                case ScreenIndex.Test:
                    ShowTestScreen();
                    break;
            }
        }

        private void ShowTestScreen()
        {
            Column1.Children.Clear();
            HideLeftPanel();
            Test1Control testScreen = new Test1Control();
            Column1.Children.Add(testScreen);
        }

        private void ShowDatabaseScreen()
        {
            Column1.Children.Clear();
            ShowLeftPanel();
            DatabaseScreen databaseScreen = new DatabaseScreen();
            Column1.Children.Add(databaseScreen);
        }

        private void ShowMainScreen()
        {
            HideLeftPanel();
            Column1.Children.Clear();
            Column1.Children.Add(startControl);
        }
    }
}
