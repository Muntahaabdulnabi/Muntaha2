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
    public partial class OrderPage : Page
    {
        private readonly OrderService _orderService;
        public OrderPage(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }

        private async void btn_order_save_Click(object sender, RoutedEventArgs e)
        {
            await _orderService.Create(new OrderCreateModel
            {
                CustomerName = tb_customerName.Text,
                CreatedDate = DateTime.Parse(tb_createdDate.Text),
                DueDate = DateTime.Parse(tb_dueDate.Text),
                TotalPrice = decimal.Parse(tb_totalPrice.Text),
                StreetName = tb_streetName.Text,
                StreetNumber = tb_streetNumber.Text,
                PostalCode = tb_postalCode.Text,
                City = tb_city.Text,
            });
            tb_createdDate.Text = String.Empty;
            tb_dueDate.Text = String.Empty;
            tb_customerName.Text = String.Empty;
            tb_totalPrice.Text = String.Empty;
            tb_streetName.Text = String.Empty;
            tb_streetNumber.Text = String.Empty;
            tb_postalCode.Text = String.Empty;
            tb_city.Text = String.Empty;
        }   
    }
}
