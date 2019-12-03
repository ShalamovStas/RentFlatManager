using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace RentApartment.Test
{
    /// <summary>
    /// Interaction logic for Test1.xaml
    /// </summary>
    public partial class Test1Control : UserControl
    {
        public ICollectionView TestListItems { get; set; }
        public Test1Control()
        {
            InitializeComponent();
            TestData item = new TestData()
            {
                Message = "Binding message"
            };
            DataContext = item;

           
        }
    }

    public class TestData
    {
        public string Message { get; set; }
    }
}
