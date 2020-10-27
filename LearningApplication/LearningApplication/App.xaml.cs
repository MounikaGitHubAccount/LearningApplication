using System;
using System.IO;
using LearningApplication.Database;
using LearningApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApplication
{
    public partial class App : Application
    {
        static TaskrDatabase database;
        static TaskrDatabase tasksDatabase;

        public static TaskrDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TaskrDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SampleDatabase.db3"));
                }
                return database;
            }
        }

        public static TaskrDatabase TasksDatabase
        {
            get
            {
                if (tasksDatabase == null)
                {
                    tasksDatabase = new TaskrDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SampleDatabase.db3"));
                }
                return tasksDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new HomePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
