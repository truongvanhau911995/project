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
using System.Windows.Media.Animation;
using ShopCar.Views;
using System.Windows.Threading;
using System.IO;
using ShopCar.Models;
using System.Globalization;
using System.Linq.Dynamic;


namespace ShopCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Models.BanLapTopEntities BLT;

        public MainWindow()
        {
            InitializeComponent();

        }




        //Convert byte[] array to BitmapImage
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

        //
        string Loged = "";

        //
        DangNhap login = new DangNhap();
        DangKy Regist = new DangKy();
        ThongTinNguoiDung info = new ThongTinNguoiDung();
        ChiTietSanPham ChiTiet = new ChiTietSanPham();
        GioHang GH ;
        XemTheoLoai XTL;
        Setting Settings= new Views.Setting();

        //

        void CaiDat(string i)
        {
            switch (i)
            {
                case "Logout":
                    {
                        LogOut();
                    }
                    break;
                case "Dark":
                    {
                       this.Background = new SolidColorBrush(Color.FromRgb(46,46,46));
                        
                    } break;


                case "Light":
                    {
                        this.Background = Brushes.WhiteSmoke;
                      
                    }
                    break;
                case "Reset":
                    {
                        this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                        FontFamily = new FontFamily("Default");
                        WindowStyle = WindowStyle.SingleBorderWindow;

                    }
                    break;
                case "Full":
                    {

                        WindowStyle = WindowStyle.None;
                       

                    }
                    break;
                case "Windows":
                    {
                        WindowStyle = WindowStyle.SingleBorderWindow;
                        

                    }
                    break;

                default:
                    FontFamily = new FontFamily(i);
                    break;
            }
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

        void FiterView(int i, int j)
        {
            if (j == 1)
            {
                UserControlView.Children.Clear();
                HidenView();
                hidden1.Width = 0;
                hidden4.Visibility = Visibility.Visible;
                hidden4.Width = Double.NaN;
                ChiTiet.Visibility = Visibility.Visible;
                ChiTiet.MaSanPham = i;
                ChiTiet.MaNguoiDung = Loged;
                UserControlView.Children.Add(ChiTiet);
            }
            if (j == 2)
            {
                if (Loged == "")
                {
                    MessageBox.Show("Cần đăng nhập để mua sản phẩm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    int MaSp = i;
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
                            sql.MaKhacHang = Loged;
                            sql.TenKhachHang = NameUser(Loged);
                            sql.MaSP = MaSp;
                            sql.TenSP = NameProduct(MaSp);
                            sql.GiaSP = GiaSP(MaSp);
                            sql.HinhSP = ImageProduct(MaSp);
                            sql.ThanhTien = GiaSP(MaSp);
                            BH.DonHangTemps.Add(sql);
                            BH.SaveChanges();//lưu thay doi
                        }
                    }
                }
            }
        }

        //

        void IsLogin(int i)
        {
            if (i == 1)
            {

                UserControlView.Children.Remove(Regist);
                login.Visibility = Visibility.Visible;
                UserControlView.Children.Add(login);
            }
            if (i == 2)
            {
                // UserControlView.Children.Clear();
                ShowView();
            }
        }
        void IsRegis(string t)
        {
            if (t == "1")
            {
                UserControlView.Children.Remove(login);
                Regist.Visibility = Visibility.Visible;
                UserControlView.Children.Add(Regist);
            }
            if (t == "2")
            {
                ShowView();
            }

        }

        void Share(string t)
        {
            ShowView();
            Loged = t;

            BLT = new BanLapTopEntities();

            var User = (from n in BLT.TaiKhoans
                        where n.IdNguoiDung == Loged
                        select n).FirstOrDefault();

            if (User != null)
            {
                txtNameUser.Text = User.HoTen;


                if (txtNameUser.Text.Length > 12)
                {
                    txtNameUser.FontSize = 14;
                }

                byte[] bitImage = User.Avatar;
          

                if (bitImage != null)
                {

                    eliUser.Fill = new ImageBrush(ToImage(bitImage));

                }
                else
                {
                    eliUser.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png",UriKind.Absolute)));
                }

                if (User.MaLoaiTK == 0)
                {
                    eliUser.ToolTip = "Người dùng";

                }
                else
                {
                    eliUser.ToolTip = "Admin";
                    Admin AD = new Admin();
                    AD.IdAdmin = Loged;
                    Hide();
                    AD.ShowDialog();
                    LogOut();
                    //Load 30 SP trang chu
                   // LoadSP();
                    //Load Danh loai sach san pham va nha san xuat

                    DSLSP_DSNSX();
                    Show();
                }
            }
        }

        //Thong tin nguoi dung
        void UserInfo_Share(string i)
        {

            if (i == "1")
            {
                Share(Loged);
                HidenView();
                hidden1.Width = Double.NaN;
            }
            if (i == "2")
            {

                UserControlView.Children.Clear();
                ShowView();
            }
        }


        //ChiTiet
        void ChiTietShare(int i)
        {
            if (i == 1)
            {
              //  LoadSP();
                UserControlView.Children.Clear();
                ShowView();
            }
        }

        //GioHang
        void Cart(string i)
        {
            if (i == "1")
            {
                UserControlView.Children.Clear();
                ShowView();
            }
            if (i == "2")
            {
               // LoadSP();
            }
        }

        //private void LoadSP()
        //{
        //    BLT = new BanLapTopEntities();
        //    var SPHOT = (from h in BLT.SanPhams
        //                 orderby h.LuotXem descending
        //                 where h.ConKinhDoanh != false
        //                 select h).Take(10);
        //    ListHot.ItemsSource = SPHOT.ToList();

        //    var SPNEW = (from h in BLT.SanPhams
        //                 orderby h.NgayNhapKho descending
        //                 where h.ConKinhDoanh != false
        //                 select h).Take(10);

        //    ListNew.ItemsSource = SPNEW.ToList();

        //    var SPSell = (from h in BLT.SanPhams
        //                  orderby h.SoLuongBan descending
        //                  where h.ConKinhDoanh != false
        //                  select h).Take(10);

        //    ListSell.ItemsSource = SPSell.ToList();
        //}

        private void DSLSP_DSNSX()
        {
            BLT = new BanLapTopEntities();
            var DSLSP = (from h in BLT.LoaiSanPhams
                         where h.ConKinhDoanh != false
                         select h);

            ListDSLSP.ItemsSource = DSLSP.ToList();


            var DSNSX = (from h in BLT.HangSanXuats
                         where h.ConKinhDoanh != false
                         select h);

            ListDSNSX.ItemsSource = DSNSX.ToList();
        }


        private void DelTableTemp()
        {
            using (var LT = new BanLapTopEntities())
            {
                LT.Database.ExecuteSqlCommand("TRUNCATE TABLE DonHangTemp");
            }
        
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            DelTableTemp();
            CaiDat();
            BLT = new BanLapTopEntities();

            txtDate.ToolTip = DateTime.Now.ToLongDateString() + "\n" + DateTime.Now.DayOfWeek;
            DispatcherTimer RunTime = new DispatcherTimer();
            RunTime.Tick += new EventHandler(RunTime_Clock);
            RunTime.Interval = new TimeSpan(0, 0, 1);
            RunTime.Start();


            //LoadForm Sau 0.1 s
            DispatcherTimer TimeLoad = new DispatcherTimer();
            //TimeLoad.Tick += new EventHandler(TimeLoad_Clock);
            TimeLoad.Interval = new TimeSpan(0, 0, 1);
            TimeLoad.Start();

         

            //Da từ InfoUser
            info.InfoUser += new ThongTinNguoiDung.PassData(UserInfo_Share);


            //Gửi Data Login
            login.share += new DangNhap.PassData(Share);
            login._Registration += new DangNhap.PassData(IsRegis);

            //Gửi Data Regist
            Regist.Share += new DangKy.PassData(IsLogin);

            //Load 30 SP trang chu
           // LoadSP();
            //Load Danh loai sach san pham va nha san xuat

            DSLSP_DSNSX();


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
        //private void TimeLoad_Clock(object sender, EventArgs e)
        //{
        //    foreach (var textblock in FindVisualChildren<TextBlock>(ListHot))
        //    {
        //        if (textblock.Name == "txtMoTaNgan")
        //        {
        //            textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
        //        }
        //    }

        //    foreach (var textblock in FindVisualChildren<TextBlock>(ListNew))
        //    {
        //        if (textblock.Name == "txtMoTaNgan")
        //        {
        //            textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
        //        }
        //    }
        //    foreach (var textblock in FindVisualChildren<TextBlock>(ListSell))
        //    {
        //        if (textblock.Name == "txtMoTaNgan")
        //        {
        //            textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
        //        }
        //    }
        //}


        private void RunTime_Clock(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            txtIClock.ToolTip = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);

        }


        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }



        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UserControlView.Children.Clear();
            ShowView();
        }

        private void HidenView()
        {
            hidden1.Visibility = Visibility.Hidden;

            hidden2.Visibility = Visibility.Hidden;
            hidden2.Width = 0;
            hidden3.Visibility = Visibility.Hidden;
            hidden3.Width = 0;
            hidden4.Visibility = Visibility.Hidden;
            hidden4.Width = 0;


            // this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\nguye\Desktop\ShopCar\ShopCar\Image\BackGround.jpg")));
        }
        private void ShowView()
        {
            hidden1.Visibility = Visibility.Visible;
            hidden1.Width = Double.NaN;
            hidden2.Visibility = Visibility.Visible;
            hidden2.Width = Double.NaN;
            hidden3.Visibility = Visibility.Visible;
            hidden3.Width = Double.NaN;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;
            // this.Background = new SolidColorBrush(Color.FromRgb(46,46,46));
        }



        //Command 
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UserControlView.Children.Clear();
            if (Loged != "")
            {
                HidenView();
                hidden1.Width = Double.NaN;
                info.Visibility = Visibility.Visible;
                info.IdNguoiDung = Loged;
                UserControlView.Children.Add(info);
            }

            else
            {
                HidenView();
                hidden1.Width = Double.NaN;
                login.Visibility = Visibility.Visible;
                UserControlView.Children.Add(login);
            }
        }
        //Click btnUsers
        //private void btnUser_Click(object sender, RoutedEventArgs e)
        //{
        //    UserControlView.Children.Clear();
        //    if (Loged != "")
        //    {
        //        HidenView();
        //        hidden1.Width = Double.NaN;
        //        info.Visibility = Visibility.Visible;
        //        info.IdNguoiDung = Loged;
        //        UserControlView.Children.Add(info);
        //    }

        //    else
        //    {
        //        HidenView();
        //        hidden1.Width = Double.NaN;
        //        login.Visibility = Visibility.Visible;
        //        UserControlView.Children.Add(login);
        //    }
        //}


        private int LayMaSP(object sender, RoutedEventArgs e)
        {

            Button temp = sender as Button;
            SanPham D = temp.DataContext as SanPham;
            int Id = D.MaSP;
            BLT = new BanLapTopEntities();
            int NumberView = (from h in BLT.SanPhams
                              where h.MaSP == Id
                              select h.LuotXem).SingleOrDefault() + 1;

            BLT = new BanLapTopEntities();
            var sql = BLT.SanPhams.Where(m => m.MaSP == Id).FirstOrDefault();
            sql.LuotXem = NumberView;
            BLT.SaveChanges();//lưu thây đổi lượt xem
            return Id;
        }

        //XEM CHI TIET SAN PHAM
        private void txtXemChiTiet_Click(object sender, RoutedEventArgs e)
        {

            UserControlView.Children.Clear();
            HidenView();
            hidden1.Width = 0;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;

            ChiTiet = new ChiTietSanPham();

            //chi tiet san pham
            ChiTiet.Share += new ChiTietSanPham.PassData(ChiTietShare);
            ChiTiet.Visibility = Visibility.Visible;
            ChiTiet.MaSanPham = LayMaSP(sender, e);
            ChiTiet.MaNguoiDung = Loged;
            UserControlView.Children.Add(ChiTiet);

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

        private int MaDonHangNext()
        {
            using (var BH = new BanLapTopEntities())
            {
                int Name = (from t in BH.HoaDons
                            select t.MaHoaDon).Count();
                return Name + 1;
            }
        }
        private void Mua_Click(object sender, RoutedEventArgs e)
        {
            if (Loged == "")
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
                        sql.MaKhacHang = Loged;
                        sql.TenKhachHang = NameUser(Loged);
                        sql.MaSP = MaSp;
                        sql.TenSP = NameProduct(MaSp);
                        sql.GiaSP = GiaSP(MaSp);
                        sql.HinhSP = ImageProduct(MaSp);
                        sql.ThanhTien = GiaSP(MaSp);
                        BH.DonHangTemps.Add(sql);
                        BH.SaveChanges();//lưu thay doi
                    }
                }
            }
        }

        //???!!!!

        //private void ShowScroll1_Checked(object sender, RoutedEventArgs e)
        //{
        //    ListHot.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Visible);
        //}

        //private void ShowScroll1_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    ListHot.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);
        //}

        //private void ShowScroll2_Checked(object sender, RoutedEventArgs e)
        //{
        //    ListNew.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Visible);
        //}

        //private void ShowScroll2_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    ListNew.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);
        //}


        //private void ShowScroll3_Checked(object sender, RoutedEventArgs e)
        //{
        //    ListSell.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Visible);
        //}

        //private void ShowScroll3_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    ListSell.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Hidden);
        //}


        private void LogOut()
        {
            DelTableTemp();
            Loged = "";
            txtNameUser.Text = "Khách hàng ?";
            eliUser.ToolTip = "Chưa Đăng Nhập";
            eliUser.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute)));

        }

        private void DangXuat_Click(object sender, RoutedEventArgs e)
        {
            
            //Fiter View
            Settings.Settings += new Setting.PassData(CaiDat);

            UserControlView.Children.Clear();
            HidenView();
            UserControlView.Children.Add(Settings);

        }

        private void bntGioHang_Click(object sender, RoutedEventArgs e)
        {
            //GioHang
            GH = new GioHang();
           
            UserControlView.Children.Clear();
            HidenView();
            
            //GH.Visibility = Visibility.Visible;
            GH.IdKhachHang = Loged;
            hidden1.Width = 100;
            UserControlView.Children.Add(GH);
            
        }

        private void btnTiemKiem_Click(object sender, RoutedEventArgs e)
        {
        
            XTL = new XemTheoLoai();
            //Fiter View
            XTL.EventXemTheoLoai += new XemTheoLoai.PassData(FiterView);

            XTL.Tile = "Tất Cả Sản Phẩm ";
            XTL.DieuKien = "MaSP > 0";
            UserControlView.Children.Clear();
            HidenView();
            XTL.Visibility = Visibility.Visible;
            hidden1.Width = 0;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;
            UserControlView.Children.Add(XTL);
        }

        private void btnLocDSLSP_Click(object sender, RoutedEventArgs e)
        {
            XTL = new XemTheoLoai();
            //Fiter View
            XTL.EventXemTheoLoai += new XemTheoLoai.PassData(FiterView);

            string chuoi = "MaLoaiSP == 0";
            XTL.Tile = "Loại: ";
            foreach (var check in FindVisualChildren<CheckBox>(ListDSLSP))
            {
                if (check.Name == "checkLoaiSP")
                {
                    if (check.IsChecked == true)
                    {
                        chuoi += " or " + "MaLoaiSP ==  " + check.Tag;
                        XTL.Tile += check.Content + " 。";
                    }
                }
            }

            XTL.DieuKien = chuoi;

            UserControlView.Children.Clear();
            HidenView();
            XTL.Visibility = Visibility.Visible;
            hidden1.Width = 0;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;
            UserControlView.Children.Add(XTL);
        }

        private void btnLocDSHSX_Click(object sender, RoutedEventArgs e)
        {
            XTL = new XemTheoLoai();
            //Fiter View
            XTL.EventXemTheoLoai += new XemTheoLoai.PassData(FiterView);

            string chuoi = "MaHangSX == 0";
            XTL.Tile = "Nhà Sản Xuất: ";
            foreach (var check in FindVisualChildren<CheckBox>(ListDSNSX))
            {
                if (check.Name == "checkHangSX")
                {
                    if (check.IsChecked == true)
                    {
                        chuoi += " or " + "MaHangSX ==  " + check.Tag;
                        XTL.Tile += check.ToolTip + " 。";
                    }
                }
            }

            XTL.DieuKien = chuoi;

            UserControlView.Children.Clear();
            HidenView();
            XTL.Visibility = Visibility.Visible;
            hidden1.Width = 0;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;
            UserControlView.Children.Add(XTL);
        }


      
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlView.Children.Count != 0)
            {
                UserControlView.Children.RemoveAt(UserControlView.Children.Count - 1);
                ShowView();
              //  LoadSP();
            }
        }


        private void FunTimKiem(string Tile)
        {
            XTL = new XemTheoLoai();
            XTL.EventXemTheoLoai += new XemTheoLoai.PassData(FiterView);
            XTL.Tile = Tile;

            UserControlView.Children.Clear();
            HidenView();
            XTL.Visibility = Visibility.Visible;
            hidden1.Width = 0;
            hidden4.Visibility = Visibility.Visible;
            hidden4.Width = Double.NaN;
            UserControlView.Children.Add(XTL);
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
               FunTimKiem(txtTimKiem.Text.Trim());
            }
         

        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                
                decimal  Gold = 5000000;
                decimal search;
                if (decimal.TryParse(txtTimKiem.Text, out search))
                {
                    using (var BH = new Models.BanLapTopEntities())
                    {
                        var sql = (from timkiem in BH.SanPhams
                                   where timkiem.GiaSP >= search
                                   where timkiem.GiaSP <= search + Gold
                                   where timkiem.ConKinhDoanh != false
                                   select timkiem).ToList().Take(5);

                        ListTimKiemSP.ItemsSource = sql;  
                    }
                }
                else
                {
                    using (var BH = new Models.BanLapTopEntities())
                    {
                        var sql = (from timkiem in BH.SanPhams
                                   from tk in BH.LoaiSanPhams
                                   from tk1 in BH.HangSanXuats
                                   where (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && timkiem.TenSP.Contains(txtTimKiem.Text))
                                   || (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && tk.TenLoaiSP.Contains(txtTimKiem.Text))
                                   || (timkiem.MaHangSX == tk1.MaHangSX && timkiem.MaLoaiSP == tk.MaLoaiSP && tk1.TenHangSX.Contains(txtTimKiem.Text))
                                   where timkiem.ConKinhDoanh != false
                                   where tk.ConKinhDoanh != false
                                   where tk1.ConKinhDoanh != false
                                   select timkiem).ToList().Take(5);

                        ListTimKiemSP.ItemsSource = sql;
                    }
                }
            }
            else
            {
                ListTimKiemSP.ItemsSource = null;
            }

            if (e.Key == Key.Enter) 
            {
                btnSearch_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                txtTimKiem.Clear();
            }
        }

        private void btnKiem_Click(object sender, RoutedEventArgs e)
        {
            
            txtXemChiTiet_Click(sender, e);
            ListTimKiemSP.ItemsSource = null;
        }

        private void CaiDat()
        {
            using (var BL = new BanLapTopEntities())
            {
               this.FontFamily = new FontFamily((from i in BL.CaiDats
                              select i.font).SingleOrDefault());

                if ((from i in BL.CaiDats select i.Back).SingleOrDefault()=="Dark")
                {
                    this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                }
                else if ((from i in BL.CaiDats select i.Back).SingleOrDefault() == "Light")
                {
                    this.Background = Brushes.WhiteSmoke;
                }

                if ((from i in BL.CaiDats select i.FullScreen).SingleOrDefault() == "Full")
                {
                    this.WindowStyle = WindowStyle.None;
                }
                else if ((from i in BL.CaiDats select i.FullScreen).SingleOrDefault() == "Windows")
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }
    }
}
