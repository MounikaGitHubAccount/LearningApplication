using System;
using LearningApplication.Utils;
using Xamarin.Forms;

namespace LearningApplication.Models
{
    public class Home : BaseViewModel
    {
        public string Name { get; set; }
        string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                NotifyPropertyChanged("Status");
            }
        }
    }

    public class ToDo : BaseViewModel
    {
        public string Name { get; set; }
        string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                NotifyPropertyChanged("Status");
            }
        }
    }
}