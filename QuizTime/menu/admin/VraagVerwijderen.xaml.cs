using MySql.Data.MySqlClient;
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

namespace QuizTime.menu.admin
{
    /// <summary>
    /// Interaction logic for VraagVerwijderen.xaml
    /// </summary>
    public partial class VraagVerwijderen : Window
    {
        public VraagVerwijderen()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string serverIp = "localhost";
            string username = "quiztime";
            string password = "SambalBij";
            string databaseName = "quiztime";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(dbConnectionString);
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM vraag WHERE ID = '" + id.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch
                {
                }
            }
            MainWindow w1 = new MainWindow();
            w1.Show();
            this.Close();

        }

    }
}
