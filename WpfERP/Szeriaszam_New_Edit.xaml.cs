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
    /// Interaction logic for Szeriaszam_New_Edit.xaml
    /// </summary>
    public partial class Szeriaszam_New_Edit : Window
    {
        public Szeriaszam_New_Edit()
        {
            InitializeComponent();
        }

        public string mod_szeriaszam;
        public string mod_statusz;
        public string mod_termek_id;
        public Szeriaszamok cbAktualis;
        public Termekek cbTermek;
        //visszagomb
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mod_statusz = null;
            mod_szeriaszam = null;
        }
        //A boxokból kimentjük az adatokat
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            mod_statusz = Statusz_box.Text;
            mod_szeriaszam = SZSZ_box.Text;
            this.Close();
        }

        private void CbNev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Aktuális szeria
            cbAktualis = ((ComboBox)sender).SelectedItem as Szeriaszamok;
            //CB beállítása
            cbNev.SelectedItem = cbAktualis;
            //boxok beállítása
            ID_box.Text = cbAktualis.Id.ToString();
            SZSZ_box.Text = cbAktualis.Szeriaszam;
            Statusz_box.Text = cbAktualis.Statusz;
        }

        private void CbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Aktuális item
            cbTermek = ((ComboBox)sender).SelectedItem as Termekek;
            //CB beállítása
            cbItem.SelectedItem = cbTermek;
            //id-kimentése
            mod_termek_id = cbTermek.Id.ToString();
        }
    }
}
