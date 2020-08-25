using System;
using System.Collections.Generic;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Logic.FriendsMatcher
{
    internal class FriendsWithRank
    {
        public User Friend { get; set; }

        public double Rank { get; set; }

        public FriendsWithRank(User i_Friend, double i_Rank)
        {
            Friend = i_Friend;
            Rank = i_Rank;
        }
    }
}
