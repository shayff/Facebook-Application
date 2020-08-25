using System;
using FacebookWrapper.ObjectModel;
using GMap.NET;

namespace Logic
{
    public interface ICalendarItem
    {
        string EventName { get; }

        string OwnerName { get; }

        string Description { get; }

        DateTime? StartTime { get; }

        DateTime? EndTime { get; }

        string ImageNormal { get; }

        string LinkToFacebook { get; }

        FacebookObjectCollection<User> AttendingUsers { get; }

        PointLatLng Position { get; }

        string PlaceName { get; }
    }
}
