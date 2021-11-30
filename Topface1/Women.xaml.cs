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
    /// Логика взаимодействия для Women.xaml
    /// </summary>
    public partial class Women : Window
    {
        public static TopfaceEntities db = new TopfaceEntities();
        public Women()
        {
            InitializeComponent();
            var cl = from pk in db.PodCategory where pk.ID_Category == 1 select pk;
            Basilick.ItemsSource = cl.ToList();
            Basilick.DisplayMemberPath = "Name";
        }

        private void Basilick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pp = Basilick.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                          ID = pr.ID_Product,
                          Имя = pr.Name,
                          Описание = pr.Description,
                          Количество = pr.Number,
                      };

            Mouse.ItemsSource = pro.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            
        }

        private void Dele_Click(object sender, RoutedEventArgs e)
        {
            string idval = Mouse.SelectedItem.ToString().Substring(7, 3);
            int id = Convert.ToInt32(idval);
            var query = (from pr in db.Product where pr.ID_Product == id select pr).First();
            db.Product.Remove(query);
            db.SaveChanges();
            var pp = Basilick.SelectedItem as PodCategory;
            var pro = from pr in db.Product
                      join kat in db.PodCategory
                      on pr.ID_PodCategory equals kat.ID_PodCategory
                      where kat.Name == pp.Name
                      select new
                      {
                          ID = pr.ID_Product,
                          Имя = pr.Name,
                          Описание = pr.Description,
                          Количество = pr.Number,
                      };

            Mouse.ItemsSource = pro.ToList();

        }
    }
}
