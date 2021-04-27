using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.Helpers
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

        public static void AddRange<T>(this ObservableCollection<T> observable, IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                observable.Add(item);
            }
        }
    }
}
