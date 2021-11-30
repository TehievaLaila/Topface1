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
    /// Логика взаимодействия для Hire.xaml
    /// </summary>
    public partial class Hire : Window
    {
        TopfaceEntities db = new TopfaceEntities();
        public Hire()
        {
            InitializeComponent();
            load_db();
        }
        private void load_db()
        {
            var query = from p in db.Post where p.ID_Post != 1 select p.Name;
            empcb.ItemsSource = query.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emplo = new Employee();
                {
                    emplo.Name = name.Text;
                    emplo.Surname = surname.Text;
                    emplo.patronymic = middlename.Text;
                    emplo.ID_Post = (from p in db.Post where p.Name == empcb.Text select p.ID_Post).First();
                };
                db.Employee.Add(emplo);
                db.SaveChanges();
                
                Employe ep = new Employe();
                ep.Show();
            }
            catch
            {
                MessageBox.Show("Введите все данные");
            }
            this.Close();
        }
    }
}
