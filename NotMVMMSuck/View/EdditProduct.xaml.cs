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
    /// Логика взаимодействия для EdditProduct.xaml
    /// </summary>
    public partial class EdditProduct : Window , INotifyPropertyChanged
    {

        #region Fields
        private string nameproduct;
        private string artikul;
        private double min_cost;
        private string image;
        private List<string> typeproduct;
        private int kolforproizv;
        private int numberzavod;
        private string selectType;

        #endregion

        #region Property
        public string Nameproduct { get => nameproduct; set { nameproduct = value; OnPropertyChanged(); } }
        public string Artikul { get => artikul; set { artikul = value; OnPropertyChanged(); } }
        public double Min_cost { get => min_cost; set { min_cost = value; OnPropertyChanged(); } }
        public string Image { get => image; set { image = value; OnPropertyChanged(); } }
        public List<string> Typeproduct { get => typeproduct; set { typeproduct = value; OnPropertyChanged(); } }
        public int Kolforproizv { get => kolforproizv; set { kolforproizv = value; OnPropertyChanged(); } }
        public int Numberzavod { get => numberzavod; set { numberzavod = value; OnPropertyChanged(); } }

        public Product CurrentProduct { get; set; }
        public string SelectType { get => selectType; set { selectType = value; OnPropertyChanged(); } }
        #endregion
        public EdditProduct(Product product)
        {
            InitilizadFields(product);
            InitializeComponent();
            DataContext = this;
        }


        #region Metods
        public void InitilizadFields(Product product)
        {
            CurrentProduct = product;
            Nameproduct = CurrentProduct.name_product;
            Artikul = CurrentProduct.articul;
            Min_cost = CurrentProduct.min_cost;
            Image = CurrentProduct.images;
            Typeproduct = new List<string>
            {
                "Держители",
                "На лицо",
            };
            SelectType = Typeproduct.FirstOrDefault(p => p.Equals(CurrentProduct.tip_product));
            Kolforproizv = CurrentProduct.kol_for_proizv;
            Numberzavod = CurrentProduct.number_proizv;


        }
        #endregion

        #region Property
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion


        #region GUI
        private void Eddit_Click(object sender, RoutedEventArgs e)
        {
            using(var bd  = new Model1())
            {
                CurrentProduct.name_product = Nameproduct;
                CurrentProduct.articul = Artikul;
                CurrentProduct.min_cost = Min_cost;
                CurrentProduct.images = Image;
                CurrentProduct.tip_product = SelectType;
                CurrentProduct.kol_for_proizv = Kolforproizv;
                CurrentProduct.number_proizv = Numberzavod;

                DialogResult = true;
            }
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var newFilePath = @"/products/" + Guid.NewGuid() + ".png";
                File.Copy(openFileDialog.SafeFileName, $@"../../products/{newFilePath}");
                Image = newFilePath;
            }

        }
        #endregion

        private void Delete_naxer(object sender, RoutedEventArgs e)
        {
            var dialog = MessageBox.Show("Вы точно хотите удалить продукт","Оповещание" , MessageBoxButton.OKCancel , MessageBoxImage.Warning);
            if (dialog == MessageBoxResult.OK)
            {
                using (var bd = new Model1())
                {

                    var product = bd.Product.Find(CurrentProduct.name_product);
                    if (product != null)
                    {
                        bd.Product.Remove(product);
                        bd.SaveChanges();
                        DialogResult = false;
                        MessageBox.Show("Продукт удален нахер", "Балдеж" , MessageBoxButton.OK , MessageBoxImage.Warning);
                    }

                }
            }
           
        }
    }
}
