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

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during developemnt, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new ZUMOAPPNAMEInitializer());
        }
    }

    public class ZUMOAPPNAMEInitializer : DropCreateDatabaseIfModelChanges<ZUMOAPPNAMEContext>
    {
        protected override void Seed(ZUMOAPPNAMEContext context)
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

