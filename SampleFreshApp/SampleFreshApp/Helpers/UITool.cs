using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SampleFreshApp.CustomPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleFreshApp.Helpers
{
    public static class UITool
    {
        [Obsolete]
        public static async Task Load(Task task) 
        {
            var loadingPage = new PopUpLoadingPage();
            await PopupNavigation.PushAsync(loadingPage);
            await task;
            await PopupNavigation.RemovePageAsync(loadingPage);
        }
    }
}
