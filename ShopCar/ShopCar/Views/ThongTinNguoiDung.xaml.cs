using Microsoft.Win32;
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
using System.IO;
using ShopCar.Models;
using System.Text.RegularExpressions;

namespace ShopCar.Views
{
    /// <summary>
    /// Interaction logic for ThongTinNguoiDung.xaml
    /// </summary>
    public partial class ThongTinNguoiDung : UserControl
    {
        Models.BanLapTopEntities BLT = new Models.BanLapTopEntities();
        public ThongTinNguoiDung()
        {
            InitializeComponent();
        }

        private static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        private static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        public delegate void PassData(string s);
        public event PassData InfoUser;
        public string IdNguoiDung { get; set; }

        string DuongDan="";
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Title = "Select a picture";
            FileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
           
           
            if (FileDialog.ShowDialog() == true)
            {
                DuongDan = FileDialog.FileName;
                BitmapImage bmp = new BitmapImage(new Uri(DuongDan));
                ImgAvatar.Source = bmp;
            }
            
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

     
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string Hoten = txtName.Text;
            string sex = txtSex.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
           

            using (Models.BanLapTopEntities db = new Models.BanLapTopEntities())
            {

                var mh = db.TaiKhoans.Where(m => m.IdNguoiDung == txtID.Text).Single() as TaiKhoan;
                if (mh == null)
                {
                    MessageBox.Show("Fail!");
                    return;
                }

                if (SinhNhat.SelectedDate == null||string.IsNullOrEmpty(email)|| string.IsNullOrEmpty(Hoten)|| string.IsNullOrEmpty(sex)|| string.IsNullOrEmpty(diachi)|| string.IsNullOrEmpty(sdt))
                {
                   errorInfo.Text=("Chưa nhập đầy đủ thông tin!");
                    return;
                }
                if (txtSex.Text!="Nam" && txtSex.Text!="Nữ")
                {
                    errorInfo.Text = ("Giới tình phải là [Nam] Hoặc [Nữ]!");
                    txtSex.Focus();
                    return;
                }
                if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errorInfo.Text = ("Email không hợp lệ");
                    txtEmail.Focus();
                    return;
                }
                if (sdt.Length > 12 || sdt.Length < 10) 
                {
                    errorInfo.Text = ("SĐT Phải từ 10 đến 11 số");
                    txtSDT.Focus();
                    return;
                }
                long sdtparse;
                if (!long.TryParse(txtSDT.Text, out sdtparse))
                {
                    errorInfo.Text = ("SĐT không hợp lệ");
                    txtSDT.Focus();
                    return;
                }

                else
                {
                    mh.Email = email;
                    mh.GioiTinh = sex;
                    mh.HoTen = Hoten;
                    mh.DiaChi = diachi;
                    mh.SoDT = sdt;
                    mh.NgaySinh = SinhNhat.SelectedDate.Value;
                    if (File.Exists(DuongDan))
                    {
                        FileStream Stream = new FileStream(DuongDan, FileMode.Open, FileAccess.Read);
                        StreamReader Reader = new StreamReader(Stream);
                        Byte[] ImgData = new Byte[Stream.Length - 1];
                        Stream.Read(ImgData, 0, (int)Stream.Length - 1);
                        mh.Avatar = ImgData;
                    }

                    if (db.SaveChanges() > 0)
                    {
                        MessageBox.Show("Done!");
                        IsReadOnlyTextBox(true);
                        errorInfo.Text = ("");
                        InfoUser?.Invoke("1");
                    }     
                }
            }

           
        }


        private void LoadInfo()
        {
            var info = (from h in BLT.TaiKhoans
                        where h.IdNguoiDung == txtID.Text
                        select h);

            byte[] b = (from h in BLT.TaiKhoans
                      where h.IdNguoiDung == txtID.Text
                      select h.Avatar).Single();

            DataContext = info.ToList();
            
            if (b != null)
            {
                ImgAvatar.Source = ToImage(b);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtID.Text = IdNguoiDung;
            LoadInfo();

        }

        private void IsReadOnlyTextBox(bool t)
        {
            txtSex.IsReadOnly = t;
            txtDiaChi.IsReadOnly = t;
            txtEmail.IsReadOnly = t;
            txtSDT.IsReadOnly = t;
            txtName.IsReadOnly = t;
        }
    
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            InfoUser?.Invoke("2");
            Expan.IsExpanded = false;
            Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Checked(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
            IsReadOnlyTextBox(false);
        }

        private void btnEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            IsReadOnlyTextBox(true);
        }

        private void SavePasswd_Click(object sender, RoutedEventArgs e)
        {
            string oldpass = md5(pOldPass.Password);
            string newpass = md5(pNewPass.Password);
            string ConfigPass =md5(pPass.Password);

            using (Models.BanLapTopEntities db = new Models.BanLapTopEntities())
            {

                var mh = db.TaiKhoans.Where(m => m.IdNguoiDung == txtID.Text).Single() as TaiKhoan;
                if (mh == null)
                {
                    MessageBox.Show("Fail!");
                    return;

                }
               
                if (string.IsNullOrEmpty(pOldPass.Password) || string.IsNullOrEmpty(pNewPass.Password) || string.IsNullOrEmpty(pPass.Password))
                {
                    error.Content = ("Not fully entered!");
                    return;
                }
                else
                {
                    var password = (from h in BLT.TaiKhoans
                                    where h.IdNguoiDung == txtID.Text
                                    select h.PassND).SingleOrDefault();

                    if (oldpass != password)
                    {
                        error.Content = "Wrong password";
                        return;
                    }
                    if (newpass != ConfigPass)
                    {
                        error.Content = "Confirm password must be same as password.";
                        return;
                    }
                    else
                    {
                        mh.PassND = newpass;
                        if (db.SaveChanges() > 0)
                        {
                            MessageBox.Show("Done!");
                            error.Content = "";
                            Expan.IsExpanded = false;
                            
                        }
                    }

                }
               
            }

        }
    }
}
