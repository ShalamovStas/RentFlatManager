using Newtonsoft.Json;
using RentApartment.Models;
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
        public MainWindow()
        {
            InitializeComponent();
            StartControl startControl = new StartControl();
            Container.Children.Add(startControl);
            startControl.Label.Text = "Loading";

            new Thread(() => LoadDB(startControl)).Start();

            
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
                Dispatcher.Invoke(() =>
                {
                    startControl.Label.Text = "File in process";
                });
                string data = reader.ReadToEnd();
                Dispatcher.Invoke(() =>
                {
                    startControl.Label.Text = "Data parcing";
                });
                if (data != null)
                {
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(data);
                    Message = items.Last<Item>().Name;
                }

                Dispatcher.Invoke(() =>
                {
                    startControl.Label.Text = "Loaded";
                });

            }
        }
    }
}
