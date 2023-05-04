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
    /// Логика взаимодействия для StudentList.xaml
    /// </summary>
    public partial class StudentList : Page
    {
        public StudentList()
        {
            InitializeComponent();
            DtStudents.ItemsSource = App.DB.Student.Where(x => x.IsDelete != true).ToList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (sender as Button).DataContext as Student;
            selectedStudent.IsDelete = true;
            App.DB.SaveChanges();
            DtStudents.ItemsSource = App.DB.Student.Where(x => x.IsDelete != true).ToList();
        }
    }
}
