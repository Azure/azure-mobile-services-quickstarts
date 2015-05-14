using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.AppService.Config;
using TryMobileAppsService.DataObjects;
using TryMobileAppsService.Models;

namespace TryMobileAppsService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            AppServiceExtensionConfig.Initialize();
            
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            //config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Remove authorization requirement for the Try Mobile Apps quickstart
            config.Filters.Remove(config.Filters.Single(x => x.Instance is AuthorizeLevelAttribute).Instance);

            Database.SetInitializer(new TryMobileAppsInitializer());
        }
    }

    public class TryMobileAppsInitializer : ClearDatabaseSchemaIfModelChanges<TryMobileAppsContext>
    {
        protected override void Seed(TryMobileAppsContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

