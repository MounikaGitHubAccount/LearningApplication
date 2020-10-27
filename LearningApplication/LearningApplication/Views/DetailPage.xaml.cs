using System;
using System.Collections.Generic;
using LearningApplication.Models;
using LearningApplication.ViewModels;
using Xamarin.Forms;

namespace LearningApplication.Views
{
    public partial class DetailPage : ContentPage
    {
        DetailViewmodel _detailViewmodel;
        public DetailPage(Home home)
        {
            InitializeComponent();
            _detailViewmodel = new DetailViewmodel(home);
            BindingContext = _detailViewmodel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _detailViewmodel.TodoData = await App.Database.GetTodosAsync();
            string Notes = "";
            if (Application.Current.Resources.ContainsKey("Notes"))
            {
                Notes = Application.Current.Properties["Notes"].ToString();
            }
            editorNotes.Text = _detailViewmodel.EditorNotes;
        }
    }
}
