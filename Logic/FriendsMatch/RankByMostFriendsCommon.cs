using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using Logic.FriendsMatcher;

namespace Logic.FriendsMatcher
{
    public class RankByMostFriendsCommon : IRankable
    {
        public string Name { get => "Rank by common friends"; }

        public double RankFriend(User i_User, User i_FriendToCompare)
        {
            MatchCommonInObjectCollection matcher = new MatchCommonInObjectCollection();
            int countOfCommon = 0;
            int countOfTotal = 1;
            try
            {
                matcher.Match<User>(i_User.Friends, i_FriendToCompare.Friends, ref countOfCommon, ref countOfTotal);
            }
            catch
            {
                countOfCommon = 0;
            }

            return countOfCommon / countOfTotal;
        }
    }
}
