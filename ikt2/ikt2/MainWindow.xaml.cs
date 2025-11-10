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

namespace ikt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string filePath = "foglalasok.csv";

        public MainWindow()
        {
            InitializeComponent();


            
            File.WriteAllText(filePath, "Nev,SzobaSzam,SzobaTipus,Parkolohely,Fo,Ellatas,Datum,Kisallat\n");
            
        }

        private void Elkuldes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Összegyűjtjük az adatokat a TextBoxokból
                string adatSor = $"{NevBox.Text},{SzobaBox.Text},{TipusBox.Text},{ParkoloBox.Text},{FoBox.Text},{EllatasBox.Text},{DatumBox.Text},{KisallatBox.Text}";

                // Hozzáírjuk a fájlhoz
                File.AppendAllText(filePath, adatSor + Environment.NewLine);

                MessageBox.Show("Az adatok sikeresen elmentve!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);

                // TextBoxok ürítése
                NevBox.Clear();
                SzobaBox.Clear();
                TipusBox.Clear();
                ParkoloBox.Clear();
                FoBox.Clear();
                EllatasBox.Clear();
                DatumBox.Clear();
                KisallatBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt mentés közben:\n" + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}