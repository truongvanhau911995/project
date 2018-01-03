using eisiWare;
using ShopCar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for GioHang.xaml
    /// </summary>
    public partial class GioHang : UserControl
    {
        BanLapTopEntities BLT;
        public GioHang()
        {
            InitializeComponent();

        }
        public delegate void PassData(string i);
        public event PassData Cart;
        public string IdKhachHang { get; set; }
        private void Load()
        {
            BLT = new BanLapTopEntities();

            var GioHang = (from h in BLT.DonHangTemps
                           select h);

            if (GioHang.Count() == 0)
            {
                ListGioHang.ItemsSource = null;
                txtSLSP.Text = "0";
                txtTTien.Text = "0 VNĐ";
            }
            else
            {
                ListGioHang.ItemsSource = GioHang.ToList();

                txtSLSP.Text = (from h in BLT.DonHangTemps
                                select h.SoLuongMua).Sum().ToString();

                txtName.Text = (from h in BLT.DonHangTemps
                                select h.TenKhachHang).FirstOrDefault();

                var Okane = (from h in BLT.DonHangTemps
                             select h.ThanhTien).Sum().ToString();

                txtTTien.Text = string.Format("{0:0,0 VNĐ}", double.Parse(Okane));

            }

            var DonHang = (from h in BLT.HoaDons
                           where h.MaKhachHang == IdKhachHang
                           orderby h.NgayLap descending
                           select h);

            if (DonHang.Count() == 0)
            {
                ListDonHang.ItemsSource = null;
                ListDonHang.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListDonHang.ItemsSource = DonHang.ToList();
                ListDonHang.Visibility = Visibility.Visible;
            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
            expd.IsExpanded = true;
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Products", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int ID = (ListGioHang.SelectedItem as DonHangTemp).STT;
                using (var BH = new Models.BanLapTopEntities())
                {
                    var sql = BH.DonHangTemps.Where(m => m.STT == ID).Single() as DonHangTemp;
                    BH.DonHangTemps.Remove(sql);
                    BH.SaveChanges();

                }
                Load();
            }

        }

        private void ListGioHang_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            DonHangTemp D = ListGioHang.SelectedItem as DonHangTemp;

            using (var BH = new Models.BanLapTopEntities())
            {
                var sql = BH.DonHangTemps.Where(m => m.MaSP == D.MaSP).Single() as DonHangTemp;
                sql.SoLuongMua = D.SoLuongMua;
                sql.ThanhTien = D.SoLuongMua * D.GiaSP;
                BH.SaveChanges();//lưu thay doi

                if (KiemTraConHang(D.MaSP) == false)
                {
                    MessageBox.Show("LapTop " + D.TenSP + " Số Tồn Kho < " + D.SoLuongMua + " Cái", "Không Đủ Mặt Hàng", MessageBoxButton.OK, MessageBoxImage.Hand);
                }

                Load();
            }


        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Cart?.Invoke("1");
        }


        private ChiTietHoaDon LoopData(int STT)
        {
            var CT = new ChiTietHoaDon();
            using (var BH = new Models.BanLapTopEntities())
            {
                var GioHang = (from h in BLT.DonHangTemps
                               where h.STT == STT
                               select h);

                foreach (var Temp in GioHang)
                {
                    CT.MaKhacHang = Temp.MaKhacHang;
                    CT.TenKhachHang = Temp.TenKhachHang;
                    CT.MaDonHang = Temp.MaDonHang;
                    CT.MaSP = Temp.MaSP;
                    CT.TenSP = Temp.TenSP;
                    CT.SoLuongMua = Temp.SoLuongMua;
                    CT.GiaSP = Temp.GiaSP;
                    CT.HinhSP = Temp.HinhSP;
                    CT.ThanhTien = Temp.ThanhTien;
                }
            }

            return CT;
        }

        private int SoLuongMua(int MaSp)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                return (from i in BH.DonHangTemps
                        where i.MaSP == MaSp
                        select i.SoLuongMua).SingleOrDefault();
            }
        }
        private bool KiemTraConHang(int MaSP)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                if ((from i in BH.DonHangTemps
                     where i.MaSP == MaSP
                     select i.SoLuongMua).SingleOrDefault() > (from i in BH.SanPhams
                                                               where i.MaSP == MaSP
                                                               select i.SoLuongTon).SingleOrDefault())
                {
                    return false;
                }

            }
            return true;
        }
        private void UpdateSoLuongSP(int MaSP)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                var sql = BH.SanPhams.Where(m => m.MaSP == MaSP).Single() as SanPham;
                int SLB = SoLuongMua(MaSP);
                sql.SoLuongBan = sql.SoLuongBan + SLB;
                sql.SoLuongTon = sql.SoLuongTon - SLB;

                BH.SaveChanges();//lưu thay doi
            }
        }


        private int LayMaSp(int STT)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                return (from i in BH.DonHangTemps
                        where i.STT == STT
                        select i.MaSP).SingleOrDefault();
            }
        }

        private List<int> LaySTT()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                return (from i in BH.DonHangTemps
                        select i.STT).ToList();
            }
        }
        private void btnthanhtoan_Click(object sender, RoutedEventArgs e)
        {
            if (ListGioHang.Items.Count > 0)
            {
                using (var BH = new Models.BanLapTopEntities())
                {
                    foreach (var i in LaySTT())
                    {
                        if (KiemTraConHang(LayMaSp(i)) == false)
                        {
                            var Name = (from lt in BH.DonHangTemps
                                        where lt.STT == i
                                        select lt.TenSP).SingleOrDefault();
                            var SL = (from lt in BH.DonHangTemps
                                      where lt.STT == i
                                      select lt.SoLuongMua).SingleOrDefault();
                            MessageBox.Show("LapTop " + Name + " Số Tồn Kho < " + SL + " Cái", "Không Đủ Mặt Hàng Cần Mua", MessageBoxButton.OK, MessageBoxImage.Hand);

                            return;
                        }

                    }

                    var sql = new HoaDon();

                    sql.MaKhachHang = (from t in BH.DonHangTemps
                                       select t.MaKhacHang).FirstOrDefault();
                    sql.NgayLap = DateTime.Now;
                    sql.TongTien = Convert.ToDecimal((from h in BLT.DonHangTemps
                                                      select h.ThanhTien).Sum().ToString());

                    sql.DaThanhToan = false;

                    BH.HoaDons.Add(sql);
                    BH.SaveChanges();//lưu thay doi


                    foreach (var i in LaySTT())
                    {
                        using (var BL = new Models.BanLapTopEntities())
                        {
                            var ChiTiet = new ChiTietHoaDon();
                            ChiTiet = LoopData(i);
                            BL.ChiTietHoaDons.Add(ChiTiet);

                            BL.SaveChanges();//lưu thay doi
                            UpdateSoLuongSP(LayMaSp(i));
                        }

                    }

                    BH.Database.ExecuteSqlCommand("TRUNCATE TABLE DonHangTemp");
                    Load();
                    MessageBox.Show("Thanh Toán Thành Công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Cart?.Invoke("2");
                }
            }
        }


        void CTHHoaDon(int i)
        {
            if (i == 1)
            {
                Userview.Children.Clear();
                GioHang ad = new GioHang();
                ad.IdKhachHang = IdKhachHang;
                Userview.Children.Add(ad);
                Load();
                
            }
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            int ID = (ListDonHang.SelectedItem as HoaDon).MaHoaDon;
            AdChiTietHoaDon Pro = new AdChiTietHoaDon();
            Pro.ChiTietOder += new AdChiTietHoaDon.PassData(CTHHoaDon);
            Pro.MaHoaDon = ID;
            Userview.Children.Clear();
            Userview.Children.Add(Pro);
        }
    }
}
