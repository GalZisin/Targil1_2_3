using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _210819_slider_Textbox
{
    /// <summary>
    /// Interaction logic for Targil2.xaml
    /// </summary>
    public partial class Targil2 : Window
    {
        private DispatcherTimer timer;
        private int number;
        public Targil2()
        {
           
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
           
            InitializeComponent();
            timer.Tick += (sen1, e1) =>
            {
                timer.Stop();
                //number = Convert.ToInt32(counter.Text);
                if (number > 0)
                {
                    number--;

                    counter.Text = number.ToString();
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }

            };
        }
        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }
        //private void startBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Task.Run(() =>
        //    {
        //        for (int i = 50; i >= 0; i--)
        //        {
        //            Action uiwork = () => { counter.Text = i.ToString(); };
        //            SafeInvoke(uiwork);
        //            Thread.Sleep(250);
        //        }
        //    });
        //}

        //private async void startBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 50; i >= 0; i--)
        //    {
        //        counter.Text = i.ToString();
        //        await Task.Run(() => { Thread.Sleep(250); });
        //    }
        //}

        public void startBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            number = 51;
          
            System.Threading.Thread.Sleep(100);
     
            timer.Start();

            //    //counter.Text = i.ToString();
            //    DispatcherTimer timer;
            //    timer = new DispatcherTimer();
            //    timer.Interval = TimeSpan.FromMilliseconds(250);
            //    int number;


            //        timer.Tick += (sen1, e1) => {

            //                number = Convert.ToInt32(counter.Text);
            //            if (number > 0)
            //            {
            //                number--;

            //                counter.Text = number.ToString();
            //            }
            //            else
            //            {
            //                timer.Stop();
            //            }

            //        };

            //    timer.Start();




        }

    }
}
