using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for vraag.xaml
    /// </summary>
    public partial class vraag : Window
    {
        private string dezequiz;
        private int dezevraag;
        private DispatcherTimer timer = new DispatcherTimer();
        private int aantalkeren = 6;
        private int counter;


        public vraag(string welkeQuiz, int hoeveelsteVraag, int hoeveelVragenInQuiz)
        {
            InitializeComponent();
            counter = hoeveelVragenInQuiz;
            dezequiz = welkeQuiz;
            dezevraag = hoeveelsteVraag;
            Vraag v = new Vraag();
            v.getVraag(welkeQuiz, hoeveelsteVraag);
            vraagtit.Content = v.vraagtitel;
            if(!(v.imgpath == "none")){
                vraagimg.Source = new ImageSourceConverter().ConvertFromString(v.imgpath) as ImageSource;
            }
            else
            {
                vraagimg.Visibility = Visibility.Hidden;
            }
            bool antwoordIngevuld = false;
            int hoeveelstefout = 1;
            for (int i = 0; i<4; i++){
                if(antwoordIngevuld == true)
                {
                    changeAntwoord(i, false, hoeveelstefout, v);
                    hoeveelstefout++;
                }
                else
                {
                    if(i == 3)
                    {
                        changeAntwoord(i, true, hoeveelstefout, v);
                        antwoordIngevuld = true;
                    }
                    else
                    {
                        Random rnd = new Random();
                        int perCent = rnd.Next(0, 100);
                        if(perCent <= 25)
                        {
                            changeAntwoord(i, true, hoeveelstefout, v);
                            antwoordIngevuld = true;
                        }
                        else
                        {
                            changeAntwoord(i, false, hoeveelstefout, v);
                            hoeveelstefout++;
                        }
                    }
                }


            }
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            timer.Tick += time;
            timer.Start();
            timer.Interval += TimeSpan.FromSeconds(1);
        }

        private void time(object sender, EventArgs e)
        {
            if(aantalkeren == 1)
            {
                volgende();
            }
            timerleft.Content = aantalkeren;
            timerleft.Content = Int32.Parse(timerleft.Content.ToString()) - 1;
            aantalkeren--;
        }

        private void changeAntwoord(int aw, bool iscorrect, int hf, Vraag vr)
        {
            if(iscorrect == false)
            {
                if (aw == 0)
                {
                    if (hf == 1)
                    {
                        vraaga.Content = vr.f1;
                    }
                    else if (hf == 2)
                    {
                        vraaga.Content = vr.f2;
                    }
                    else
                    {
                        vraaga.Content = vr.f3;
                    }
                }
                else if (aw == 1)
                {
                    if (hf == 1)
                    {
                        vraagb.Content = vr.f1;
                    }
                    else if (hf == 2)
                    {
                        vraagb.Content = vr.f2;
                    }
                    else
                    {
                        vraagb.Content = vr.f3;
                    }
                }
                else if (aw == 2)
                {
                    if (hf == 1)
                    {
                        vraagc.Content = vr.f1;
                    }
                    else if (hf == 2)
                    {
                        vraagc.Content = vr.f2;
                    }
                    else
                    {
                        vraagc.Content = vr.f3;
                    }
                }
                else
                {
                    if (hf == 1)
                    {
                        vraagd.Content = vr.f1;
                    }
                    else if (hf == 2)
                    {
                        vraagd.Content = vr.f2;
                    }
                    else
                    {
                        vraagd.Content = vr.f3;
                    }
                }
            }
            else
            {
                if (aw == 0)
                {
                    vraaga.Content = vr.antwoord;
                    
                }
                else if (aw == 1)
                {
                    vraagb.Content = vr.antwoord;
                }
                else if (aw == 2)
                {
                    vraagc.Content = vr.antwoord;
                }
                else
                {
                    vraagd.Content = vr.antwoord;
                }

            }
        }


        private void volgende()
        {
            if (dezevraag == counter)
            {
                eindeVragen w2 = new eindeVragen(dezequiz, counter);
                w2.Show();

                this.Close();
            }
            else
            {
                vraag w2 = new vraag(dezequiz, dezevraag + 1, counter);
                w2.Show();

                this.Close();

            }
        }
    }
}
