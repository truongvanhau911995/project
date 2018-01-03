using Microsoft.Win32;
using ShopCar.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddSP_EditSP.xaml
    /// </summary>
    public partial class AddSP_EditSP : Window
    {
        public AddSP_EditSP()
        {
            InitializeComponent();
            Load();
        }

        string DuongDan = "";
        private void btnBrowes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Title = "Select a picture";
            FileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";



            if (FileDialog.ShowDialog() == true)
            {
                DuongDan = FileDialog.FileName;
                txtUri.Text = DuongDan;

                BitmapImage bmp = new BitmapImage(new Uri(DuongDan));
                Pictur.Source = bmp;
            }
        }

        private string LayDuoi(string t)
        {
            int index = t.LastIndexOf('.');
            t = t.Substring(index + 1);
            return t;
        }

        private void Load()
        {
            using (var BH = new BanLapTopEntities())
            {
                var LoaiSP = (from i in BH.LoaiSanPhams
                              where i.ConKinhDoanh != false
                              select new { i.MaLoaiSP ,i.TenLoaiSP} );

                cbLoaiSP.ItemsSource = LoaiSP.ToList();

                var HangSX = (from i in BH.HangSanXuats
                              where i.ConKinhDoanh != false
                              select new { i.MaHangSX, i.TenHangSX });

                cbHangSX.ItemsSource = HangSX.ToList();
            }
        }
       

        private bool Compelete()
        {
            if (txtUri.Text == "")
            {
                sError.Content = "Chưa Có Hình Ảnh Của Sản Phẩm";
                txtUri.Focus();
                return false;
            }
            //Name
            if (txtNameSP.Text == "")
            {
                sError.Content = "Cần Nhập Tên Sản Phẩm";
                txtNameSP.Focus();
                return false;
            }

            //gia
            if (txtGiaSP.Text == "")
            {
                sError.Content = "Cần Nhập Giá Sản Phẩm";
                txtGiaSP.Focus();
                return false;
            }
            decimal Gia;
            if (!decimal.TryParse(txtGiaSP.Text,out Gia))
            {
                sError.Content = "Cần Nhập Lại Giá Sản Phẩm";
                txtGiaSP.Focus();
                return false;
            }


            if (txtMoTaNgan.Text == "")
            {
                txtMoTaNgan.Focus();
                sError.Content = "Cần Nhập Mô Tả";
                return false;
            }
            if (txtCauHinh.Text == "")
            {
                sError.Content = "Cần Nhập Cấu Hình";
                txtCauHinh.Focus();
                return false;
            }
            if (txtChiTiet.Text == "")
            {
                sError.Content = "Cần Nhập Chi Tiết Sản Phẩm";
                txtChiTiet.Focus();
                return false;
            }
            if (txtXuatSu.Text == "")
            {
                sError.Content = "Xuất Sứ ???";
                txtXuatSu.Focus();
                return false;
            }
            if (cbLoaiSP.Text == "")
            {
                sError.Content = " Loại Sản Phẩm ???";
                cbLoaiSP.Focus();
                return false;
            }
            if (cbHangSX.Text == "")
            {
                sError.Content = "Hãng Sản Xuất ???";
                cbHangSX.Focus();
                return false;
            }
            if (udNhapKho.Value < 0)
            {
                sError.Content = "Số Hàng Nhập Kho < 0 ????";
                udNhapKho.Focus();
                return false;
            }

            return true;
        }

        private void Clears()
        {
            txtCauHinh.Clear();
            txtChiTiet.Clear();
            txtGiaSP.Clear();
            txtMoTaNgan.Clear();
            txtNameSP.Clear();
            txtUri.Clear();
            txtXuatSu.Clear();
            BitmapImage bmp = new BitmapImage(new Uri(@"pack://application:,,,/Image\Lap.png"));
            Pictur.Source = bmp;

        }
        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {

            if (Compelete())
            {
                // string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ContactImages\\";
                string folderpath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory) + "\\Images\\";
                string FileName = txtNameSP.Text + "." + LayDuoi(DuongDan);
                if (!Directory.Exists(folderpath))
                {
                    DirectoryInfo di =  Directory.CreateDirectory(folderpath);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                string filePath = folderpath + System.IO.Path.GetFileName(FileName);

                string MoTaNgan = txtMoTaNgan.Text;
                string CauHinh = txtCauHinh.Text;
                string ChiTiet = txtChiTiet.Text;
                var NewSP = new SanPham { TenSP = txtNameSP.Text.Trim(), GiaSP = Convert.ToDecimal(txtGiaSP.Text), LuotXem = 0, SoLuongBan = 0, SoLuongTon = (int)udNhapKho.Value, NgayNhapKho = DateTime.Now, MoTaNgan = @MoTaNgan, CauHinh = @CauHinh, MoTa = @ChiTiet, XuatXu = txtXuatSu.Text.Trim(), MaLoaiSP = Convert.ToInt32(cbLoaiSP.SelectedValue), MaHangSX = Convert.ToInt32(cbHangSX.SelectedValue), HinhSP = @"pack://siteoforigin:,,,/Images\" + FileName };
                using (var BanHang = new Models.BanLapTopEntities())
                {
                    BanHang.SanPhams.Add(NewSP);
                    if (BanHang.SaveChanges() > 0)
                    {


                        if (!File.Exists(filePath))
                        {
                            System.IO.File.Copy(DuongDan, filePath, true);
                        }

                        MessageBox.Show("Success!");
                        Clears();
                    }
                    else
                    {
                        MessageBox.Show("Error Please record");
                    }
                }
            }
        }
    }
}
