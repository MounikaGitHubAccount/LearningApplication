using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using LearningApplication.Models;
using LearningApplication.Utils;
using LearningApplication.Views;
using Xamarin.Forms;

namespace LearningApplication.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand PlusCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }

        public HomeViewModel()
        {
            PlusCommand = new Command(() => PlusOnClick());
            TaskList = new List<Home>
            {
                new Home(){ Name = "TaskList1", Status = "uncheckradio.png"},
                new Home(){ Name = "TaskList2", Status = "uncheckradio.png"},
                new Home(){ Name = "TaskList3", Status = "uncheckradio.png"},
            };
        }

        async void PlusOnClick()
        {
            if (!string.IsNullOrWhiteSpace(TaskValue))
            {
                Home task = new Home()
                {
                    Name = TaskValue,
                    Status = "uncheckradio.png"
                };

                //Add New Task  
                await App.TasksDatabase.SaveTasksAsync(task);
                await Application.Current.MainPage.DisplayAlert("Success", "Task added Successfully", "OK");
                //Get All Tasks  
                var taskList = await App.TasksDatabase.GetTasksAsync();
                TaskValue = string.Empty;
                TaskList = taskList;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Required", "Please Enter Task name!", "OK");
            }
        }

        string _taskValue = "";
        public string TaskValue
        {
            get => _taskValue;
            set
            {
                _taskValue = value;
                NotifyPropertyChanged("TaskValue");
            }
        }

        List<Home> _taskList;
        public List<Home> TaskList
        {
            get => _taskList;
            set
            {
                _taskList = value;
                NotifyPropertyChanged("TaskList");
            }
        }

        Home _selectedTask;
        public Home SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (value != null)
                {
                    if (value.Status == "checkradio.png")
                    {
                        value.Status = "uncheckradio.png";
                    }
                    else if (value.Status == "uncheckradio.png")
                    {
                        value.Status = "checkradio.png";
                    }
                    Application.Current.MainPage.Navigation.PushModalAsync(new DetailPage(value));

                }
                _selectedTask = null;
                NotifyPropertyChanged("SelectedTask");
            }
        }
    }
}

