using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApplication.Models;
using SQLite;
using Xamarin.Forms;

namespace LearningApplication.Database
{
    public class TaskrDatabase : ContentPage
    {
        readonly SQLiteAsyncConnection _toDosDatabase;
        readonly SQLiteAsyncConnection _taskDatabase;

        public TaskrDatabase(string dbPath)
        {

            //Establishing the conection
            _toDosDatabase = new SQLiteAsyncConnection(dbPath);
            _toDosDatabase.CreateTableAsync<ToDo>().Wait();

            _taskDatabase = new SQLiteAsyncConnection(dbPath);
            _taskDatabase.CreateTableAsync<Home>().Wait();

        }

        // Show the TodosList
        public Task<List<ToDo>> GetTodosAsync()
        {
            return _toDosDatabase.Table<ToDo>().ToListAsync();
        }

        // Save registers
        public Task<int> SaveTodosAsync(ToDo taskr)
        {
           return _toDosDatabase.InsertAsync(taskr);
        }

        // Update Todos
        public Task<int> UpdateTodosAsync(ToDo taskr)
        {
            return _toDosDatabase.UpdateAsync(taskr);
        }

        //Tasks
        //Read All Items  
        public Task<List<Home>> GetTasksAsync()
        {
            return _taskDatabase.Table<Home>().ToListAsync();
        }

        // Save registers
        public Task<int> SaveTasksAsync(Home taskr)
        {
            return _taskDatabase.InsertAsync(taskr);
        }

        // Update Task
        public Task<int> UpdateTasksAsync(Home taskr)
        {
            return _taskDatabase.UpdateAsync(taskr);
        }

        //Delete  
        public Task<int> DeleteItemAsync(Home task)
        {
            return _taskDatabase.DeleteAsync(task);
        }
    }
}

