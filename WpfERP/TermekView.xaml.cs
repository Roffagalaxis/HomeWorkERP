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

namespace WpfERP
{
    /// <summary>
    /// Interaction logic for TermekView.xaml
    /// </summary>
    public partial class TermekView : Window
    {
        public TermekView()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Mindig így hozzuk létre a Db context-et
            // Automatikusan megszűnik a using végén
            using (ItemModelContainer container = new ItemModelContainer())
            {
                // Mindig így hozzuk létre a Db context-et
                // Automatikusan megszűnik a using végén
                List<Szeriaszamok> mufajok = new List<Szeriaszamok>();

                //// Include("<tulajdonságnév>") -> valamilyen JOIN (többnyire INNER)
                //foreach (Genre genre in container.Genres.Include("Movies"))
                //{
                //    // Konvertálunk egyedi (lokális) objektumokra,
                //    // az egyszerűbb megjelenítés végett (Genre -> Műfaj)
                //    Termekek m = new Termekek() { Id = genre.Id, Név = genre.Name };
                //    foreach (Movie movie in genre.Movies)
                //        m.Filmek += (movie.Title + Environment.NewLine);

                //    mufajok.Add(m);
                //}


                foreach (var x in container.SzeriaszamokSet)
                {
                    Szeriaszamok sz = x;
                    mufajok.Add(sz);
                }
                // Megadjuk a DataGrid adatforrást
                dbData.ItemsSource = mufajok;
            }
        }
    }
}
