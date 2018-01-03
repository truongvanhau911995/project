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
using System.Windows.Threading;
using System.Data;

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for ChiTietSanPham.xaml
    /// </summary>
    public partial class ChiTietSanPham : UserControl
    {
        DispatcherTimer RunTime;
        DispatcherTimer RunTime1;
        Models.BanLapTopEntities BLT;
        public ChiTietSanPham()
        {
            InitializeComponent();
        }


        public delegate void PassData(int i);
        public event PassData Share;
        public int MaSanPham { get; set; }
        public string MaNguoiDung { get; set; }
        private void LoadChiTiet()
        {
            BLT = new Models.BanLapTopEntities();
            var CT = (from h in BLT.SanPhams
                      where h.MaSP == MaSanPham
                      select h);

            DataContext = CT.ToList();

            var SLB = (from h in BLT.SanPhams
                       where h.MaSP == MaSanPham
                       select h.SoLuongBan).SingleOrDefault();
            txtSLB.Text = SLB.ToString();

            var SLX = (from h in BLT.SanPhams
                       where h.MaSP == MaSanPham
                       select h.LuotXem).SingleOrDefault();
            txtSLX.Text = SLX.ToString();


            var LSP = (from h in BLT.LoaiSanPhams
                       from k in BLT.SanPhams
                       where h.MaLoaiSP == k.MaLoaiSP && k.MaSP == MaSanPham
                       select h.TenLoaiSP).SingleOrDefault();
            txtLoaiSP.Text = LSP;

            var Logo = (from h in BLT.HangSanXuats
                        from k in BLT.SanPhams
                        where h.MaHangSX == k.MaHangSX && k.MaSP == MaSanPham
                        select h.Logo).SingleOrDefault();


            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(Logo, UriKind.RelativeOrAbsolute);
            bi3.EndInit();
            ImgHang.Source = bi3;
        }


        private void ReplateView()
        {

            txtMoTa.Text = txtMoTa.Text.Replace("\\r\\n", "\r\n");
            txtCauHinh.Text = txtCauHinh.Text.Replace("\\r\\n", "\r\n");
            
        }

        public void LoadSanPham()
        {


            int? MaHangSX = (from h in BLT.SanPhams
                             where h.MaSP == MaSanPham
                             select h.MaHangSX).SingleOrDefault();

            int? MaLoaiSP = (from h in BLT.SanPhams
                             where h.MaSP == MaSanPham
                             select h.MaLoaiSP).SingleOrDefault();


            var SPCL = (from h in BLT.SanPhams
                        where h.MaLoaiSP == MaLoaiSP
                        select h).OrderBy(x => Guid.NewGuid()).Take(6);
            ListCungLoai.ItemsSource = SPCL.ToList();


            var SPCH = (from h in BLT.SanPhams
                        where h.MaHangSX == MaHangSX
                        select h).OrderBy(x => Guid.NewGuid()).Take(6);
            ListCungHang.ItemsSource = SPCH.ToList();
        }

      
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BLT = new BanLapTopEntities();

            LoadChiTiet();

            ReplateView();
            LoadSanPham();
            expan1.IsExpanded = false;
            expan2.IsExpanded = false;
            expan3.IsExpanded = false;

            RunTime = new DispatcherTimer();
           
            RunTime.Tick += new EventHandler(TimeLoad_Clock);
            RunTime.Interval = new TimeSpan(0, 0, 1);
            RunTime.Start();

            RunTime1 = new DispatcherTimer();
            RunTime1.Tick += new EventHandler(TimeLoad1_Clock);
            RunTime1.Interval = new TimeSpan(0, 0, 0);
            RunTime1.Start();
        }

        /// <summary>
        /// Tim Tên 1 Element in DataTemplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
        private void TimeLoad1_Clock(object sender, EventArgs e)
        {
            ReplateView();
            RunTime1.Stop();
        }
        private void TimeLoad_Clock(object sender, EventArgs e)
        {
           
            foreach (var textblock in FindVisualChildren<TextBlock>(ListCungHang))
            {
                if (textblock.Name == "txtMoTaNgan")
                {
                    textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
                }
            }

            foreach (var textblock in FindVisualChildren<TextBlock>(ListCungLoai))
            {
                if (textblock.Name == "txtMoTaNgan")
                {
                    textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
                }
            }

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            expan1.IsExpanded = false;
            expan2.IsExpanded = false;
            expan3.IsExpanded = false;
            Share?.Invoke(1);
        }

        //Lay Tong ten Khach Hang
        private string NameUser(string IdUser)
        {
            using (var BH = new BanLapTopEntities())
            {
                string Name = (from t in BH.TaiKhoans
                               where t.IdNguoiDung == IdUser
                               select t.HoTen).FirstOrDefault();
                return Name;
            }
        }

        //Lay Ten San Pham
        private string NameProduct(int MaSP)
        {
            using (var BH = new BanLapTopEntities())
            {
                string Name = (from t in BH.SanPhams
                               where t.MaSP == MaSP
                               select t.TenSP).FirstOrDefault();
                return Name;
            }
        }

        //Lay hinh San Pham
        private string ImageProduct(int MaSP)
        {
            using (var BH = new BanLapTopEntities())
            {
                string Name = (from t in BH.SanPhams
                               where t.MaSP == MaSP
                               select t.HinhSP).FirstOrDefault();
                return Name;
            }
        }

        private int MaDonHangNext()
        {
            using (var BH = new BanLapTopEntities())
            {
                int Name = (from t in BH.HoaDons
                               select t.MaHoaDon).Count();
                return Name + 1 ;
            }
        }
        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (MaNguoiDung=="")
            {
                MessageBox.Show("Cần đăng nhập để mua sản phẩm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            { 
                int SLM = Convert.ToInt32(txtSL.Value);
                int MaSp = MaSanPham;
                using (var BH = new Models.BanLapTopEntities())
                {
                    if (TonTaiHang(MaSp))
                    {
                        var sql = BH.DonHangTemps.Where(m => m.MaSP == MaSp).Single() as DonHangTemp;
                        int SLMua = sql.SoLuongMua + SLM;
                        sql.SoLuongMua = SLMua;
                        sql.ThanhTien =sql.ThanhTien + (GiaSP(MaSp) * SLM);
                        BH.SaveChanges();//lưu thay doi
                    }
                    else
                    {

                        var sql = new DonHangTemp();
                        sql.SoLuongMua = SLM;
                        sql.MaDonHang = MaDonHangNext();
                        sql.MaKhacHang = MaNguoiDung;
                        sql.TenKhachHang = NameUser(MaNguoiDung);
                        sql.MaSP = MaSp;
                        sql.TenSP = NameProduct(MaSp);
                        sql.HinhSP = ImageProduct(MaSp);
                        sql.GiaSP = GiaSP(MaSp);
                        sql.ThanhTien = GiaSP(MaSp);
                        BH.DonHangTemps.Add(sql);
                        BH.SaveChanges();//lưu thay doi
                    }
                }

            }
        } 

        private void txtSL_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (txtSL.Value < 0)
            {
                txtSL.Value = 0;
            }
            if (txtSL.Value > 99)
            {
                txtSL.Value = 99;
            }
         
        }


        private int LayMaSP(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            SanPham D = temp.DataContext as  SanPham;
            int NumberView = D.LuotXem + 1;
            int Id = D.MaSP;
            BLT = new Models.BanLapTopEntities();
            var sql = BLT.SanPhams.Where(m => m.MaSP == Id).FirstOrDefault();
            sql.LuotXem = NumberView;
            BLT.SaveChanges();//lưu thây đổi lượt xem
            return Id;
        }
        private void txtXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            MaSanPham = LayMaSP(sender,e);
            UserControl_Loaded(sender, e);
        }


        private decimal GiaSP(int MaSP)
        {
            using (var T = new BanLapTopEntities())
            {
                var t = (from h in T.SanPhams
                         where h.MaSP == MaSP
                         select h.GiaSP).SingleOrDefault();

                return t;
            }
        }
        private bool TonTaiHang(int MaSP)
        {
            using (var T = new BanLapTopEntities())
            {
                int t = (from h in T.DonHangTemps
                         where h.MaSP == MaSP
                         select h).Count();

                if (t > 0)
                {
                    return true;
                }
            }

            return false;
        }
        private void Mua_Click(object sender, RoutedEventArgs e)
        {
            if (MaNguoiDung=="")
            {
                MessageBox.Show("Cần đăng nhập để mua sản phẩm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                Button temp = sender as Button;
                SanPham D = temp.DataContext as SanPham;
                int MaSp = D.MaSP;
                using (var BH = new Models.BanLapTopEntities())
                {
                    if (TonTaiHang(MaSp))
                    {
                        var sql = BH.DonHangTemps.Where(m => m.MaSP == MaSp).Single() as DonHangTemp;
                        int SLMua = sql.SoLuongMua + 1;
                        sql.SoLuongMua = SLMua;
                        sql.ThanhTien = sql.ThanhTien + GiaSP(MaSp);
                        BH.SaveChanges();//lưu thay doi
                    }
                    else
                    {

                        var sql = new DonHangTemp();
                        sql.SoLuongMua = 1;
                        sql.MaDonHang = MaDonHangNext();
                        sql.MaKhacHang = MaNguoiDung;
                        sql.TenKhachHang = NameUser(MaNguoiDung);
                        sql.MaSP = MaSp;
                        sql.TenSP = NameProduct(MaSp);
                        sql.HinhSP = ImageProduct(MaSp);
                        sql.GiaSP = GiaSP(MaSp);
                        sql.ThanhTien = GiaSP(MaSp);
                        BH.DonHangTemps.Add(sql);
                        BH.SaveChanges();//lưu thay doi
                    }
                }

            }
        }

            //int? SLB = (from h in BLT.SanPhams
            //            where h.MaSP == Id
            //            select h.SoLuongBan).SingleOrDefault();

            //int? SLT = (from h in BLT.SanPhams
            //            where h.MaSP == Id
            //            select h.SoLuongTon).SingleOrDefault();


            //if (SLT < 1)
            //{
            //    MessageBox.Show("Tạm Hết Hàng", "Notification", MessageBoxButton.OK, MessageBoxImage.Stop);
            //}
            //else
            //{

            //    BLT = new Models.BanLapTopEntities();
            //    var sql = BLT.SanPhams.Where(m => m.MaSP == Id).FirstOrDefault();
            //    sql.SoLuongBan = SLB + 1;
            //    sql.SoLuongTon = SLT - 1;
            //    BLT.SaveChanges();//lưu thay doi

            //    BLT = new Models.BanLapTopEntities();
            //    LoadChiTiet();
            //    ReplateView();
            //    LoadSanPham();
            //}
     }
 }

