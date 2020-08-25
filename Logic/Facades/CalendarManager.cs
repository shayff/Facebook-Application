using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Logic.Facades
{
    public class CalendarManager
    {
        private readonly User r_LoggedInUser;

        public CalendarManager(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        public List<ICalendarItem> GetEvents(DateRangeEventArgs e)
        {
            List<ICalendarItem> MyEvents = new List<ICalendarItem>();
            foreach (Event singleEvent in r_LoggedInUser.Events)
            {
                if (e.Start.Date == ((DateTime)singleEvent.StartTime).Date)
                {
                    MyEvents.Add(new EventAdapter(singleEvent));
                }
            }

            foreach (User friend in r_LoggedInUser.Friends)
            {
                UserAdapter friendAdapt = new UserAdapter(friend);
                if (e.Start.Date == ((DateTime)friendAdapt.StartTime).Date)
                {
                    MyEvents.Add(friendAdapt);
                }
            }

            return MyEvents;
        }
    }
}
