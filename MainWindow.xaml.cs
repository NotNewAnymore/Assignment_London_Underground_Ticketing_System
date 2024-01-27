// Henry Fleischer

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace Assignment_London_Underground_Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Replace "HenrysList" with your Custom List name in 2 places.
        // 1. Replace here
        // Example YourList<Ride> Riders
        public HenrysList<Rider> Riders;

        int numberOfRiders = 5000; // Changes this to something higher than 100 to check your list is working

        public MainWindow()
        {
            InitializeComponent();
            InitializeRiders();
            cmbSearchStation.ItemsSource = Enum.GetValues(typeof(Station));


            lvRiders.ItemsSource = Riders;
        } // MainWindow

        private void OnSearchStation(object sender, RoutedEventArgs e)
        {
            var searchStation = cmbSearchStation.SelectedIndex;

			// Enter code here to show all riders who started their ride from the selected station
			foreach (Rider item in Riders)
			{
				if (item != null && (int)item.StationOn == cmbSearchStation.SelectedIndex)
				{
					lvFilteredRiders.Items.Add(item);

				}

			}
			// lvRiders.ItemsSource = YourReturnedResults;
		} // OnSearchStation

        private void OnShowActive(object sender, RoutedEventArgs e)
        {
			// Enter code here to display all riders currently riding the underground
			foreach (Rider item in Riders)
			{
				if (item != null && item.StationOn == Station.Active)
                {
                    lvFilteredRiders.Items.Add(item);

				}

			}
			// lvRiders.ItemsSource = YourReturnedResults;
		} // OnShowActive

        private void OnClearList(object sender, RoutedEventArgs e)
        {
            lvFilteredRiders.Items.Clear();
        }

        private void InitializeRiders()
        {
            // 2. And here
            // Ex Riders = new YourList<Rider>();
            Riders = new HenrysList<Rider>();
            Random rnd = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();

            for (int i = 0; i < numberOfRiders; i++)
            {
                int uniqueNumber;
                do
                {
                    uniqueNumber = rnd.Next(100000000, 1000000000);
                }
                while (usedNumbers.Contains(uniqueNumber));

                usedNumbers.Add(uniqueNumber);

                Station stationOn = (Station)rnd.Next(Enum.GetNames(typeof(Station)).Length);
                Station stationOff = rnd.Next(100) < 30 ? Station.Active : (Station)rnd.Next(1, Enum.GetNames(typeof(Station)).Length);

                Riders.Add(new Rider(uniqueNumber, stationOn, stationOff));
            }
            Riders.AddAtIndex(new Rider(6,(Station)rnd.Next(Enum.GetNames(typeof(Station)).Length),(Station)rnd.Next(Enum.GetNames(typeof(Station)).Length)),2);
            Riders.RemoveAtIndex(2);  //At least it does not throw an error no matter what I do.

        } // Initialize Riders

    

    } //class

} // namespace