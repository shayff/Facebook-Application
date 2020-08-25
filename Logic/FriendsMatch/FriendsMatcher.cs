using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Logic.FriendsMatcher
{
    internal class FriendsMatcher
    {
        public Matcher Matcher { get; set; }

        private readonly User r_LoggedInUser;

        public FriendsMatcher(User i_LoggedInUser, IRankable i_RankStragety)
        {
            Matcher = new Matcher(i_RankStragety);
            r_LoggedInUser = i_LoggedInUser;
        }

        public List<User> MatchFriends()
        {
            List<FriendsWithRank> rankedList = new List<FriendsWithRank>();
            List<User> listSorted = new List<User>();
            foreach (User fbfriend in r_LoggedInUser.Friends)
            {
                rankedList.Add(new FriendsWithRank(fbfriend, matchSingleFriend(fbfriend)));
            }

            foreach (FriendsWithRank rankedFriend in rankedList.OrderBy(x => x.Rank).ToList())
            {
                listSorted.Add(rankedFriend.Friend);
            }

            return listSorted;
        }

        private double matchSingleFriend(User i_FriendToCompare)
        {
            return Matcher.RankFriend(r_LoggedInUser, i_FriendToCompare);
        }
    }
}
