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
using System.Windows.Shapes;
using Topface1.TF;

namespace Topface1
{
    /// <summary>
    /// Логика взаимодействия для Employe.xaml
    /// </summary>
    public partial class Employe : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Employe()
        {
            InitializeComponent();
            Data_loaded();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hire hire = new Hire();
            hire.Show();
            this.Close();
           
        }

        private void Data_loaded()
        {
            var qar =
                from employee in db.Employee
                join post in db.Post on employee.ID_Post equals post.ID_Post
                where post.ID_Post != 1
                select new
                {
                    id = employee.ID_Employee,
                    Имя = employee.Name,
                    Фамилия = employee.Surname,
                    Отчество = employee.patronymic,
                    Пост = post.Name

                };
            dgempl.ItemsSource = qar.ToList();

        }
    }
}
