using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using RentApartment.Models;
using RentApartment.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RentApartment.DataBaseScreen
{
    /// <summary>
    /// Interaction logic for DatabaseScreen.xaml
    /// </summary>
    public partial class DatabaseScreen : UserControl
    {
        private IUserRepository _userRepository;
        public IEnumerable<User> UsersList { get; private set; }
        public DatabaseScreen()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            Load();
            
        }

        private void AddRow(User user)
        {
            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            TextBlock textBlock = new TextBlock();
            Button button = new Button();

            rectangle.Width = 150;
            rectangle.Height = 100;
            rectangle.Margin = new Thickness(10, 10, 10, 10);
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.Fill = new SolidColorBrush(Color.FromRgb(159, 159, 159));

            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.FontSize = 30;
            textBlock.Text = user.UserName;

            button.Style = Resources["RoundedButtonStyleDelete"] as Style;
            var icon = new PackIcon { Kind = PackIconKind.QuestionMark };
            icon.Width = 30;
            icon.Height = 30;
            icon.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            button.Content = icon;

            //button.Name = "name";
            button.Click += (object sender, RoutedEventArgs e) => {
                MessageBox.Show(JsonConvert.SerializeObject(user));
            };

            grid.Children.Add(rectangle);
            grid.Children.Add(textBlock);
            grid.Children.Add(button);

            StackPanel.Children.Add(grid);
        }

        private void Action_test(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Load()
        {
            UsersList = await _userRepository.GetUsersAsyncFromFile();
            if (UsersList == null && UsersList.Count() == 0)
                return;
            var first10Users = UsersList.Take(10);
            foreach (var user in first10Users)
            {
                AddRow(user);
            }
        }

    }
}
