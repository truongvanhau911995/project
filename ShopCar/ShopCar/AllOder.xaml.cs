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
    /// Interaction logic for AllOder.xaml
    /// </summary>
    public partial class AllOder : UserControl
    {
        public AllOder()
        {
            InitializeComponent();
        }

       
      
            
       
        private void Load()
        {
            using (var BLT = new BanLapTopEntities())
            {

                var Pro = (from h in BLT.HoaDons
                           orderby h.NgayLap descending
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

        private void btnChuyenThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Xác Nhận ?", "Giao Hàng", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int ID = (ListGioHang.SelectedItem as HoaDon).MaHoaDon;
                using (var BH = new Models.BanLapTopEntities())
                {
                    var sql = BH.HoaDons.Where(m => m.MaHoaDon == ID).Single() as HoaDon;
                    sql.DaThanhToan = true;
                    BH.SaveChanges();

                }
                Load();
            }
        }

        void CTHHoaDon(int i)
        {
            if (i == 1)
            {
                UserView.Children.RemoveAt(UserView.Children.Count - 1);
                AllOder ad = new AllOder();
                UserView.Children.Add(ad); 
                Load();
            }
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            int ID = (ListGioHang.SelectedItem as HoaDon).MaHoaDon;
            AdChiTietHoaDon Pro = new AdChiTietHoaDon();
            Pro.ChiTietOder += new AdChiTietHoaDon.PassData(CTHHoaDon);
            Pro.MaHoaDon = ID;
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }


        private void ListGioHang_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
           

        }
    }
}
