using GoldStarr_YSYS_OP1_Grupp_6.Classes;
using GoldStarr_YSYS_OP1_Grupp_6.InFramePages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core.Preview;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoldStarr_YSYS_OP1_Grupp_6
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
         Store store = new Store();

        public MainPage()
        {
            this.InitializeComponent();
            TempStores.ResetProperties();
            store.UniversalListInitializer();
            
        }

        public void SaveOnClose()
        {
            store.SaveAll();
        }
        public void HideInfo()
        {
            MainPageHeader.Visibility = Visibility.Collapsed;
            MainPageInfo.Visibility = Visibility.Collapsed;
            TextBlockErrorHeader.Visibility = Visibility.Collapsed;
            TextBlockErrorMessages.Visibility = Visibility.Collapsed;
            TextBlockErrorMessageToCopy.Visibility = Visibility.Collapsed;
        }

        private void ButtonStock_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(StockPage), store);
            HideInfo();
        }

        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(CustomerList), store);
            HideInfo();
        }
        private void OrderButtom_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(NewOrder), store);
            HideInfo();
        }

        private void CustomerOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(CustomerOrderPage), store);
            HideInfo();
        }

        private void onSaveFileClick(object sender, RoutedEventArgs e)
        {
            store.SaveAll();
        }

        private void GoToSupplierPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(SupplierPage), store);
            HideInfo();
        }
    }
}
