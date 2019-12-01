using RentApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentApartment
{
    /// <summary>
    /// Interaction logic for LeftNavigationControl.xaml
    /// </summary>
    public partial class LeftNavigationControl : UserControl
    {
        private Action<ScreenIndex> SelectItemAction;

        public LeftNavigationControl(Action<ScreenIndex> selectDelegate)
        {
            InitializeComponent();
            SelectItemAction = selectDelegate;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Menu0_Click(object sender, MouseButtonEventArgs e)
        {
            SelectItemAction?.Invoke(ScreenIndex.MainScreen);
        }

        private void Menu1_Click(object sender, MouseButtonEventArgs e)
        {
            SelectItemAction?.Invoke(ScreenIndex.DatabaseScreen);
        }

        private void Item_0_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimateItemEnter(sender as Grid);
        }

        private void Item_0_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimateItemLeave(sender as Grid);
        }

        private void AnimateItemEnter(Grid grid)
        {
            ColorAnimation animation = new ColorAnimation();

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0.0;
            opacityAnimation.To = 0.1;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            SolidColorBrush brush_item0 = new SolidColorBrush();
            brush_item0.Color = Colors.White;
            brush_item0.Opacity = 0.1;
            grid.Background = brush_item0;
            brush_item0.BeginAnimation(SolidColorBrush.OpacityProperty, opacityAnimation);
        }
        private void AnimateItemLeave(Grid grid)
        {
            ColorAnimation animation = new ColorAnimation();

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0.1;
            opacityAnimation.To = 0.0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            SolidColorBrush brush_item0 = new SolidColorBrush();
            brush_item0.Color = Colors.White;
            brush_item0.Opacity = 0.1;
            grid.Background = brush_item0;
            brush_item0.BeginAnimation(SolidColorBrush.OpacityProperty, opacityAnimation);
        }
    }
}
