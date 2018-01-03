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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace ShopCar.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView :  Microsoft.Office.Interop.Excel.Window
    {
        public Excel.Application Application
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public XlCreator Creator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        dynamic Excel.Window.Parent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Range ActiveCell
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Chart ActiveChart
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Pane ActivePane
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public dynamic ActiveSheet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public dynamic Caption
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayFormulas
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayGridlines
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayHeadings
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayHorizontalScrollBar
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayOutline
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool _DisplayRightToLeft
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayVerticalScrollBar
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayWorkbookTabs
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayZeros
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool EnableResize
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool FreezePanes
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int GridlineColor
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public XlColorIndex GridlineColorIndex
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Index
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Left
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string OnWindow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Panes Panes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Range RangeSelection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int ScrollColumn
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int ScrollRow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Sheets SelectedSheets
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public dynamic Selection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Split
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int SplitColumn
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double SplitHorizontal
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int SplitRow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double SplitVertical
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double TabRatio
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double Top
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public XlWindowType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double UsableHeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double UsableWidth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Range VisibleRange
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int WindowNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public XlWindowState WindowState
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public dynamic Zoom
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public XlWindowView View
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayRightToLeft
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public SheetViews SheetViews
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public dynamic ActiveSheetView
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayRuler
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AutoFilterDateGrouping
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool DisplayWhitespace
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Hwnd
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ReportView()
        {
            InitializeComponent();
        }


        public void ComboYear()
        {
            using (var BH = new Models.BanLapTopEntities())
            {
                var ListYear = (from h in BH.HoaDons
                                select new
                                {
                                    Years = (int?)h.NgayLap.Year
                                }).Distinct();

                cbYear.ItemsSource = ListYear.ToList();

            }

        }
        private void Load()
        {


        }

        int Nam = DateTime.Now.Year;
        private void btnFiter_Click(object sender, RoutedEventArgs e)
        {
            if (cbYear.Text != "")
            {
                Nam = Convert.ToInt32(cbYear.Text);
            }

            txtTile.Text = "Thống Kê Doanh  Theo Năm: " + Nam;
            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from hd in BH.HoaDons
                          where hd.NgayLap.Year == Nam
                          select hd);
                ListDoanhThu.ItemsSource = KQ.ToList();
              
            }

            txtTile2.Text = "Lịch Sử Mua Hàng Theo Năm: " + Nam;
            using (var BH = new Models.BanLapTopEntities())
            {
                var KQ = (from s in BH.ChiTietHoaDons
                          from hd in BH.HoaDons
                          where
                            hd.NgayLap.Year == Nam &&
                            hd.MaHoaDon == s.MaDonHang
                         select s);

                ListLichSu.ItemsSource = KQ.ToList();
            }
        }

        public dynamic Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        private void cbYear_Loaded(object sender, RoutedEventArgs e)
        {
          
            ComboYear();

            btnFiter_Click(sender, e);
            txtTile.Text = "Thống Kê Doanh Thu  Theo Năm: " + Nam ;
            txtTile2.Text = "Lịch Sử Mua Hàng Theo Năm: " + Nam ;
        }


        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < ListDoanhThu.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = ListDoanhThu.Columns[j].Header;
            }
            for (int i = 0; i < ListDoanhThu.Columns.Count; i++)
            {
                for (int j = 0; j < ListDoanhThu.Items.Count; j++)
                {
                    TextBlock b = ListDoanhThu.Columns[i].GetCellContent(ListDoanhThu.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }

            }
        }

        private void btnExcel2_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < ListLichSu.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = ListLichSu.Columns[j].Header;
            }
            for (int i = 0; i < ListLichSu.Columns.Count; i++)
            {
                for (int j = 0; j < ListLichSu.Items.Count; j++)
                {
                    TextBlock b = ListLichSu.Columns[i].GetCellContent(ListLichSu.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }

            }
        }
    }
}
