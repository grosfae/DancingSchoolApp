using DancingSchoolApp.Components.Model;
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
    /// Логика взаимодействия для GroupList.xaml
    /// </summary>
    public partial class GroupList : Page
    {
        public GroupList()
        {
            InitializeComponent();
            CbTrainer.ItemsSource = App.DB.Trainer.ToList();
            CbDance.ItemsSource = App.DB.Dance.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedGroup = (sender as Button).DataContext as Group;
            NavigationService.Navigate(new GroupAddEdit(selectedGroup));
        }

        private void Refresh()
        {
            IEnumerable<Group> groups = App.DB.Group.Where(x => x.IsDelete != true).ToList();
            if(CbDance.SelectedIndex != -1)
            {
                groups = groups.Where(x => x.Dance == CbDance.SelectedItem);
            }
            if (CbTrainer.SelectedIndex != -1)
            {
                groups = groups.Where(x => x.Trainer == CbTrainer.SelectedItem);
            }
            LvGroups.ItemsSource = groups;
        }

        private void CbDance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            CbDance.SelectedIndex = -1;
            CbTrainer.SelectedIndex = -1;
        }
    }
}
