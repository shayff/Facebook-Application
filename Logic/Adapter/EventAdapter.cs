using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using GMap.NET;

namespace Logic
{
    public class EventAdapter : ICalendarItem
    {
        private readonly Event m_Event;

        public EventAdapter(Event i_Event)
        {
            m_Event = i_Event;
        }

        public string EventName => m_Event.Name;

        public string OwnerName => m_Event.Owner?.Name;

        public string Description => m_Event.Description;

        public DateTime? StartTime => m_Event.StartTime;

        public DateTime? EndTime => m_Event.EndTime;

        public string ImageNormal
        {
            get
            {
                if (m_Event.PictureLargeURL != null)
                {
                    return m_Event.PictureLargeURL;
                }
                else
                {
                    return "Facebook-PIC.jpg";
                }
            }
        }

        public string LinkToFacebook => m_Event.LinkToFacebook;

        public FacebookObjectCollection<User> AttendingUsers
        {
            get
            {
                FacebookObjectCollection<User> attendingUsers = null;
                try
                {
                    attendingUsers = m_Event.AttendingUsers;
                    Logger.Instance.WriteMessage("Successful retrive AtteindUsers of event");
                }
                catch
                {
                    Logger.Instance.WriteMessage("Error retrive AtteindUsers of event");
                }

                return attendingUsers;
            }
        }

        public PointLatLng Position => new PointLatLng((double)m_Event.Place.Location.Latitude, (double)m_Event.Place.Location.Longitude);

        public string PlaceName
        {
            get
            {
                string placeName = null;
                if (m_Event.Place != null)
                {
                    if (m_Event.Place.Location != null)
                    {
                        placeName = m_Event.Place.Location.City;
                    }
                }

                return placeName;
            }
        }
    }
}