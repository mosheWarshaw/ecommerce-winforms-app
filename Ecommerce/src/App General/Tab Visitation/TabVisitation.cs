using System;
using System.Collections.Generic;

namespace ProjectNS.TabVisitationNS
{
    public enum TabName
    {
        ORDER, FINANCE, PURCHASE_HISTORY
    }


    public class TabVisitation
    {
        private Dictionary<TabName, bool> tabs = new Dictionary<TabName, bool>();


        public TabVisitation()
        {
            foreach (TabName tabName in Enum.GetValues(typeof(TabName)))
            {
                tabs[tabName] = false;
            }
        }


        public void SetVisitedToTrue(TabName tabName)
        {
            tabs[tabName] = true;
        }

        /// <summary>
        /// This generally refers to if the tab was visited when the user was logged in,
        /// and a visitation to a tab when not logged in won't be registered.
        /// </summary>
        public bool Visited(TabName tabName)
        {
            return tabs[tabName];
        }
    }
}
