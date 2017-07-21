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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Policy;

namespace lowkey
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

        private void CommentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=login; port=3306; password='';");
        //private object urlkind;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Connecting to MySQL...");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `Username`, `Password` FROM `users` WHERE `Username` = '" + CommentTextBox.Text + "'  AND `Password` = '" + PasswordBox.Password + "'", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Yes logged in");
                NavigationWindow window = new NavigationWindow();
                
                window.Source = new Uri("Home.xaml", UriKind.Relative);
                window.Show();
                this.Close();

            }
            else
            {
               // MessageBox.Show("Invalid Login please check username and password");
                connection.Close();
                Console.WriteLine("Done.");
            }
        }
    }
}
