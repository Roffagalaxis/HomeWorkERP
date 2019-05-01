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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //belépés
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ItemModelContainer container = new ItemModelContainer())
            {
                //"SELECT * FROM Users WHERE Name = 'userfield'
                var user = container.UsersSet.Where(u => u.Name == userfield.Text).SingleOrDefault();
                if (user != null && user.Password == pwfield.Password)
                {
                    var window = new CenterWindow();
                    window.Show();
                    this.Close();                    
                }
                else
                {
                    Errorbox.Text = "Hibás felhasználónév vagy jelszó!!";
                }
            }
        }
    }
}
