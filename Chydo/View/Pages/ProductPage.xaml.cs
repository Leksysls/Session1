using Chydo.Model;
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

namespace Chydo.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Core db = new Core();
        List<Product> arrayProduct;
        public ProductPage()
        {
            Manufacturer allManufacturer = new Manufacturer
            {
                IdManufacturer = 0,
                Manufacturers="Все производители",
            };
            List<Manufacturer> arrayManufacturer = db.context.Manufacturer.ToList();
            arrayManufacturer.Add(allManufacturer);

            InitializeComponent();
            arrayProduct = db.context.Product.ToList();
            LViewProduct.ItemsSource = arrayProduct;

            FilterComboBox.ItemsSource = arrayManufacturer;
            FilterComboBox.DisplayMemberPath = "Manufacturers";
            FilterComboBox.SelectedValuePath = "IdManufacturer";
            FilterComboBox.SelectedIndex = 0;

            SortComboBox.SelectedIndex = 0;
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            var product = db.context.Product.ToList();

            if (SortComboBox.SelectedIndex == 0)
            {
                product = product.OrderBy(x => x.ProductCost).ToList();
            }
            else
            {
                product = product.OrderByDescending(x => x.ProductCost).ToList();
            }

            if (TBoxSearch.Text !=String.Empty)
            {
                product = product.Where(x => x.ProductName.ToString().ToLower().Contains(TBoxSearch.Text.ToString().ToLower())).ToList();
            }

            if (FilterComboBox.SelectedIndex.ToString() !="0" )
            {
                product = product.Where(x => x.ProductManufacturer.ToString() == FilterComboBox.SelectedIndex.ToString()).ToList();
            }
            LViewProduct.ItemsSource = product;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
