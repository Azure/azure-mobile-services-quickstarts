using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace ZUMOAPPNAMEService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            ServiceConfig.Initialize(new ConfigBuilder(options, Initialize));

            Database.SetInitializer(new TodoItemInitializer());
        }

        public static void Initialize(HttpConfiguration config)
        {
            // Use this method to set WebAPI configuration options 
        }

    }

    public class TodoItemInitializer : DropCreateDatabaseIfModelChanges<TodoItemContext>
    {
        protected override void Seed(TodoItemContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = "1", Text = "First item", Complete = false },
                new TodoItem { Id = "2", Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }

}

