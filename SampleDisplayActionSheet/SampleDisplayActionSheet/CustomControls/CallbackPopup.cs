using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleDisplayActionSheet.CustomControls
{
    public class CallbackPopup : PopupPage
    {
        private TaskCompletionSource<object> _taskCompletionSource;

        public Task<object> PagePopupTask
        {
            get => _taskCompletionSource.Task;
        }

        public CallbackPopup()
        {
            _taskCompletionSource = new TaskCompletionSource<object>();
        }

        public void SetPopupResult(object result) =>
            _taskCompletionSource.SetResult(result);
    }
}
