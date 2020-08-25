using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using Logic.FriendsMatcher;

namespace Logic.FriendsMatcher
{
    public class RankByMostGroupsCommon : IRankable
    {
        public string Name { get => "Rank by common groups"; }

        public double RankFriend(User i_User, User i_FriendToCompare)
        {
            MatchCommonInObjectCollection matcher = new MatchCommonInObjectCollection();
            int countOfCommon = 0;
            int countOfTotal = 1;
            try
            {
                matcher.Match<Group>(i_User.Groups, i_FriendToCompare.Groups, ref countOfCommon, ref countOfTotal);
            }
            catch
            {
                countOfCommon = 0;
            }

            return countOfCommon / countOfTotal;
        }
    }
}
