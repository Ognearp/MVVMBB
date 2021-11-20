using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using NotMVMMSuck.Data;

namespace NotMVMMSuck.View
{
    /// <summary>
    /// Логика взаимодействия для ProductAdds.xaml
    /// </summary>
    public partial class ProductAdds : Window,INotifyPropertyChanged
    {

        private string nameproduct;
        private string artikul;
        private double min_cost;
        private string image;
        private List<string> typeproduct;
        private int kolforproizv;
        private int numberzavod;
        private string selectType;
        public ProductAdds()
        {
            DataContext = this;
            LoadStanratFields();

            InitializeComponent();
        }



        #region Fields

        public string Nameproduct { get => nameproduct; set { nameproduct = value; OnPropertyChanged(); } }
        public string Artikul { get => artikul; set { artikul = value; OnPropertyChanged(); } }
        public double Min_cost { get => min_cost; set { min_cost = value; OnPropertyChanged(); } }
        public string Image { get => image; set { image = value; OnPropertyChanged(); } }
        public List<string> Typeproduct { get=> typeproduct; set { typeproduct = value; OnPropertyChanged(); } }
        public int Kolforproizv { get => kolforproizv; set { kolforproizv = value; OnPropertyChanged(); } }
        public int Numberzavod { get => numberzavod; set { numberzavod = value; OnPropertyChanged(); } }

        public Product CurrentProduct { get; set; }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChanged(); } }

        #endregion



        #region Methods

        public void LoadStanratFields()
        {
            CurrentProduct = new Product();
            Nameproduct = string.Empty;
            Artikul = string.Empty;
            Min_cost = 0;
            Image = string.Empty;
            SelectType = string.Empty;
            Kolforproizv = 0;
            Numberzavod = 0;
            Image = @"/products/picture.png";
            Typeproduct = new List<string>
            {
                "Держители",
                "На лицо"
            };
        }
        
        #endregion


        #region property
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        private void AddClick(object sender, RoutedEventArgs e)
        {
            CurrentProduct.name_product = Nameproduct;
            CurrentProduct.articul = Artikul;
            CurrentProduct.min_cost = Min_cost;
            CurrentProduct.images = Image;
            CurrentProduct.kol_for_proizv = Kolforproizv;
            CurrentProduct.tip_product = SelectType;
            CurrentProduct.number_proizv = Numberzavod;

            using (var bd = new Model1())
            {
                bd.Product.Add(CurrentProduct);
                bd.SaveChanges();
                DialogResult = true;
                MessageBox.Show("Продукт успешно добавлен");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var newFilePath = @"/products/" + Guid.NewGuid() + ".png";
                File.Copy(openFileDialog.FileName, $@"../../{newFilePath}");
                Image = newFilePath;
            }
        }
    }
}
