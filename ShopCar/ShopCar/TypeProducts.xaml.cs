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

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for TypeProducts.xaml
    /// </summary>
    public partial class TypeProducts : UserControl
    {
        public TypeProducts()
        {
            InitializeComponent();
        }

        private void Load()
        {
            using (var BLT = new BanLapTopEntities())
            {

                var Pro = (from h in BLT.LoaiSanPhams
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
                         where i.MaLoaiSP == ID && i.ConKinhDoanh!=false
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
            int ID = (ListGioHang.SelectedItem as LoaiSanPham).MaLoaiSP;
            if (ConKinhDoanh(ID))
            {
                MessageBox.Show("Vẫn Còn Sản Phẩm Thuộc Loại Này => Không Thể Xóa", "Delete Selected", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if (MessageBox.Show("Are you sure ?", "Delete Selected", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                   
                    using (var BH = new Models.BanLapTopEntities())
                    {
                        var sql = BH.LoaiSanPhams.Where(m => m.MaLoaiSP == ID).Single() as LoaiSanPham;
                        sql.ConKinhDoanh = false;
                        BH.SaveChanges();

                    }
                    Load();
                }
                catch (Exception)
                {
                    MessageBox.Show("Vẫn Còn Sản Phẩm Thuộc Loại Này => Không Thể Xóa", "Delete Selected", MessageBoxButton.OK, MessageBoxImage.Stop);

                }
              
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            LoaiSanPham D = ListGioHang.SelectedItem as LoaiSanPham;
            if (D.TenLoaiSP.Length <= 5)
            {
                MessageBox.Show("Loại Sản Phẩm Chưa Nhập hoặc không chính xác", "?????", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {


                if (MessageBox.Show("Are you sure ?", "Save Selected", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int ID = (ListGioHang.SelectedItem as LoaiSanPham).MaLoaiSP;
                    using (var BH = new Models.BanLapTopEntities())
                    {
                        var sql = BH.LoaiSanPhams.Where(m => m.MaLoaiSP == ID).Single() as LoaiSanPham;
                        sql.TenLoaiSP = D.TenLoaiSP;
                        BH.SaveChanges();

                    }
                    Load();
                }
            }
        }


        private int GetMaLoaiSP()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                return (from i in BH.LoaiSanPhams
                        select i.MaLoaiSP).Max() + 1;
            }
        } 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtAdd.Text.Length <= 5)
            {
                MessageBox.Show("Loại Sản Phẩm Chưa Nhập hoặc không chính xác", "?????", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                using (var BH = new Models.BanLapTopEntities())
                {

                    var sql = new LoaiSanPham();
                    sql.MaLoaiSP = GetMaLoaiSP();
                    sql.TenLoaiSP = txtAdd.Text;
                    BH.LoaiSanPhams.Add(sql);
                    BH.SaveChanges();//lưu thay doi
                    txtAdd.Clear();

                }
                Load();
            }
        }
    }
}