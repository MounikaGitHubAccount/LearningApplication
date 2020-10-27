using System;
using System.Collections.Generic;
using System.Windows.Input;
using LearningApplication.Models;
using LearningApplication.Utils;
using Xamarin.Forms;

namespace LearningApplication.ViewModels
{
    public class DetailViewmodel : BaseViewModel
    {
        public ICommand NotesCommand { get; set; }
        public ICommand ToDosCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public DetailViewmodel(Home home)
        {
            if (home != null)
            {
                DetailsHeader = home.Name;
            }
            NotesCommand = new Command(() => NotesOnClick());
            ToDosCommand = new Command(() => ToDosOnClick());
            PlusCommand = new Command(() => PlusOnClick());
            BackCommand = new Command(() => BackarrowOnClick());
            IsNotes = true;
            IsToDos = false;
        }

        private void BackarrowOnClick()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
        async void PlusOnClick()
        {
            if (!string.IsNullOrWhiteSpace(TodoValue))
            {
                ToDo task = new ToDo()
                {
                    Name = TodoValue,
                    Status = "uncheckradio.png"
                };

                //Add New Task  
                await App.Database.SaveTodosAsync(task);
                await Application.Current.MainPage.DisplayAlert("Success", "ToDo added Successfully", "OK");
                //Get All Tasks  
                var taskList = await App.Database.GetTodosAsync();
                TodoValue = string.Empty;
                TodoData = taskList;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Required", "Please Enter ToDo name!", "OK");
            }
        }

        private void ToDosOnClick()
        {
            IsNotes = false;
            IsToDos = true;
            NotesTextColor = "#404040";
            ToDosTextColor = "#ffffff";
        }

        private void NotesOnClick()
        {
            IsNotes = true;
            IsToDos = false;
            NotesTextColor = "#ffffff";
            ToDosTextColor = "#404040";
        }

        bool _isNotes = false;
        public bool IsNotes
        {
            get => _isNotes;
            set
            {
                _isNotes = value;
                NotifyPropertyChanged("IsNotes");
            }
        }

        bool _isToDos = true;
        public bool IsToDos
        {
            get => _isToDos;
            set
            {
                _isToDos = value;
                NotifyPropertyChanged("IsToDos");
            }
        }

        string _notesTextColor = "#ffffff";
        public string NotesTextColor
        {
            get => _notesTextColor;
            set
            {
                _notesTextColor = value;
                NotifyPropertyChanged("NotesTextColor");
            }
        }

        string _toDosTextColor = "#404040";
        public string ToDosTextColor
        {
            get => _toDosTextColor;
            set
            {
                _toDosTextColor = value;
                NotifyPropertyChanged("ToDosTextColor");
            }
        }

        string _todoValue = "";
        public string TodoValue
        {
            get => _todoValue;
            set
            {
                _todoValue = value;
                NotifyPropertyChanged("TodoValue");
            }
        }

        string _detailsHeader = "";
        public string DetailsHeader
        {
            get => _detailsHeader;
            set
            {
                _detailsHeader = value;
                NotifyPropertyChanged("DetailsHeader");
            }
        }

        List<ToDo> _todoData;
        public List<ToDo> TodoData
        {
            get => _todoData;
            set
            {
                _todoData = value;
                NotifyPropertyChanged("TodoData");
            }
        }
        string _editorNotes = Application.Current.Properties["Notes"].ToString();
        public string EditorNotes
        {
            get => _editorNotes;
            set
            {
                if (value!=null || value !="")
                {
                     Application.Current.Properties["Notes"] = value;
                     Application.Current.SavePropertiesAsync();
                }
                _editorNotes = value;
                NotifyPropertyChanged("EditorNotes");
            }
        }
    }
}

