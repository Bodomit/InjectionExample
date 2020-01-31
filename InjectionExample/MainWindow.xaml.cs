using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Collections.ObjectModel;
using InjectionExample.model;
using InjectionExample.model.repos;

namespace InjectionExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IStudentRepository StudentRepository { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            StudentRepository = new BadStudentRepository();
            // StudentRepository = new BetterStudentRepository();
            // StudentRepository = new BestStudentRepository();
        }

        private void refreshList(List<Student> students)
        {
            this.studentList.ItemsSource = students;
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = this.StudentRepository.GetStudents();
            refreshList(students);
            
        }

        private void btnGetByLastName_Click(object sender, RoutedEventArgs e)
        {
            string lastName = this.txtLastName.Text;
            List<Student> students = this.StudentRepository.GetStudentsByLastName(lastName);

            refreshList(students);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            List<Student> students = this.StudentRepository.ResetStudentsTable();
            refreshList(students);
        }
    }
}
