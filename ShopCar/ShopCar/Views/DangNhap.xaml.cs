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

namespace ShopCar.Views
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : UserControl
    {
        Models.BanLapTopEntities LT = new Models.BanLapTopEntities();
        public DangNhap()
        {
            InitializeComponent();
        }


        public delegate void PassData(string s);
        public event PassData share;
        public event PassData _Registration;




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



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtName.Text;
            string Pass = txtPasswd.Password;
            Pass = md5(Pass);

            var ok = (from n in LT.TaiKhoans
                      where n.IdNguoiDung == Name && n.PassND == Pass
                      select n).FirstOrDefault();

            if (txtName.Text == "" && txtPasswd.Password == "")
            {
                errormessage.Text = "Chưa Nhập Tài Khoản Và Mật Khẩu";
            }
            else
            {
                if (txtName.Text != "" && txtPasswd.Password == "")
                {
                    errormessage.Text = "Chưa Nhập Mật Khẩu";
                }

                else if (txtName.Text != "" && txtPasswd.Password != "")
                {

                    if (ok != null)
                    {
                        share?.Invoke(ok.IdNguoiDung);
                        Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        errormessage.Text = "Sai Tài Khoản Hoặc Mật Khẩu";
                    }

                }

                else
                {
                    errormessage.Text = "Chưa Nhập Tài Khoản";
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            _Registration?.Invoke("1");
            Visibility = Visibility.Collapsed;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                txtName.Clear();
                txtPasswd.Clear();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            _Registration?.Invoke("2");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }
    }
}
