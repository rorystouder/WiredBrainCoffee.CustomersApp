using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Customer Added!");
            await messageDialog.ShowAsync();
        }

        private async void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Customer Deleted!");
            await messageDialog.ShowAsync();
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(customerListGrid);

            int newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(customerListGrid, newColumn);

            moveSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }
    }
}
