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
using System.Windows.Threading;

namespace QuizTime.menu.quizstart
{
    /// <summary>
    /// Interaction logic for antwoord.xaml
    /// </summary>
    public partial class antwoord : Window
    {
        private string dezequiz;
        private int dezevraag;
        private int vraagcounter;
        private DispatcherTimer timer = new DispatcherTimer();
        private int aantalkeren = 6;
        public antwoord(string quiz, int vraagnr, int vc)
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            vraagcounter = vc;
            dezequiz = quiz;
            dezevraag = vraagnr;
            Vraag v = new Vraag();
            v.getVraag(quiz, vraagnr);
            vraagtit.Content = v.vraagtitel;
            Antwoord.Content = v.antwoord;


            InitializeComponent();
            timer.Tick += time;
            timer.Start();
            timer.Interval += TimeSpan.FromSeconds(1);
        }

        private void time(object sender, EventArgs e)
        {
            if (aantalkeren == 1)
            {
                volgende();
            }
            timerleft.Content = aantalkeren;
            timerleft.Content = Int32.Parse(timerleft.Content.ToString()) - 1;
            aantalkeren--;
        }

        private void volgende()
        {
            if (dezevraag == vraagcounter)
            {
                eindeQuiz w2 = new eindeQuiz();
                w2.Show();

                this.Close();
            }
            else
            {
                antwoord w2 = new antwoord(dezequiz, dezevraag + 1, vraagcounter);
                w2.Show();

                this.Close();

            }
        }
    }
}
