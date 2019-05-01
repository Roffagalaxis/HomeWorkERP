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
            //Létrehozunk egy Db context-et
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Termekek> local_Termekeks = new List<Local_Termekek>();

                foreach (Termekek termekek in container.TermekekSet)
                {
                    // Konvertálunk lokális objektumra
                    Local_Termekek m = new Local_Termekek() { Id = termekek.Id, Neve = termekek.Neve, Leiras = termekek.Leiras };
                    local_Termekeks.Add(m);
                }
                // DataGrid adatforrás
                dbData.ItemsSource = local_Termekeks;
            }
        }

        public string mod_nev;
        public string mod_leiras;

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //Létrehozunk egy Db context-et
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Termekek> local_Termekeks = new List<Local_Termekek>();

                foreach (Termekek termekek in container.TermekekSet)
                {
                    // Konvertálunk lokális objektumra
                    Local_Termekek m = new Local_Termekek() { Id = termekek.Id, Neve = termekek.Neve, Leiras = termekek.Leiras };
                    local_Termekeks.Add(m);
                }
                // DataGrid adatforrás
                dbData.ItemsSource = local_Termekeks;
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            Termek_New_Edit.ShowDialog();
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            Termek_New_Edit.ShowDialog();
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            Termek_New_Edit.btnSave.Content = "Keresés";
            Termek_New_Edit.ID.Visibility = Visibility.Hidden;
            Termek_New_Edit.ID_box.Visibility = Visibility.Hidden;
            Termek_New_Edit.ShowDialog();
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Termekek> local_Termekeks = new List<Local_Termekek>();
                //ha leriasra keresünk- csak pontos egyezés!!!
                foreach (Termekek termekek in container.TermekekSet.Where(u => u.Leiras == mod_leiras))
                {
                    // Konvertálunk lokális objektumra
                    Local_Termekek m = new Local_Termekek() { Id = termekek.Id, Neve = termekek.Neve, Leiras = termekek.Leiras };
                    local_Termekeks.Add(m);
                }
                //ha névre keresünk- csak pontso egyezés!!!
                foreach (Termekek termekek in container.TermekekSet.Where(u => u.Neve == mod_nev))
                {
                    // Konvertálunk lokális objektumra
                    Local_Termekek m = new Local_Termekek() { Id = termekek.Id, Neve = termekek.Neve, Leiras = termekek.Leiras };
                    local_Termekeks.Add(m);
                }
                //dataGrid adatforrás
                dbData.ItemsSource = local_Termekeks;
            }
        }
    }
}
