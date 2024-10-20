using E2E_APPLICATION.Models.ViewModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace E2E_APPLICATION.Pages.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private HomeViewModel _homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();
            this.DataContext = _homeViewModel;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Games/GamesMenu/GamesMenu.xaml", UriKind.Relative));
        }

        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            await _homeViewModel.Login("user@example.com", "string");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _homeViewModel.Logout();
        }
    }
}
