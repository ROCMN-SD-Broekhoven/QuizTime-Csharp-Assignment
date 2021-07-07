using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTime.menu.quizstart
{
    class Vraag
    {
        public string vraagtitel;
        public string imgpath;
        public string antwoord;
        public string f1;
        public string f2;
        public string f3;

        public void getVraag(string quiz, int vraagnr)
        {
            //standaard waarden
            vraagtitel = "vraag1";
            imgpath = "none";
            antwoord = "antwoord";
            f1 = "fout 1";
            f2 = "fout 2";
            f3 = "fout 3";


            //haal db info op
            string serverIp = "localhost";
            string username = "quiztime";
            string password = "SambalBij";
            string databaseName = "quiztime";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            string query = string.Format("SELECT * FROM (SELECT * FROM vraag WHERE QuizNaam = '{0}' ORDER BY ID LIMIT {1}) AS T ORDER BY ID DESC LIMIT 1", quiz, vraagnr);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            //trycatch database en anders default values
            try
            {
                conn.Open();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    vraagtitel = reader["Vraag"].ToString();
                    imgpath = reader["ImgPath"].ToString();
                    antwoord = reader["Antwoord"].ToString();
                    f1 = reader["F1"].ToString();
                    f2 = reader["F2"].ToString();
                    f3 = reader["F3"].ToString();
                }
            }
            catch
            {

            }
        }
    }
}
