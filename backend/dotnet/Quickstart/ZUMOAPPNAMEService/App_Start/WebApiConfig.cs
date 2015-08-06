using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;

namespace ZUMOAPPNAMEService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620681
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

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

