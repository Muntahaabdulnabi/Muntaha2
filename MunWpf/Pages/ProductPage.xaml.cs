using MunApi.Models;
using MunWpf.Sevices;
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

namespace MunWpf.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private readonly ProductService _productService;
        public ProductPage(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }
        public async void btn_product_save_Click(object sender, RoutedEventArgs e)
        {
            await _productService.Create(new ProductCreateModel
            {
                Name = tb_product_name.Text,
                Description = tb_product_description.Text,
                Price = decimal.Parse(tb_product_price.Text)
            });
            tb_product_name.Text = String.Empty;
            tb_product_description.Text = String.Empty;
            tb_product_price.Text = String.Empty;
        }
    }
}
