using ShopCar.Models;
using ShopCar.Views;
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

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        public string IdAdmin { get; set; }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Exit Admin ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            TongDoanhThu Pro = new TongDoanhThu();
            txtTitle.Text = "Thống Kê";
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void LoaiSP_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Loại Sản Phẩm";
            TypeProducts Pro = new TypeProducts();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void HangSX_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Nhà Sản Xuất Sản Phẩm";
            AdHangSanXuat Pro = new AdHangSanXuat();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void DonHang_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Đơn Hàng";
            AllOder Pro = new AllOder();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
      
        }
        void UserInfo_Share(string i)
        {

            if (i == "1")
            {
                Load();
            }
            if (i == "2")
            {

                UserView.Children.Clear();
            }
        }
        private void INFO_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Thông Tin";
            Views.ThongTinNguoiDung Pro = new Views.ThongTinNguoiDung();
            Pro.InfoUser += new ThongTinNguoiDung.PassData(UserInfo_Share);
            Pro.IdNguoiDung = IdAdmin;
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }
        public BitmapImage ToImage(byte[] array)
        {


            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void Load()
        {
            using (var BLT = new BanLapTopEntities())
            {
                var User = (from n in BLT.TaiKhoans
                            where n.IdNguoiDung == IdAdmin
                            select n).FirstOrDefault();

                if (User != null)
                {
                    ImgAd.ToolTip = User.HoTen;
                    txtNameUsers.Text = User.HoTen;

                    byte[] bitImage = User.Avatar;


                    if (bitImage != null)
                    {

                        ImgAd.Fill = new ImageBrush(ToImage(bitImage));

                    }
                    else
                    {
                        ImgAd.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute)));
                    }

                }
            }
            TongDoanhThu Pro = new TongDoanhThu();
            txtTitle.Text = "Thống Kê";
            UserView.Children.Clear();
            UserView.Children.Add(Pro);

        }

        private void AllPro_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Tất Cả Sản Phẩm";
            AllProducts Pro = new AllProducts();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void btnHistoy_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Lịch Sử Mua Hàng";
           // LichSuMuaHang Pro = new LichSuMuaHang();
            UserView.Children.Clear();
            //UserView.Children.Add(Pro);
        }

        private void btnNguoiDung_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Danh Sách Người Dùng";
            AcountList Pro = new AcountList();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "Report";
            ReportView Pro = new ReportView();
            UserView.Children.Clear();
            UserView.Children.Add(Pro);
        }
    }
}
