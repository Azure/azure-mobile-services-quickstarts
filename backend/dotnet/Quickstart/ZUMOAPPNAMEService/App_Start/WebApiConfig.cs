using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.AppService.Config;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;

namespace ZUMOAPPNAMEService
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
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            // Set default and null value handling to "Include" for Json Serializer
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
            
            Database.SetInitializer(new ZUMOAPPNAMEInitializer());
        }
    }

    public class ZUMOAPPNAMEInitializer : ClearDatabaseSchemaIfModelChanges<ZUMOAPPNAMEContext>
    {
        protected override void Seed(ZUMOAPPNAMEContext context)
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

