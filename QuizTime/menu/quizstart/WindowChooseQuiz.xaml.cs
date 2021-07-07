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

namespace QuizTime.menu.quizstart
{
    /// <summary>
    /// Interaction logic for WindowChooseQuiz.xaml
    /// </summary>
    public partial class WindowChooseQuiz : Window
    {
        private string[] vulling;

        public WindowChooseQuiz()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            vulling = Vullen();
            if (vulling == null)
            {
                lb.Visibility= Visibility.Hidden;
            }
            else
            {
                for (int i = 0; i < vulling.Length; i++)
                {
                    lb.Items.Add(vulling[i].ToString());
                }
            }
        }

        public string[] Vullen()
        {
            //moet nog met db
            string[] tijdelijkevulling = new string[0];

            string serverIp = "localhost";
            string username = "quiztime";
            string password = "SambalBij";
            string databaseName = "quiztime";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            string query = "SELECT * from quizen";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            //trycatch database en anders default values
            try
            {
                conn.Open();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string someValue = reader["QuizNaam"].ToString();

                    Array.Resize(ref tijdelijkevulling, tijdelijkevulling.Length + 1);
                    tijdelijkevulling[tijdelijkevulling.Length - 1] = someValue;
                }
            }
            catch
            {

            }
            return tijdelijkevulling;
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = lb.SelectedItem.ToString();
            vraag w2 = new vraag(item, 1, getVragenCount(item));
            w2.Show();

            this.Close();
        }

        private int getVragenCount(string quizNaam)
        {
            int tijdelijkeCounter = 0;
            string serverIp = "localhost";
            string username = "quiztime";
            string password = "SambalBij";
            string databaseName = "quiztime";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            string query = string.Format("SELECT COUNT(*) FROM vraag WHERE QuizNaam = '{0}'", quizNaam);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            //trycatch database en anders default values
            try
            {
                conn.Open();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tijdelijkeCounter = Int32.Parse(reader["Count(*)"].ToString());
                }
            }
            catch
            {

            }
            return tijdelijkeCounter;
        }
    }
}
