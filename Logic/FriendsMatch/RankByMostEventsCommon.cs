using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using Logic.FriendsMatcher;

namespace Logic.FriendsMatcher
{
    public class RankByMostEventsCommon : IRankable
    {
        private readonly MatchCommonInObjectCollection r_MatcherCommon;

        public string Name { get => "Rank by common events"; }

        public RankByMostEventsCommon()
        {
            r_MatcherCommon = new MatchCommonInObjectCollection();
        }

        public double RankFriend(User i_User, User i_FriendToCompare)
        {
            int countOfCommon = 0;
            int countOfTotal = 1;
            try
            {
                r_MatcherCommon.Match<Event>(i_User.Events, i_FriendToCompare.Events, ref countOfCommon, ref countOfTotal);
            }
            catch
            {
                countOfCommon = 0;
            }

            return countOfCommon / countOfTotal;
        }
    }
}
