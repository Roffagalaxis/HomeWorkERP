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
    }
}
