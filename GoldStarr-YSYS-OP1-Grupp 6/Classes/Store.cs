using GoldStarr_YSYS_OP1_Grupp_6.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace GoldStarr_YSYS_OP1_Grupp_6
{
    class Store
    {

        public ObservableCollection<Merchandise> MerchandiseCollection;
        public ObservableCollection<Customer> CustomerCollection;
        public ObservableCollection<CustomerOrder> CustomerOrderCollection;
        public ObservableCollection<CustomerOrder> BacklogCustomerOrderCollection;
        public ObservableCollection<string> SupplierCollection;
        private string errorMessage = string.Empty;

        public Store()
        {
            MerchandiseCollection = new ObservableCollection<Merchandise>();
            CustomerCollection = new ObservableCollection<Customer>();
            CustomerOrderCollection = new ObservableCollection<CustomerOrder>();
            BacklogCustomerOrderCollection = new ObservableCollection<CustomerOrder>();
            SupplierCollection = new ObservableCollection<string>();
            /*PopulatateMerchandiseCollection();
            PopulateCustomerList();
            PopulateCustomerOrderList();*/
           // AutoSaveToFileTimer();
        }



        public void PopulatateMerchandiseCollection()
        {
            MerchandiseCollection.Add(new Merchandise("Marabou Schweizernöt", "Marabou", 15));
            MerchandiseCollection.Add(new Merchandise("Coca Cola", "Spendrups", 12));
            MerchandiseCollection.Add(new Merchandise("Apelsinejuice", "Festis", 13));
            MerchandiseCollection.Add(new Merchandise("Citronjuice", "Rynkeby", 5));
            MerchandiseCollection.Add(new Merchandise("Skånerost", "Zoega's", 5));
            MerchandiseCollection.Add(new Merchandise("Hallonsaft", "BOB", 15));
            MerchandiseCollection.Add(new Merchandise("Fanta", "Coca Cola Company", 125));
        }

        public void PopulateCustomerList()
        {
            CustomerCollection.Add(new Customer("Abdi Anderson", "Limhamnsvägen 27, Malmö"));
            CustomerCollection.Add(new Customer("Thomas Shelby", "Regementsgatan 31, Malmö", "0734958965"));
            CustomerCollection.Add(new Customer("Fallon Carrington", "Malmövägen 15, Lund", "0733456585"));
            CustomerCollection.Add(new Customer("Rick Grimes", "Industrigatan 32, Malmö", "0736987456"));
            CustomerCollection.Add(new Customer("Meredith Grey", "Alnarpsvägen 40, Åkarp"));
            CustomerCollection.Add(new Customer("Richard Hendricks", "Mariedalsvägen 15, Malmö", "0733456145"));
            CustomerCollection.Add(new Customer("Arthur Shelby", "Lommavägen 13, Oxie"));
            
        }

        /*public void PopulateCustomerOrderList()
        {
            CustomerOrderCollection.Add(new CustomerOrder(CustomerCollection[1], MerchandiseCollection[1], 5));
            CustomerOrderCollection.Add(new CustomerOrder(CustomerCollection[2], MerchandiseCollection[2], 5));
            CustomerOrderCollection.Add(new CustomerOrder(CustomerCollection[3], MerchandiseCollection[3], 5));
        }

        private void AutoSaveToFileTimer()
        {
            DispatcherTimer dispatcherTimer;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += AutosaveToFile;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
        }

        void AutosaveToFile(object sender, object e)
        {
        }*/

        public async void UniversalSaver<T>(string filename, ObservableCollection<T> collectionName)
        {
            string json = JsonConvert.SerializeObject(collectionName);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, json);
        }
        public void SaveAll()
        {
            UniversalSaver<Merchandise>("merchandise.json", MerchandiseCollection);
            UniversalSaver<Customer>("customers.json", CustomerCollection);
            UniversalSaver<CustomerOrder>("orders.json", CustomerOrderCollection);
        }

        public async Task<ObservableCollection<T>> UniversalLoader<T>(string filename)
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            await FileIO.ReadTextAsync(file);
            string json = await FileIO.ReadTextAsync(file);
            ObservableCollection<T> collectionName = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            return collectionName;
        }

        public async void UniversalListInitializer()
        {
            MerchandiseCollection = await UniversalLoader<Merchandise>("merchandise.json");
            CustomerCollection = await UniversalLoader<Customer>("customers.json");
            CustomerOrderCollection = await UniversalLoader<CustomerOrder>("orders.json");
        }
        
        public string GetErrors()
        {
            return errorMessage;
        }

    }
}
