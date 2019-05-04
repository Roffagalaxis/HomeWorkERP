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
    /// Interaction logic for CenterWindow.xaml
    /// </summary>
    public partial class CenterWindow : Window
    {
        public CenterWindow()
        {
            InitializeComponent();
            //Létrehozunk egy Db context-et
            using (var ctx = new ItemModelContainer())
            {
                //Készleten lévő Szériás-SQL
                List<Keszleten_Levo_Szeriak> keszleten_Levo_szeria_list = ctx.Database.SqlQuery<Keszleten_Levo_Szeriak>("" +
                "SELECT T.NEVE TERMEK, " +
                "SZ.SZERIASZAM, " +
                "Concat(P.NEV, '-' , P.SZINT ,'-', P.DOBOZ) TAROLO " +
                "FROM SzeriaszamokSet SZ, TermekekSet T, KeszletSet K, PolcokSet P " +
                "WHERE SZ.TERMEKEK_ID = T.ID " +
                "AND K.SZERIASZAMOK_ID = SZ.ID " +
                "AND P.ID = K.POLCOK_ID; ").ToList();

                // DataGrid adatforrás
                dbPreview.ItemsSource = keszleten_Levo_szeria_list;
            }
        }
        
        //Kijelentkezünk
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        //Bezárjuk az alkalmazást
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Termékek megnyitása
        private void Term_View_Click(object sender, RoutedEventArgs e)
        {
            var TermViewWindow = new TermekView();
            TermViewWindow.Show();
        }
        //Szériaszámok megnyitása
        private void Szeria_View_Click(object sender, RoutedEventArgs e)
        {
            var SzeriaszamWindow = new SzeriaszamView();
            SzeriaszamWindow.Show();
        }
    }
}
