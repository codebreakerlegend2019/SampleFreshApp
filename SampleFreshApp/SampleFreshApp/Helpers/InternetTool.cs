using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SampleFreshApp.Helpers
{
    public static class InternetTool
    {
        public static bool IsConnected()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
                return true;

            else if (current == NetworkAccess.ConstrainedInternet)
                return false;

            else if (current == NetworkAccess.Local)
                return false;

            else if (current == NetworkAccess.None)
                return false;

            else if (current == NetworkAccess.Unknown)
                return false;

            else
                return false;
        }
    }
}
