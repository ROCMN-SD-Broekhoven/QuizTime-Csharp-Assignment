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

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            menu.quizstart.WindowChooseQuiz w2 = new menu.quizstart.WindowChooseQuiz();
            w2.Show();

            this.Close();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            menu.admin.AdminHomeMetVragenlijst w2 = new menu.admin.AdminHomeMetVragenlijst();
            w2.Show();

            this.Close();
        }
    }
}
