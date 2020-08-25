using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Logic.FriendsMatcher
{
    public class Matcher
    {
        public IRankable Ranker { get; set; }

        public Matcher(IRankable i_Ranker)
        {
            Ranker = i_Ranker;
        }

        public double RankFriend(User i_User, User i_FriendToCompare)
        {
            return Ranker.RankFriend(i_User, i_FriendToCompare);
        }
    }
}
