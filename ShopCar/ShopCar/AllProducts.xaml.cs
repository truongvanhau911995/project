using ShopCar.Models;
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

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for AllProducts.xaml
    /// </summary>
    public partial class AllProducts : UserControl
    {
        public AllProducts()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            int ID = (ListGioHang.SelectedItem as SanPham).MaSP;
            Views.UpDown UD = new Views.UpDown();
            UD.MaSP = ID;
            UD.ShowDialog();
            Load();
        }


        private void Load()
        {
            using (var BLT = new BanLapTopEntities())
            {

                var Pro = (from h in BLT.SanPhams
                           where h.ConKinhDoanh != false
                               select h);

                    if (Pro.Count() == 0)
                    {
                        ListGioHang.ItemsSource = null;
                    }
                    else
                    {
                        ListGioHang.ItemsSource = Pro.ToList();
                    }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void ListGioHang_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Selected", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
               
                int ID = (ListGioHang.SelectedItem as SanPham).MaSP;
                using (var BH = new Models.BanLapTopEntities())
                {
                    var sql = BH.SanPhams.Where(m => m.MaSP == ID).Single() as SanPham;
                    sql.ConKinhDoanh = false;
                    BH.SaveChanges();
                }
                Load();
                
                
            }
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            AddSP_EditSP AddSp = new AddSP_EditSP();
            AddSp.Owner = Window.GetWindow(this);
            AddSp.Show();
        }
    }
}
