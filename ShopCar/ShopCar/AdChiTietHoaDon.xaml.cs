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
    /// Interaction logic for ChiTietHoaDon.xaml
    /// </summary>
    public partial class AdChiTietHoaDon : UserControl
    {
        public AdChiTietHoaDon()
        {
            InitializeComponent();
        }
        public int MaHoaDon { get; set; }
        public delegate void PassData(int s);
        public event PassData ChiTietOder;


        void Load()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                var Sour = (from l in BH.ChiTietHoaDons
                            where l.MaDonHang == MaHoaDon
                            select l).ToList();
                ListChiTiet.ItemsSource = Sour;

                int TSP = (from l in BH.ChiTietHoaDons
                                where l.MaDonHang == MaHoaDon
                                select l.SoLuongMua).Sum();

                txtTSP.Text = TSP.ToString();
                string Okane = (from l in BH.ChiTietHoaDons
                                  where l.MaDonHang == MaHoaDon
                                  select l.ThanhTien).Sum().ToString();

                txtTong.Text = string.Format("{0:0,0 VNĐ}", double.Parse(Okane));

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void btnBlack_Click(object sender, RoutedEventArgs e)
        {
            ChiTietOder?.Invoke(1);
        }
    }
}
