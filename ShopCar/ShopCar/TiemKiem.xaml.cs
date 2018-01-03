using ShopCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TiemKiem.xaml
    /// </summary>
    public partial class TiemKiem : UserControl
    {
        ListCollectionView lcv;
        public TiemKiem()
        {
            InitializeComponent();

            var dc = new BanLapTopEntities();

            var sql = from p in dc.SanPhams
                      from c in dc.HangSanXuats
                      where c.MaHangSX == p.MaHangSX
                      select p;

            lst.ItemsSource = sql.ToList();
            lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(lst.ItemsSource);


        }

        private void btnF_Click(object sender, RoutedEventArgs e)
        {
            lcv.Filter = p => ((SanPham)p).GiaSP > decimal.Parse(txtPrice.Text);
        }

        private void btnDeleF_Click(object sender, RoutedEventArgs e)
        {
            if (lcv.Filter != null)
            {
                lcv.Filter = null;
            }
        }
        static int m = 0;
        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            m = (m + 1) % 3;
            if (m == 0)
            {
                lcv.SortDescriptions.Clear();
            }
            if (m == 1)
            {
                lcv.SortDescriptions.Add(new SortDescription("GiaSP", ListSortDirection.Descending));

            }

        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(lst.ItemsSource);
            view.GroupDescriptions.Add(new PropertyGroupDescription("MaHangSX"));
        }


        private void txtXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Mua_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
