using ShopCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : UserControl
    {
        public DangKy()
        {
            InitializeComponent();
        }


        public delegate void PassData(int i);
        public event PassData Share;
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
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            Visibility = Visibility.Collapsed;
            Share?.Invoke(1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            textBoxUser.Clear();
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            Share?.Invoke(2);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Submit_Click(sender, e);
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUser.Text.Length == 0)
            {
                errormessage.Text = "Please Enter a Username ";
                textBoxUser.Focus();
                return;
            }
            else if (textBoxUser.Text.Length < 4)
            {
                errormessage.Text = "Please Enter a Username Length >= 5 character!";
                textBoxUser.Focus();
                return;
            }
            BanLapTopEntities BLT = new BanLapTopEntities();
            int DK = BLT.TaiKhoans.Where(m => m.IdNguoiDung == textBoxUser.Text).Count();
            if (DK > 0)
            {
                errormessage.Text = "The username already exists!";
                textBoxUser.Focus();
                return;
            }
            //----------
            if (textBoxLastName.Text.Length == 0)
            {
                errormessage.Text = "Please Enter at your full name !";
                textBoxLastName.Focus();
                return;
            }
            else if (textBoxLastName.Text.Length < 5)
            {
                errormessage.Text = "Enter a valid your name!";
                textBoxLastName.Focus();
                return;
            }
            
            //-------------
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Please Enter an email !";
                textBoxEmail.Focus();
                return;
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
                return;
            }
            //----------

            if (passwordBox1.Password.Length == 0)
            {
                errormessage.Text = "Please Enter password !";
                passwordBox1.Focus();
                return;
            }
            if (passwordBoxConfirm.Password.Length == 0)
            {
                errormessage.Text = "Please Enter Confirm password.";
                passwordBoxConfirm.Focus();
                return;
            }
            if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                errormessage.Text = "Confirm password must be same as password.";
                passwordBoxConfirm.Focus();
                return;
            }
            if (textBoxAddress.Text.Length == 0)
            {
                errormessage.Text = "Please Enter Address....";
                textBoxAddress.Focus();
                return;
            }

            string Username = textBoxUser.Text;
            string lastname = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string password = md5(passwordBox1.Password);
            string address = "";
            address = textBoxAddress.Text;

            errormessage.Text = "";

            var TK = new TaiKhoan { IdNguoiDung = Username, PassND = password, HoTen = lastname, Email = email, DiaChi = address, MaLoaiTK = 0 };
            using (var BanHang = new Models.BanLapTopEntities())
            {
                int n = BanHang.TaiKhoans.Where(m => m.IdNguoiDung == TK.IdNguoiDung).Count();
                if (n > 0)
                {
                    errormessage.Text = "Username is Exist";

                }
                else
                {

                    BanHang.TaiKhoans.Add(TK);
                    if (BanHang.SaveChanges() > 0)
                    {
                        MessageBox.Show("Success!");
                        Reset();
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
