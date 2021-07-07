using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminHomeMetVragenlijst.xaml
    /// </summary>
    public partial class AdminHomeMetVragenlijst : Window
    {
        public AdminHomeMetVragenlijst()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            try
            {
                string serverIp = "localhost";
                string username = "quiztime";
                string password = "SambalBij";
                string databaseName = "quiztime";

                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);


                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM vraag";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                        da.Fill(dt);
                }
                vragen.ItemsSource = dt.DefaultView;
            }
            catch
            {

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            switch(content)
            {
                case "Vraag Toevoegen":
                    VraagToevoegen w1 = new VraagToevoegen();
                    w1.Show();
                    this.Close();
                    break;
                case "Quiz Toevoegen":
                    QuizToevoegen w2 = new QuizToevoegen();
                    w2.Show();
                    this.Close();
                    break;
                case "Vraag Verwijderen":
                    VraagVerwijderen w3 = new VraagVerwijderen();
                    w3.Show();
                    this.Close();
                    break;
                default:
                    QuizVerwijderen w4 = new QuizVerwijderen();
                    w4.Show();
                    this.Close();
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow w5 = new MainWindow();
            w5.Show();
            this.Close();
        }
    }
}
