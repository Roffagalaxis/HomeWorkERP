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
using System.Windows.Shapes;

namespace WpfERP
{
    /// <summary>
    /// Interaction logic for SzeriaszamView.xaml
    /// </summary>
    public partial class SzeriaszamView : Window
    {
        public SzeriaszamView()
        {
            InitializeComponent();
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Szeriaszamok> local_Szeriaszamoks = new List<Local_Szeriaszamok>();

                foreach (Szeriaszamok szeriaszamok in container.SzeriaszamokSet)
                {
                    // Konvertálunk lokális objektumra
                    Local_Szeriaszamok m = new Local_Szeriaszamok() { Id = szeriaszamok.Id, Szeriaszam = szeriaszamok.Szeriaszam, Statusz = szeriaszamok.Statusz };
                    local_Szeriaszamoks.Add(m);
                }
                // DataGrid adatforrás
                dbData.ItemsSource = local_Szeriaszamoks;
            }
        }

        public string mod_szeriaszam;
        public string mod_statusz;
        public int mod_termek_id;

        //Frissítés Gomb
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //Létrehozunk egy Db context-et
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Szeriaszamok> local_Szeriaszamoks = new List<Local_Szeriaszamok>();

                foreach (Szeriaszamok szeriaszamok in container.SzeriaszamokSet)
                {
                    // Konvertálunk lokális objektumra
                    Local_Szeriaszamok m = new Local_Szeriaszamok() { Id = szeriaszamok.Id, Szeriaszam = szeriaszamok.Szeriaszam, Statusz = szeriaszamok.Statusz };
                    local_Szeriaszamoks.Add(m);
                }
                // DataGrid adatforrás
                dbData.ItemsSource = local_Szeriaszamoks;
            }
        }
        //Új Gomb
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var szeriaszam_New_Edit = new Szeriaszam_New_Edit();
            //elrejtjük a felesleget
            szeriaszam_New_Edit.ID.Visibility = Visibility.Hidden;
            szeriaszam_New_Edit.ID_box.Visibility = Visibility.Hidden;
            szeriaszam_New_Edit.cbNev.Visibility = Visibility.Hidden;
            //feltöltöltöm a comboboxot
            using (ItemModelContainer container = new ItemModelContainer())
            {
                szeriaszam_New_Edit.cbItem.DataContext = container.TermekekSet.ToList();
            }
            szeriaszam_New_Edit.cbNev.SelectedIndex = 0;
            //megnyitás
            szeriaszam_New_Edit.ShowDialog();
            //visszatérés
            this.mod_statusz = szeriaszam_New_Edit.mod_statusz;
            this.mod_szeriaszam = szeriaszam_New_Edit.mod_szeriaszam;
            this.mod_termek_id = Convert.ToInt32(szeriaszam_New_Edit.mod_termek_id);
            //vissza gomb és üres adat felvitel akadályozás
            if (mod_statusz != null && mod_szeriaszam != null && mod_statusz != "" && mod_szeriaszam != "")
            {
                using (ItemModelContainer container = new ItemModelContainer())
                {
                    foreach (Termekek termek in container.TermekekSet.Where(u => u.Id == mod_termek_id))
                    {
                        Szeriaszamok ujszeriaszamok = new Szeriaszamok
                        {
                            Szeriaszam = mod_szeriaszam,
                            Statusz = mod_statusz,
                            Termekek = termek
                        };
                        //hozzáadjuk a szériát
                        container.SzeriaszamokSet.Add(ujszeriaszamok);
                    }
                    //adatok mentése
                    container.SaveChanges();
                }
            }

        }
        //Szerkesztés Gomb
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var szeriaszam_New_Edit = new Szeriaszam_New_Edit();
            //elrejtjük a felesleget
            szeriaszam_New_Edit.cbItem.Visibility = Visibility.Hidden;
            //feltöltöm a ComboBoxot
            using (ItemModelContainer container = new ItemModelContainer())
            {
                szeriaszam_New_Edit.cbNev.DataContext = container.SzeriaszamokSet.ToList();
            }
            szeriaszam_New_Edit.cbNev.SelectedIndex = 0;
            //megnyitás
            szeriaszam_New_Edit.ShowDialog();
            //visszatérés
            this.mod_statusz = szeriaszam_New_Edit.mod_statusz;
            this.mod_szeriaszam = szeriaszam_New_Edit.mod_szeriaszam;
            //vissza gomb és üres adat felvitel akadályozás
            if (mod_statusz != null && mod_szeriaszam != null && mod_statusz != "" && mod_szeriaszam != "")
            {
                using (ItemModelContainer container = new ItemModelContainer())
                {
                    szeriaszam_New_Edit.cbAktualis.Szeriaszam = mod_szeriaszam;
                    szeriaszam_New_Edit.cbAktualis.Statusz = mod_statusz;
                    container.Entry(szeriaszam_New_Edit.cbAktualis).State = System.Data.Entity.EntityState.Modified;
                    //adatok mentése
                    container.SaveChanges();
                }
            }
        }
        //Keresés Gomb
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var szeriaszam_New_Edit = new Szeriaszam_New_Edit();
            szeriaszam_New_Edit.btnSave.Content = "Keresés";
            //elrejtjük a felesleget
            szeriaszam_New_Edit.ID.Visibility = Visibility.Hidden;
            szeriaszam_New_Edit.ID_box.Visibility = Visibility.Hidden;
            szeriaszam_New_Edit.cbNev.Visibility = Visibility.Hidden;
            szeriaszam_New_Edit.cbItem.Visibility = Visibility.Hidden;
            //megnyitás
            szeriaszam_New_Edit.ShowDialog();
            //visszatérés
            this.mod_statusz = szeriaszam_New_Edit.mod_statusz;
            this.mod_szeriaszam = szeriaszam_New_Edit.mod_szeriaszam;
            //adatmentés
            using (ItemModelContainer container = new ItemModelContainer())
            {
                List<Local_Szeriaszamok> local_Szeriaszamoks = new List<Local_Szeriaszamok>();
                //ha leriasra keresünk- csak pontos egyezés!!!
                foreach (Szeriaszamok szeriaszamok in container.SzeriaszamokSet.Where(u => u.Statusz == mod_statusz))
                {
                    // Konvertálunk lokális objektumra
                    Local_Szeriaszamok m = new Local_Szeriaszamok() { Id = szeriaszamok.Id, Szeriaszam = szeriaszamok.Szeriaszam, Statusz = szeriaszamok.Statusz };
                    local_Szeriaszamoks.Add(m);
                }
                //ha névre keresünk- csak pontso egyezés!!!
                foreach (Szeriaszamok szeriaszamok in container.SzeriaszamokSet.Where(u => u.Szeriaszam == mod_szeriaszam))
                {
                    // Konvertálunk lokális objektumra
                    Local_Szeriaszamok m = new Local_Szeriaszamok() { Id = szeriaszamok.Id, Szeriaszam = szeriaszamok.Szeriaszam, Statusz = szeriaszamok.Statusz };
                    local_Szeriaszamoks.Add(m);
                }
                //dataGrid adatforrás
                dbData.ItemsSource = local_Szeriaszamoks;
            }
        }
    }
}
