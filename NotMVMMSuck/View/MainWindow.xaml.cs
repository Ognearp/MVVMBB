using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using NotMVMMSuck.Data;
using NotMVMMSuck.Model;

namespace NotMVMMSuck.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,   INotifyPropertyChanged
    {

        private ObservableCollection<Product> productList;
        private ObservableCollection<Product> filterList;
        private string searchText;
        private int currentPage;
        private int itemonpage = 20;
        private bool orderbyDesign;
        private string selectType;
        private FilterItem selectSort;
        private Product selectProduct;
        private string pageDisplay;
        

        public Product SelectProduct
        {
            get => selectProduct;
            set
            {
                selectProduct = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Product> ProductList
        {
            get => productList;
            set
            {
                productList = value;
                OnPropertyChanged();

            }
        }

        public ObservableCollection<Product> FilterList
        {
            get => filterList;
            set
            {
                filterList = value;
                OnPropertyChanged();
            }
        }

        public string PageDisplay
        {
            get=> $"{currentPage + 1}/{MaxPage}";
            
        }
        public List<string> FilterType { get; set; }
        public List<FilterItem> SortParams { get; set; }

        public FilterItem SelectSort
        {
            get => selectSort;
            set
            {
                selectSort = value;
                OnPropertyChanged();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }

        public string SelectType
        {
            get => selectType;
            set
            {
                selectType = value;
                OnPropertyChanged();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;    
                OnPropertyChanged();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }
        public bool OrderByDesign
        {
            get => orderbyDesign;
            set
            {
                orderbyDesign = value;
                OnPropertyChanged();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }

        public int CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }

        private int MaxPage
        {
            get => Convert.ToInt32(Math.Ceiling((float)ProductList
                .Where(p => p.name_product
                .Contains(searchText))
                .Where(p => SelectType.Equals("Все типы") ? p.tip_product.Contains("") : p.tip_product.Equals(SelectType)).Count() / (float)itemonpage));
        }
        public MainWindow()
        {
            LoadProducts();
            LoadSortParams();
            LoadFilter();
            InitializeFields();
            InitializeComponent();
            DataContext = this;
        }

        #region Methods

        private void InitializeFields()
        {
            searchText = string.Empty;
            selectSort = SortParams[0];
            selectType = FilterType[0];
            CurrentPage = 0;
        }

        public void LoadProducts()
        {
            using(var bd = new Model1())
            {
                ProductList = new ObservableCollection<Product>(bd.Product.ToList());
            }
        }
        private void LoadSortParams()
        {
            SortParams = new List<FilterItem>
            {
                new FilterItem("name_product", "Название"),
                new FilterItem("min_cost", "Минимальная цена для агента")

            };
        }
        private void LoadFilter()
        {
            FilterType = new List<string>()
            {
               "Все типы",
               "Держители",
               "На лицо"
            };

        }

        public void FilterProducts(string search, string filtertype, string orderBy = "name_product", bool OrderByDesign = false)
        {
            if (OrderByDesign)
            {
                FilterList = new ObservableCollection<Product>(ProductList.OrderByDescending(p => p.GetProperty(orderBy))
                .Where(p => p.name_product.Contains(search))
                .Where(p => filtertype == "Все типы" ? p.tip_product.Contains("") : p.tip_product.Equals(filtertype))
                .Skip(currentPage * itemonpage).Take(itemonpage));
            }
            else
            {
                FilterList = new ObservableCollection<Product>(ProductList.OrderBy(p => p.GetProperty(orderBy))
                .Where(p => p.name_product.Contains(search))
                .Where(p => filtertype == "Все типы" ? p.tip_product.Contains("") : p.tip_product.Equals(filtertype))
                .Skip(currentPage * itemonpage).Take(itemonpage));
            }
            OnPropertyChanged(nameof(PageDisplay));
        }
        #endregion

        #region Property

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }


        #region GUIRealization
        private void ButtonClickNext(object sender, RoutedEventArgs e)
        {
            if (CurrentPage + 1 < MaxPage)
            {
                CurrentPage++;
            }
        }

        private void ButtonClickPrevious(object sender, RoutedEventArgs e)
        {
            if(CurrentPage > 0)
            {
                CurrentPage--;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OrderByDesign = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            OrderByDesign = false;
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            ProductAdds add = new ProductAdds();
            add.ShowDialog();
            if (add.DialogResult == true)
            {
               
                LoadProducts();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
                OnPropertyChanged(nameof(FilterProducts));
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EdditProduct edit = new EdditProduct(SelectProduct);
            edit.ShowDialog();
            if (edit.DialogResult == true)
            {
                using(var bd = new Model1())
                {
                    var product = bd.Product.Find(edit.CurrentProduct.name_product);
                    product.tip_product = edit.SelectType;
                    product.number_proizv = edit.Numberzavod;
                    product.min_cost = edit.Min_cost;
                    product.kol_for_proizv = edit.Kolforproizv;
                    product.images = edit.Image;
                    product.articul = edit.Artikul;

                    bd.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                    LoadProducts();
                    FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
                }
            }
            else
            {
                LoadProducts();
                FilterProducts(SearchText, SelectType, SelectSort.Property, OrderByDesign);
            }
        }

        #endregion



        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
