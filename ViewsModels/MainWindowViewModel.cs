using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppLab19.Models;

namespace WpfAppLab19.ViewsModels
{
    class MainWindowViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int radius;
        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double otvet;
        public double Otvet
        {
            get => otvet;
            set
            {
                otvet = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }

        private void OnAddCommand(object p)
        {
            Otvet = ArifGeometr.Add(Radius);
        }
        private bool CanOnAddComandExecute(object p)
        {
            if (radius >= 0 ) return true; 
            else return false; 
           
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommand, CanOnAddComandExecute);
        }


    }
}
