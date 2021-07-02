using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDetailControl : UserControl
    {

        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer),
                typeof(CustomerDetailControl), new PropertyMetadata(null, CustomerChangedCallback));

        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }

        private static void CustomerChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if(d is CustomerDetailControl customerDetailControl)
            {
                var customer = e.NewValue as Customer;
                customerDetailControl.txtFirstName.Text = customer?.FirstName ?? "";
                customerDetailControl.txtLastName.Text = customer?.LastName ?? "";
                customerDetailControl.chkIsDeveloper.IsChecked = customer?.IsDeveloper;
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            if (Customer != null)
            {
                Customer.FirstName = txtFirstName.Text;
                Customer.LastName = txtLastName.Text;
                Customer.IsDeveloper = chkIsDeveloper.IsChecked.GetValueOrDefault();
            }
        }


    }


}
