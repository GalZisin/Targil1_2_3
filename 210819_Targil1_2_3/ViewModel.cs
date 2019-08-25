using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _210819_slider_Textbox
{
    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo //, IValueConverter
    {
       
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand OkCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

                OkCommand.RaiseCanExecuteChanged();
                CancelCommand.RaiseCanExecuteChanged();
            }
        }
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
        public ViewModel()
        {
       
            OkCommand = new DelegateCommand(() =>
            {
                
                MessageBox.Show($"Hello {Name}!");

            }, () => { return CanExecuteGoMethod();}); 


            CancelCommand = new DelegateCommand(() =>
            {
                Name = string.Empty;
                OnPropertyChanged("Name");
            }, () => { return CanExecuteCancelMethod(); }); 

        }

        public string this[string propertyName]
        {
            get
            {
                return GetErrorForProperty(propertyName);
            }
        }
        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "Name":
                    if (Name == null)
                    {
                        return string.Empty;
                    }
                    else if (Name.Length > 10)
                    {
                        return "Over 10 characters";
                    }
                    else
                        return string.Empty;
                default:
                    return string.Empty;
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private bool CanExecuteGoMethod()
        {
            if (Name != null)
            {
                return (Name.Length >= 3);
            }
            return false;
        }

        private bool CanExecuteCancelMethod()
        {
            if (Name != null)
            {
                return (Name.Length >= 1);
            }
            return false;
        }

    }
}
