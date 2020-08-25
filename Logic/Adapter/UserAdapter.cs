using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using GMap.NET;

namespace Logic
{
    public class UserAdapter : ICalendarItem
    {
        private readonly User m_User;

        public UserAdapter(User i_User)
        {
            m_User = i_User;
        }

        public string EventName => string.Format("{0} Birthday", m_User.Name);

        public string OwnerName => string.Empty;

        public string Description => string.Empty;

        public DateTime? StartTime
        {
            get
            {
                DateTime BirthDay;
                DateTime? StartTime = null;
                if (m_User.Birthday != null)
                {
                    try
                    {
                        BirthDay = DateTime.ParseExact(m_User.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        BirthDay = DateTime.ParseExact(m_User.Birthday, "MM/dd", CultureInfo.InvariantCulture);
                    }

                    StartTime = new DateTime(DateTime.Today.Year, BirthDay.Month, BirthDay.Day);

                    if (StartTime < DateTime.Today)
                    {
                        StartTime = new DateTime(DateTime.Today.Year + 1, BirthDay.Month, BirthDay.Day);
                    }
                }

                return StartTime;
            }
        }

        public DateTime? EndTime => StartTime;

        public string Birthday => m_User.Birthday;

        public string ImageNormal => m_User.PictureNormalURL;

        public string LinkToFacebook => m_User.Link;

        public FacebookObjectCollection<User> AttendingUsers
        {
            get
            {
                FacebookObjectCollection<User> test = new FacebookObjectCollection<User>();
                return test;
            }
        }

        public PointLatLng Position
        {
            get
            {
                PointLatLng Position = PointLatLng.Empty;
                if (m_User.Hometown != null)
                {
                    Position = new PointLatLng((double)m_User.Hometown.Location.Latitude, (double)m_User.Hometown.Location.Longitude);
                }

                return Position;
            }
        }

        public string PlaceName
        {
            get
            {
                string placeName = null;
                if (m_User.Hometown != null)
                {
                    if (m_User.Hometown.Name != null)
                    {
                        placeName = m_User.Hometown.Name;
                    }
                }

                return placeName;
            }
        }
    }
}
