using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using DoAn.Views;
using System.Windows.Threading;
using DoAn.Model;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Model.BanLapTopEntities BLT;

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
        Setting Settings = new Views.Setting();
        //
        // CHỨC NĂNG CÀI ĐẶT
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
                        this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));

                    }
                    break;


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

        //Lay hinh San Pham
        private string ImageProduct(int MaSP)
        {
            using (var BH = new BanLapTopEntities())
            {
                string Name = (from t in BH.SanPham
                               where t.MaSP == MaSP
                               select t.HinhSP).FirstOrDefault();
                return Name;
            }
        }

        //void FiterView(int i, int j)
        //{
        //    if (j == 1)
        //    {
        //        UserControlView.Children.Clear();
        //        HidenView();
        //        hidden1.Width = 0;
        //        hidden4.Visibility = Visibility.Visible;
        //        hidden4.Width = Double.NaN;
        //        ChiTiet.Visibility = Visibility.Visible;
        //       // ChiTiet.MaSanPham = i;
        //       // ChiTiet.MaNguoiDung = Loged;
        //        UserControlView.Children.Add(ChiTiet);
        //    }
        //    if (j == 2)
        //    {
        //        if (Loged == "")
        //        {
        //            MessageBox.Show("Cần đăng nhập để mua sản phẩm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        }
        //        else
        //        {
        //            int MaSp = i;
        //            using (var BH = new Model.BanLapTopEntities())
        //            {
        //                if (TonTaiHang(MaSp))
        //                {
        //                    var sql = BH.DonHangTemp.Where(m => m.MaSP == MaSp).Single() as DonHangTemp;
        //                    int SLMua = sql.SoLuongMua + 1;
        //                    sql.SoLuongMua = SLMua;
        //                    sql.ThanhTien = sql.ThanhTien + GiaSP(MaSp);
        //                    BH.SaveChanges();//lưu thay doi
        //                }
        //                else
        //                {

        //                    var sql = new DonHangTemp();
        //                    sql.SoLuongMua = 1;
        //                    sql.MaDonHang = MaDonHangNext();
        //                    sql.MaKhacHang = Loged;
        //                    sql.TenKhachHang = NameUser(Loged);
        //                    sql.MaSP = MaSp;
        //                    sql.TenSP = NameProduct(MaSp);
        //                    sql.GiaSP = GiaSP(MaSp);
        //                    sql.HinhSP = ImageProduct(MaSp);
        //                    sql.ThanhTien = GiaSP(MaSp);
        //                    BH.DonHangTemp.Add(sql);
        //                    BH.SaveChanges();//lưu thay doi
        //                }
        //            }
        //        }
        //    }
        //}

        ////

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
               // ShowView();
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
                //ShowView();
            }

        }

        //DANG NHAP
        void Share(string t)
        {
           // ShowView();
            Loged = t;

            BLT = new BanLapTopEntities();

            var User = (from n in BLT.TaiKhoan
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
                    eliUser.Fill = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Image/User.png", UriKind.Absolute)));
                }

                if (User.MaLoaiTK == 0)
                {
                    eliUser.ToolTip = "Người dùng";

                }
                else
                {
                    eliUser.ToolTip = "Admin";
                    //Admin AD = new Admin();            ===============ADMIN
                   // AD.IdAdmin = Loged;
                   // Hide();
                   // AD.ShowDialog();
                    LogOut();
                    //Load 30 SP trang chu
                    // LoadSP();
                    //Load Danh loai sach san pham va nha san xuat

                   // DSLSP_DSNSX();
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
                //HidenView();
                //hidden1.Width = Double.NaN;
            }
            if (i == "2")
            {

                UserControlView.Children.Clear();
              //  ShowView();
            }
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

           // DelTableTemp();
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
           // Regist.Share += new DangKy.PassData(IsLogin);

            //Load 30 SP trang chu
            // LoadSP();
            //Load Danh loai sach san pham va nha san xuat

           // DSLSP_DSNSX();


        }

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
      

        private void RunTime_Clock(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            txtIClock.ToolTip = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        //AN MENU
        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }


        //SHOW MENU
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
            //ShowView();
        }

        //private void HidenView()
        //{
        //    hidden1.Visibility = Visibility.Hidden;
        //    hidden2.Visibility = Visibility.Hidden;
        //    hidden2.Width = 0;
        //    hidden3.Visibility = Visibility.Hidden;
        //    hidden3.Width = 0;
        //    //hidden4.Visibility = Visibility.Hidden;
        //    //hidden4.Width = 0;
        //    // this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\nguye\Desktop\DoAn\DoAn\Image\BackGround.jpg")));
        //}
        //private void ShowView()
        //{
        //    hidden1.Visibility = Visibility.Visible;
        //    hidden1.Width = Double.NaN;
        //    hidden2.Visibility = Visibility.Visible;
        //    hidden2.Width = Double.NaN;
        //    hidden3.Visibility = Visibility.Visible;
        //    hidden3.Width = Double.NaN;
        //    //hidden4.Visibility = Visibility.Visible;
        //    //hidden4.Width = Double.NaN;
        //    // this.Background = new SolidColorBrush(Color.FromRgb(46,46,46));
        //}

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
                //HidenView();
                //hidden1.Width = Double.NaN;
                info.Visibility = Visibility.Visible;
                info.IdNguoiDung = Loged;
                UserControlView.Children.Add(info);
            }
        
            else
            {
               // HidenView();
                //hidden1.Width = Double.NaN;
                login.Visibility = Visibility.Visible;
                UserControlView.Children.Add(login);
            }
        }
   
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
            //HidenView();
            UserControlView.Children.Add(Settings);

        }

       
      

        //Button click quay luoi
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlView.Children.Count != 0)
            {
                UserControlView.Children.RemoveAt(UserControlView.Children.Count - 1);
                //ShowView();
                //  LoadSP();
            }
        }
        private void CaiDat()
        {
            using (var BL = new BanLapTopEntities())
            {
                this.FontFamily = new FontFamily((from i in BL.CaiDat
                                                  select i.font).SingleOrDefault());

                if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Dark")
                {
                    this.Background = new SolidColorBrush(Color.FromRgb(46, 46, 46));
                }
                else if ((from i in BL.CaiDat select i.Back).SingleOrDefault() == "Light")
                {
                    this.Background = Brushes.WhiteSmoke;
                }
            
                if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Full")
                {
                    this.WindowStyle = WindowStyle.None;
                }
                else if ((from i in BL.CaiDat select i.FullScreen).SingleOrDefault() == "Windows")
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }

    }
}
