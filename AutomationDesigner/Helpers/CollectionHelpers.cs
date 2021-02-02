using Syncfusion.Windows.Forms.Tools.Win32API;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesinger.Helpers
{
    public static class CollectionHelpers
    {
        public static List<string> SettingsToList(this StringCollection stringCollection)
        {
            var tempList = new List<string>();

            if (stringCollection != null && stringCollection.Count > 0)
            {
                foreach (var s in stringCollection)
                {
                    tempList.Add(s);
                }
            }

            return tempList;
        }
    }
}
