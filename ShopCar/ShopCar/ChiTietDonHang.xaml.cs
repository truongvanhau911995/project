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
    /// Interaction logic for ChiTietDonHang.xaml
    /// </summary>
    public partial class ChiTietDonHang : UserControl
    {
        public ChiTietDonHang()
        {
            InitializeComponent();
        }

        public int MaDonHang { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                var Sour = (from l in BH.ChiTietHoaDons
                            where l.MaDonHang == MaDonHang
                            select l).ToList();
                ListChiTiet.ItemsSource = Sour;

            }
        }

        private void ListChiTiet_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
