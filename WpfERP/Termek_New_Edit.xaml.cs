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
    /// Interaction logic for Termek_New_Edit.xaml
    /// </summary>
    public partial class Termek_New_Edit : Window
    {
        public Termek_New_Edit()
        {
            InitializeComponent();
        }

        public string mod_nev;
        public string mod_leiras;
        public Termekek cbAktualis;

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mod_leiras = null;
            mod_nev = null;
        }
        //A boxokból kimentjük az adatokat
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            mod_leiras = Leiras_box.Text;
            mod_nev = Name_box.Text;
            this.Close();
        }

        private void CbNev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Aktuális item
            cbAktualis = ((ComboBox)sender).SelectedItem as Termekek;
            //CB beállítása
            cbNev.SelectedItem = cbAktualis;
            //boxok beállítása
            ID_box.Text = cbAktualis.Id.ToString();
            Name_box.Text = cbAktualis.Neve;
            Leiras_box.Text = cbAktualis.Leiras;
        }
    }
}
