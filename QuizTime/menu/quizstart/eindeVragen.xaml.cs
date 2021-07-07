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
    /// Interaction logic for eindeVragen.xaml
    /// </summary>
    public partial class eindeVragen : Window
    {
        private string dezeQuiz;
        private int vc;
        public eindeVragen(string welkeQuiz, int vragenCount)
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            vc = vragenCount;
            dezeQuiz = welkeQuiz;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            antwoord w2 = new antwoord(dezeQuiz, 1, vc);
            w2.Show();

            this.Close();
        }
    }
}
