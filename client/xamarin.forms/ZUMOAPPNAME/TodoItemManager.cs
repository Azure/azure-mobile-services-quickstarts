using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace ZUMOAPPNAME
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public class TodoItemManager
    {
        // Azure
        IMobileServiceSyncTable<TodoItem> todoTable;
        MobileServiceClient client;

        public TodoItemManager()
        {
            this.client = new MobileServiceClient(
                Constants.ApplicationURL,
                Constants.ApplicationKey);

            var store = new MobileServiceSQLiteStore("localstore.db");
            store.DefineTable<TodoItem>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.todoTable = client.GetSyncTable<TodoItem>();
        }

        public async Task SyncAsync()
        {
            await this.todoTable.PullAsync("todoItems", this.todoTable.CreateQuery());
        }

        public async Task<TodoItem> GetTaskAsync(string id)
        {
            try
            {
                return await todoTable.LookupAsync(id);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"INVALID {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR {0}", e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync()
        {
            try
            {
                return new ObservableCollection<TodoItem>(await todoTable.ReadAsync());
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"INVALID {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(TodoItem item)
        {
            if (item.ID == null)
            {
                await todoTable.InsertAsync(item);
                //TodoViewModel.TodoItems.Add(item);
            }
            else
                await todoTable.UpdateAsync(item);
        }

        public async Task DeleteTaskAsync(TodoItem item)
        {
            try
            {
                //TodoViewModel.TodoItems.Remove(item);
                await todoTable.DeleteAsync(item);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"INVALID {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"ERROR {0}", e.Message);
            }
        }
    }
}

