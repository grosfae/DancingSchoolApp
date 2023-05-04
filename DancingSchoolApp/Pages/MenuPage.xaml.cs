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

namespace DancingSchoolApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            MenuFrame.Navigate(new GroupList());
        }

        private void StudentBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new StudentList());
        }

        private void GroupBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new GroupList());
        }
    }
}
