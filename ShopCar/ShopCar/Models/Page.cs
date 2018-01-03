using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Models
{
    class Page: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        List<SanPham> products;

        public List<SanPham> Products
        {
            get
            {
                return products;
            }

            set
            {
                if (value == products)
                {
                    return;
                }
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public static int PageSize = 6;
        int curPage;
        public int CurPage
        {
            get
            {
                return curPage;
            }

            set
            {
                if (value == curPage)
                {
                    return;
                }
                curPage = value;
                OnPropertyChanged("CurPage");
            }
        }

        int totalPage;
        public int TotalPage
        {
            get
            {
                return totalPage;
            }

            set
            {
                if (value == totalPage)
                {
                    return;
                }
                totalPage = value;
                OnPropertyChanged("TotalPage");
            }
        }

    }
}
