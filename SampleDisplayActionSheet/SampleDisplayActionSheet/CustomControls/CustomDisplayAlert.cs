using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleDisplayActionSheet.CustomControls
{
    public class CustomDisplayAlert
    {
        public static async Task<object> ShowDialogAsync(string title, string description = "", params string[] options)
        {
            var popup = new BaseDialog(title, description, options);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);

            return await popup.PagePopupTask;
        }
    }
}
