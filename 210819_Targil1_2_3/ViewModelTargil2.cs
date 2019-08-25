using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _210819_slider_Textbox
{
    class ViewModelTargil2 : DispatcherObject, INotifyPropertyChanged
    {
    
        public DelegateCommand StartCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public static bool stop;
        private string counter;
        public string Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
                OnPropertyChanged("Counter");
            }
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
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public ViewModelTargil2()
        {
            
            StartCommand = new DelegateCommand(() =>
            {
                stop = true;
                Thread.Sleep(250);
                stop = false;
                Task.Run(() =>
                {
                    
                    for (int i = 50; i >= 0; i--)
                    {

                        if (stop)
                            break;
                        Action uiwork = () => { Counter = i.ToString(); };
                        SafeInvoke(uiwork);
                        Thread.Sleep(250);
                        Counter = i.ToString();
                    }
                    
                });
            
            },()=>{return true;});
        }
    }
}
