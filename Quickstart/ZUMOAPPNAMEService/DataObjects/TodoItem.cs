using Microsoft.WindowsAzure.Mobile.Service;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class TodoItem : TableData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}