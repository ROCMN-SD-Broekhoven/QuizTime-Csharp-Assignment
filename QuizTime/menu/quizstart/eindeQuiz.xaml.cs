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
    /// Interaction logic for eindeQuiz.xaml
    /// </summary>
    public partial class eindeQuiz : Window
    {
        public eindeQuiz()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w2 = new MainWindow();
            w2.Show();

            this.Close();
        }
    }
}
