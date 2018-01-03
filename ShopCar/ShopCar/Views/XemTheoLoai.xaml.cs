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
using System.Linq.Dynamic;
using System.Windows.Threading;

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for XemTheoLoai.xaml
    /// </summary>
    public partial class XemTheoLoai : UserControl
    {
        BanLapTopEntities BLT;
        DispatcherTimer TimeLoad;
        IQueryable<SanPham> SourceFill;
        public string DieuKien { get; set; }
      
        public string Tile { get; set; }
        public delegate void PassData(int i ,int j);
        public event PassData EventXemTheoLoai;
        public XemTheoLoai()
        {
            InitializeComponent();
          //  var db = this.FindResource("dbForWd") as Models.Page;
          //  db.CurPage = 1;
        }
        List<SanPham> GetSearchQuery(int curPage, int pageSize, out int totalPage)
        {
            IQueryable<SanPham> q = SourceFill;

            totalPage = (int)Math.Ceiling(q.Count() * 1.0 / pageSize);
            ListHot.ItemsSource= q.OrderBy(p=>p.MaSP).Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            return q.OrderBy(p => p.MaSP).Skip((curPage - 1) * pageSize).Take(pageSize).ToList(); 
        }

        private void ButtunPage(int total)
        {
            int totalPage = total;
            List<Models.PageButton> ListBtn = new List<PageButton>();
            PageButton t ;
            for (int i = 0; i < totalPage; i++)
            {
                t = new PageButton();
                t.I = i + 1;
                ListBtn.Add(t);
            }
            ListButton.ItemsSource = ListBtn;

        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
           // var db = this.FindResource("dbForWd") as Models.Page;
           // int temp;
           // int totalPage;
            //if (db.CurPage > 1 && int.TryParse(btnInPage.Text, out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            //{
            //    db.CurPage--;
            //}
          //  else { return; }
          //  db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
           // db.TotalPage = totalPage;
            //ListButton.SelectedIndex = db.CurPage - 1;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           // var db = this.FindResource("dbForWd") as Models.Page;

            //int totalPage;
            //int temp;
            //if (db.CurPage < db.TotalPage && int.TryParse(btnInPage.Text,out temp) && temp <= Convert.ToInt32(txtTotal.Text) && temp >= 1)
            //{
            //    db.CurPage++;
            //}
            //else { return; }
           // db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
           // db.TotalPage = totalPage;
           // ListButton.SelectedIndex = db.CurPage - 1;
        }

        private int LayMaSP(object sender, RoutedEventArgs e)
        {

            Button temp = sender as Button;
            SanPham D = temp.DataContext as SanPham;
            int Id = D.MaSP;
            BLT = new BanLapTopEntities();
            int NumberView = (from h in BLT.SanPhams
                              where h.MaSP == Id

                              select h.LuotXem).SingleOrDefault() + 1;

            BLT = new BanLapTopEntities();
            var sql = BLT.SanPhams.Where(m => m.MaSP == Id).FirstOrDefault();
            sql.LuotXem = NumberView;
            BLT.SaveChanges();//lưu thây đổi lượt xem
            return Id;
        }

        private void txtXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            EventXemTheoLoai?.Invoke(LayMaSP(sender,e),1);
           
        }

        private void Mua_Click(object sender, RoutedEventArgs e)
        {
            EventXemTheoLoai?.Invoke(LayMaSP(sender, e), 2);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            bool FA = false;
            TimeLoad = new DispatcherTimer();
            TimeLoad.Tick += new EventHandler(TimeLoad_Clock);
            TimeLoad.Interval = new TimeSpan(0, 0, 1);
            TimeLoad.Start();

            txtTile.Text = "Kết Quả Tìm Kiếm Theo \"";

            if (!string.IsNullOrEmpty(DieuKien))
            {
                var BLT = new BanLapTopEntities();
                var DSX = BLT.SanPhams
                               .Where(DieuKien)
                                .Where("ConKinhDoanh != false");

                SourceFill = DSX;

                //var db = this.FindResource("dbForWd") as Models.Page;
                //int totalPage;
                //db.CurPage = 1;
                //db.Products= GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
                //db.TotalPage = totalPage;
                //ButtunPage(totalPage);
               

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Tile))
                {
                 
                    
                    decimal Gold = 5000000;
                    decimal search;
                    if (decimal.TryParse(Tile, out search))
                    {
                        var BH = new Models.BanLapTopEntities();

                        var sql = (from timkiem in BH.SanPhams
                                   where timkiem.GiaSP >= search
                                   where timkiem.GiaSP <= search + Gold
                                   where timkiem.ConKinhDoanh != false
                                   select timkiem);

                            SourceFill = sql;

                            var db = this.FindResource("dbForWd") as Models.Page;
                            int totalPage;
                            db.CurPage = 1;
                            db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
                            db.TotalPage = totalPage;
                            ButtunPage(totalPage);

                        decimal tem = search + Gold;
                        txtTile.Text += " Giá Từ " + Tile + " VNĐ ー＞ " + tem;
                        FA = true;
                    }
                    else
                    {
                        var BH = new Models.BanLapTopEntities();
                        
                            var sql = (from timkiem in BH.SanPhams
                                       from tk in BH.LoaiSanPhams
                                       from tk1 in BH.HangSanXuats
                                       where (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && timkiem.TenSP.Contains(Tile))
                                       || (timkiem.MaLoaiSP == tk.MaLoaiSP && timkiem.MaHangSX == tk1.MaHangSX && tk.TenLoaiSP.Contains(Tile))
                                       || (timkiem.MaHangSX == tk1.MaHangSX && timkiem.MaLoaiSP == tk.MaLoaiSP && tk1.TenHangSX.Contains(Tile))
                                       where timkiem.ConKinhDoanh != false
                                       select timkiem);

                            SourceFill = sql;

                            var db = this.FindResource("dbForWd") as Models.Page;
                            int totalPage;
                            db.CurPage = 1;
                            db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
                            db.TotalPage = totalPage;
                            ButtunPage(totalPage);

                    }
                }
            }
            if (FA == true)
            {
                txtTile.Text += " VNĐ\"";
            }
            else
            {
                txtTile.Text += Tile + "\"";
            }
          

        }


        /// <summary>
        /// Tim Tên 1 Element in DataTemplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
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
        private void TimeLoad_Clock(object sender, EventArgs e)
        {
            foreach (var textblock in FindVisualChildren<TextBlock>(ListHot))
            {
                if (textblock.Name == "txtMoTaNgan")
                {
                    textblock.Text = textblock.Text.Replace("\\r\\n", "\r\n");
                }
            }

           

        }

        private void btnInPage_KeyDown(object sender, KeyEventArgs e)
        {
            
            //int n;
            //if (!int.TryParse(btnInPage.Text, out n))
            //{
            //    n = 1;
            //}
            //else if (n <= Convert.ToInt32(txtTotal.Text) && n >= 1) 
            //{
            //    var db = this.FindResource("dbForWd") as Models.Page;

            //    int totalPage;

            //    db.CurPage = n;

            //    db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
            //    db.TotalPage = totalPage;
            //    ListButton.SelectedIndex = n - 1;
            //}

        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button;
            
            PageButton D = temp.DataContext as PageButton;
            int Id = D.I;
            var db = this.FindResource("dbForWd") as Models.Page;
            ListButton.SelectedIndex = Id - 1;
            int totalPage;

            db.CurPage = Id;

            db.Products = GetSearchQuery(db.CurPage, Models.Page.PageSize, out totalPage);
            db.TotalPage = totalPage;
            
        }
    }
}
