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

        //Frissítés Gomb
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
        //Új Gomb
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            //elrejtjük a felesleget
            Termek_New_Edit.ID.Visibility = Visibility.Hidden;
            Termek_New_Edit.ID_box.Visibility = Visibility.Hidden;
            Termek_New_Edit.cbNev.Visibility = Visibility.Hidden;
            //megnyitás
            Termek_New_Edit.ShowDialog();
            //visszatérés
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
            //vissza gomb és üres adat felvitel akadályozás
            if (mod_leiras != null && mod_nev != null && mod_leiras != "" && mod_nev != "")
            {
                using (ItemModelContainer container = new ItemModelContainer())
                {
                    Termekek ujtermek = new Termekek
                    {
                        Neve = mod_nev,
                        Leiras = mod_leiras
                    };
                    //hozzáadjuk a terméket
                    container.TermekekSet.Add(ujtermek);
                    //adatok mentése
                    container.SaveChanges();
                }
            }
            
        }
        //Szerkesztés Gomb
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            //feltöltöm a ComboBoxot
            using (ItemModelContainer container = new ItemModelContainer())
            {
                Termek_New_Edit.cbNev.DataContext = container.TermekekSet.ToList();
            }
            Termek_New_Edit.cbNev.SelectedIndex = 0;                
            //megnyitás
            Termek_New_Edit.ShowDialog();
            //visszatérés
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
            //vissza gomb és üres adat felvitel akadályozás
            if (mod_leiras != null && mod_nev != null && mod_leiras != "" && mod_nev != "")
            {
                using (ItemModelContainer container = new ItemModelContainer())
                {
                    Termek_New_Edit.cbAktualis.Neve = mod_nev;
                    Termek_New_Edit.cbAktualis.Leiras = mod_leiras;
                    container.Entry(Termek_New_Edit.cbAktualis).State = System.Data.Entity.EntityState.Modified;
                    //adatok mentése
                    container.SaveChanges();
                }
            }
        }
        //Keresés Gomb
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var Termek_New_Edit = new Termek_New_Edit();
            Termek_New_Edit.btnSave.Content = "Keresés";
            //elrejtjük a felesleget
            Termek_New_Edit.ID.Visibility = Visibility.Hidden;
            Termek_New_Edit.ID_box.Visibility = Visibility.Hidden;
            Termek_New_Edit.cbNev.Visibility = Visibility.Hidden;
            //megnyitás
            Termek_New_Edit.ShowDialog();
            //visszatérés
            this.mod_leiras = Termek_New_Edit.mod_leiras;
            this.mod_nev = Termek_New_Edit.mod_nev;
            //adatmentés
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
