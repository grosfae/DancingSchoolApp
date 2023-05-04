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
    /// Логика взаимодействия для GroupAddEdit.xaml
    /// </summary>
    public partial class GroupAddEdit : Page
    {
        
        Group contextGroup;
        public GroupAddEdit(Group group)
        {
            InitializeComponent();
            contextGroup = group;
            DataContext = contextGroup;
            CbTrainer.ItemsSource = App.DB.Trainer.ToList();
            CbDance.ItemsSource = App.DB.Dance.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (contextGroup.Dance == null)
            {
                errorMessage += "Выберите танец\n";
            }
            if (contextGroup.Trainer == null)
            {
                errorMessage += "Выберите тренера\n";
            }

            if (contextGroup.CountStudent < 0 || contextGroup.CountStudent > 999)
            {
                errorMessage += "Введите количество студентов\n";
            }


            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            

            if (MessageBox.Show("Сохранить изменения?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (contextGroup.ID == 0)
                {
                    App.DB.Group.Add(contextGroup);
                }
                App.DB.SaveChanges();
                NavigationService.Navigate(new GroupList());

            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string fileName = $"{contextGroup.ID}.txt";
            
            
        }
    }
}
