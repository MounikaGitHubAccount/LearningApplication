using System;
using System.Collections.Generic;
using LearningApplication.ViewModels;
using Xamarin.Forms;

namespace LearningApplication.Views
{
    public partial class HomePage : ContentPage
    {
        HomeViewModel _homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();
            BindingContext = _homeViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel.TaskList = await App.TasksDatabase.GetTasksAsync();
        }
    }
}
