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
using System.Windows.Shapes;

namespace ShopCar.Views
{
    /// <summary>
    /// Interaction logic for UpDown.xaml
    /// </summary>
    public partial class UpDown : Window
    {
        public UpDown()
        {
            InitializeComponent();
        }

        public int MaSP { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (udSL.Value < 0)
            {
                MessageBox.Show("Why is " + udSL.Value+" ?", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var BH = new Models.BanLapTopEntities())
                {
                    var sql = BH.SanPhams.Where(m => m.MaSP == MaSP).Single() as SanPham;
                    sql.SoLuongTon +=(int)udSL.Value;
                    BH.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
