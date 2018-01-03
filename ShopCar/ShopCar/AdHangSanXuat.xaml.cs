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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for HangSanXuat.xaml
    /// </summary>
    public partial class AdHangSanXuat : UserControl
    {
        public AdHangSanXuat()
        {
            InitializeComponent();
        }

        
        private void Load()
        {
            using (var BLT = new BanLapTopEntities())
            {

                var Pro = (from h in BLT.HangSanXuats
                           where h.ConKinhDoanh != false
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void ListGioHang_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private bool ConKinhDoanh(int ID)
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                int C = (from i in BH.SanPhams
                         where i.MaHangSX == ID && i.ConKinhDoanh != false
                         select i).Count();

                if (C > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            int ID = (ListGioHang.SelectedItem as HangSanXuat).MaHangSX;
            if (ConKinhDoanh(ID))
            {
                MessageBox.Show("Vẫn Còn Sản Phẩm Thuộc Hãng Này => Không Thể Xóa", "Delete Selected", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if (MessageBox.Show("Are you sure ?", "Delete Selected", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                   
                    using (var BH = new Models.BanLapTopEntities())
                    {
                        var sql = BH.HangSanXuats.Where(m => m.MaHangSX == ID).Single() as HangSanXuat;
                        sql.ConKinhDoanh = false;
                        BH.SaveChanges();

                    }
                    Load();
                }
                catch (Exception)
                {
                    MessageBox.Show("Vẫn Còn Sản Phẩm Thuộc Hãng Này => Không Thể Xóa", "Delete Selected", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

            }
        }


        string DuongDan = "";
        private void btnBrowe_Click(object sender, RoutedEventArgs e)
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
                Img.Source = bmp;
            }
        }

        private string LayDuoi(string t)
        {
            int index = t.LastIndexOf('.');
            t = t.Substring(index + 1);
            return t;
        }

        private int LayMaHSX()
        {
            using (var BanHang = new Models.BanLapTopEntities())
            {
                return (from i in BanHang.HangSanXuats
                        select i.MaHangSX).Max() + 1;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || DuongDan == "")
            {
                MessageBox.Show("Chưa Điền Đầy Đủ Thông Tin", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                // string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ContactImages\\";
                string folderpath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory) + "\\Image\\";
                string FileName = txtName.Text + "." + LayDuoi(DuongDan);
                if (!Directory.Exists(folderpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderpath);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                string filePath = folderpath + System.IO.Path.GetFileName(FileName);


                var HSX = new HangSanXuat { MaHangSX = LayMaHSX(), TenHangSX = txtName.Text, Logo = @"pack://siteoforigin:,,,/Image\" + FileName };
                using (var BanHang = new Models.BanLapTopEntities())
                {
                    BanHang.HangSanXuats.Add(HSX);
                    if (BanHang.SaveChanges() > 0)
                    {


                        if (!File.Exists(filePath))
                        {
                            System.IO.File.Copy(DuongDan, filePath, true);
                        }

                        MessageBox.Show("Success!");

                        Img.Source = null;
                        txtUri.Clear();
                        txtName.Clear();
                        Load();
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
