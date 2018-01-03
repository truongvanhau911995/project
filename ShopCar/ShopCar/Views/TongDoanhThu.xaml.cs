using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopCar.Views
{
    /// <summary>
    /// Interaction logic for TongDoanhThu.xaml
    /// </summary>
    public partial class TongDoanhThu : UserControl
    {
     
        public TongDoanhThu()
        {
            InitializeComponent();
           
        }

        public void ComboYear()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
               var ListYear = (from h in BH.HoaDons
                                         select new
                                         {
                                             Years = (int?)h.NgayLap.Year
                                         }).Distinct();

                cbYear.ItemsSource = ListYear.ToList();
               
            }
            
        }

        private void LoadPieChartData()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from s in BH.SanPhams
                          orderby s.MaHangSX descending
                          group new { s.HangSanXuat, s } by new
                          {
                              s.HangSanXuat.TenHangSX
                          } into g
                          select new
                          {
                              g.Key.TenHangSX,
                              Tong = (int?)g.Sum(p => p.s.SoLuongBan)
                          });
               ((PieSeries)mcChart.Series[0]).ItemsSource = KQ.ToList();
            }

            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from s in BH.SanPhams
                          orderby s.MaLoaiSP descending
                          group new { s.LoaiSanPham, s } by new
                          {
                              s.LoaiSanPham.TenLoaiSP
                          } into g
                          select new
                          {
                              g.Key.TenLoaiSP,
                              Tong = (int?)g.Sum(p => p.s.SoLuongBan)
                          });
                ((PieSeries)mcChartLoai.Series[0]).ItemsSource = KQ.ToList();
            }


            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from s in BH.HoaDons
                          group s by new
                          {
                              Column1 = (int?)s.NgayLap.Year
                          } into g
                          select new
                          {
                              Nam = g.Key.Column1,
                              Tong = (decimal?)g.Sum(p => p.TongTien)
                          });
                ((ColumnSeries)mcChartNam.Series[0]).ItemsSource = KQ.ToList();
            }

          
        }
       
        int Nam = DateTime.Now.Year;


        private void btnFiter_Click(object sender, RoutedEventArgs e)
        {
            if (cbYear.Text!="")
            {
                Nam = Convert.ToInt32(cbYear.Text);
            }

            txtTile.Text = "Thống Kê Doanh Thu Sản Phẩm Theo Năm: " + Nam + " Đơn vị VNĐ";
            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from s in BH.ChiTietHoaDons
                          from hd in BH.HoaDons
                          where
                            hd.NgayLap.Year == Nam &&
                            hd.MaHoaDon == s.MaDonHang
                          group s by new
                          {
                              s.TenSP
                          } into g
                          select new
                          {
                              g.Key.TenSP,
                              DoanhThu = (decimal?)g.Sum(p => p.ThanhTien)
                          });
                ((PieSeries)mcChartTungNam.Series[0]).ItemsSource = KQ.ToList();
            }
        }

        private void cbYear_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPieChartData();
            ComboYear();
       
            btnFiter_Click(sender, e);
            txtTile.Text = "Thống Kê Doanh Thu Sản Phẩm Theo Năm: " + Nam + " Đơn vị VNĐ";
        }

     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

    }
}
